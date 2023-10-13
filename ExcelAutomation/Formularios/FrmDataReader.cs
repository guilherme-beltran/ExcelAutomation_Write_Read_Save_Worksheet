using ExcelAutomation.Domain.Models;
using ExcelAutomation.Layouts;
using ExcelAutomation.UseCases.Handler;
using MaterialSkin.Controls;
using MiniExcelLibs;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExcelAutomation.Formularios
{
    public partial class FrmDataReader : MaterialForm
    {
        #region Variaveis e propriedades

        private readonly string[] colunas = { "MATRÍCULA", "NOME", "CPF", "CARGO", "VALOR PAGO ADMINISTRATIVAMENTE ATÉ A DATA DO TRANSITO EM JULGADO CORRIGIDO ATÉ MAIO/2006", "VALOR DEVIDO AOS BENEFICIÁRIOS ATÉ MAIO/2006" };
        private readonly bool[] colVisivel = { true, true, true, true, true, true };
        private readonly int[] larguraColunas = { 150, 200, 100, 150, 200, 150 };
        private int __qtdArquivosLidos;
        private int __qtdArquivosSelecionados;
        private ExcelHandler __excelHandler;

        private Stopwatch stopWatch;

        #endregion

        #region Construtor

        public FrmDataReader()
        {
            InitializeComponent();
            pgbImportacao.Visible = false;
        }

        #endregion

        #region Eventos

        private void FrmDataReader_Load(object sender, EventArgs e)
        {
            CarregarLayoutDatagrid();
        }

        #endregion

        #region Botões

        private async void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*"
            };

            lblAguardando.Visible = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                if (!ValidarArquivosSelecionados(openFileDialog))
                {
                    return;
                }

                ConfigurarProgressBar();

                try
                {
                    await ProcessarArquivosSelecionados(openFileDialog);

                    ExibirMensagemDeSucesso();

                }
                catch (Exception ex)
                {
                    ExibirMensagemErro(ex);
                }
                finally
                {
                    FinalizarProcessamento();
                }

            }

        }
        private async void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*",
                FileName = "Sem titulo.xlsx"
            };


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnExportar.Enabled = false;
                btnLimpar.Enabled = false;
                string filePath = saveFileDialog.FileName;

                await Export(filePath);

                btnExportar.Enabled = true;
                btnLimpar.Enabled = true;
            }
        }
        private void pbLimpar_Click(object sender, EventArgs e)
        {
            dtgDados.Rows.Clear();
            btnLimpar.Visible = false;
            btnExportar.Visible = false;
            lblArqLidos.Visible = false;
            __qtdArquivosLidos = 0;
            __qtdArquivosSelecionados = 0;
            __excelHandler.Dispose();
        }


        #endregion

        #region Métodos

        private bool ValidarArquivosSelecionados(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.FileNames.Length > 13000)
            {
                MessageBox.Show($"Não é possível selecionar mais do que 13000 arquivos");
                lblAguardando.Visible = false;
                return false;
            }

            if (!ValidarExtensao(openFileDialog.FileNames))
            {
                lblAguardando.Visible = false;
                return false;
            }
            __qtdArquivosSelecionados = openFileDialog.FileNames.Length;
            return true;
        }

        private void ConfigurarProgressBar()
        {
            pgbImportacao.Maximum = __qtdArquivosSelecionados;
            pgbImportacao.Value = 0;
            pgbImportacao.Visible = true;
            lblArqLidos.Visible = false;
        }

        private void ExibirMensagemDeSucesso()
        {
            pgbImportacao.Visible = false;
            lblAguardando.Visible = false;
            lblArqLidos.Visible = true;
            btnImportar.Enabled = true;
            lblArqLidos.Text = $"Arquivos lidos: \n{__qtdArquivosLidos}";
            ExibirTempoTotalCarregamento();
            ExibirBotaoExportarELimpar();
        }

        private async Task ProcessarArquivosSelecionados(OpenFileDialog openFileDialog)
        {
            btnImportar.Enabled = false;
            __excelHandler = new ExcelHandler();
            stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string filePath in openFileDialog.FileNames)
            {
                await Read(filePath);
            }

            openFileDialog.Dispose();
        }

        private void FinalizarProcessamento()
        {
            __excelHandler.Dispose();
            lblAguardando.Visible = false;
        }

        private void ExibirMensagemErro(Exception ex)
        {
            MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
            btnImportar.Enabled = true;
        }

        private void ExibirBotaoExportarELimpar()
        {
            btnExportar.Visible = true;
            btnLimpar.Visible = true;
        }

        private void ExibirTempoTotalCarregamento()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            MessageBox.Show($"Tempo total: {elapsedTime}");
        }

        private bool ValidarExtensao(string[] fileNames)
        {
            foreach (var filePath in fileNames)
            {
                string extensao = Path.GetExtension(filePath).ToLower();
                if (extensao != ".xls" && extensao != ".xlsx")
                {
                    MessageBox.Show($"Arquivo inválido: {filePath}. Por favor, selecione apenas arquivos com extensão .xls ou .xlsx.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private async Task Read(string filePath)
        {
            await Task.Run(() =>
            {
                __excelHandler.ReadFile(filePath);
            });

            await Fill();
            AtualizarProgressBar();
        }

        private void AtualizarProgressBar()
        {
            pgbImportacao.Value++;
        }

        private async Task Fill()
        {
            var beneficiario = new Beneficiario();

            var matricula = __excelHandler.Matricula;
            var nome = __excelHandler.Nome;
            var cpf = __excelHandler.Cpf;
            var cargo = __excelHandler.Cargo;
            var valorCorrigido = __excelHandler.ValorCorrigido;
            var totalDevido = __excelHandler.TotalDevido;

            beneficiario.Create(matricula: matricula,
                        nome: nome,
                        cpf: cpf,
                        cargo: cargo,
                        valorCorrigido: valorCorrigido,
                        totalPagoAdministrativo: totalDevido);

            dtgDados.Rows.Add(beneficiario.Matricula,
                              beneficiario.Nome,
                              beneficiario.Cpf,
                              beneficiario.Cargo,
                              beneficiario.ValorCorrigido,
                              beneficiario.TotalPagoAdministrativo);

            __qtdArquivosLidos++;
        }

        private void CarregarLayoutDatagrid()
        {
            LayoutDataGridView.GerarLayoutDataGridView(dataGridView: dtgDados,
                                                       corFundoColunaSelecionada: Color.White,
                                                       corLetraColunaSelecionada: Color.Black,
                                                       corFundoColunaNaoSelecionada: Color.White,
                                                       corLetraColunaNaoSelecionada: Color.Black,
                                                       corFundoLinhaSelecionada: Color.RoyalBlue,
                                                       corLetraLinhaSelecionada: Color.Black,
                                                       corFundoLinhaNaoSelecionada: Color.White,
                                                       corLetraLinhaNaoSelecionada: Color.Black,
                                                       null,
                                                       new Font("Segoe UI", 10));

            LayoutDataGridView.PreencherDataGridView(dataGridView: dtgDados,
                                                    nomesColunas: colunas,
                                                    colunaVisivel: colVisivel,
                                                    tamanhoColunas: larguraColunas);


        }

        private async Task Export(string filePath)
        {
            if (File.Exists(filePath))
            {
                filePath = Path.Combine(Path.GetDirectoryName(filePath)!,
                    $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now:yyyyMMddHHmmss}.xlsx");
            }

            var values = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dtgDados.Rows)
            {
                var rowData = new Dictionary<string, object>
                {
                    { colunas[0], row.Cells[0].Value },
                    { colunas[1], row.Cells[1].Value },
                    { colunas[2], row.Cells[2].Value },
                    { colunas[3], row.Cells[3].Value },
                    { colunas[4], row.Cells[4].Value },
                    { colunas[5], row.Cells[5].Value }
                };

                values.Add(rowData);
            }

            MiniExcel.SaveAs(filePath, values);
            MessageBox.Show("Dados exportados para o Excel com sucesso!");
        }

        #endregion




    }
}
