using ExcelAutomation.Domain.Models;
using ExcelAutomation.Layouts;
using ExcelAutomation.UseCases.Handler;
using MaterialSkin.Controls;
using MiniExcelLibs;
using System.Data;
using System.Diagnostics;

namespace ExcelAutomation.Formularios
{
    public partial class FrmDataReader : MaterialForm
    {
        private readonly string[] colunas = { "MATRÍCULA", "NOME", "CPF", "CARGO", "VALOR CORRIGIDO", "TOTAL DEVIDO" };
        private readonly bool[] colVisivel = { true, true, true, true, true, true };
        private readonly int[] larguraColunas = { 150, 200, 100, 150, 200, 150 };
        private int __qtdArquivosLidos;
        private int __qtdArquivosSelecionados;
        private ExcelHandler __excelHandler;

        private Stopwatch stopWatch;
        public FrmDataReader()
        {
            InitializeComponent();
            pgbImportacao.Visible = false;
        }

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
                if (!openFileDialog.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) || !openFileDialog.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Tipo de arquivo inválido. Selecione apenas arquivos .xls ou .xlsx");
                    lblAguardando.Visible = false;
                    return;
                }

                if (openFileDialog.FileNames.Length > 12000)
                {
                    MessageBox.Show($"Não é possível selecionar mais do que 12000 arquivos");
                    lblAguardando.Visible = false;
                    return;
                }

                __qtdArquivosSelecionados = openFileDialog.FileNames.Length;
                pgbImportacao.Maximum = __qtdArquivosSelecionados;
                pgbImportacao.Value = 0;
                pgbImportacao.Visible = true;
                lblArqLidos.Visible = false;

                try
                {
                    btnImportar.Enabled = false;

                    __excelHandler = new ExcelHandler();

                    stopWatch = new Stopwatch();
                    stopWatch.Start();

                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        await Read(filePath);
                    }


                    pgbImportacao.Visible = false;
                    lblAguardando.Visible = false;

                    lblArqLidos.Visible = true;
                    btnImportar.Enabled = true;

                    lblAguardando.Visible = false;
                    btnExportar.Visible = true;
                    btnLimpar.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
                    btnImportar.Enabled = true;
                }
                finally
                {
                    lblArqLidos.Text = $"Arquivos lidos: \n{__qtdArquivosLidos}";
                    __excelHandler.Dispose();

                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    MessageBox.Show($"Tempo total: {elapsedTime}");
                }
            }
            lblAguardando.Visible = false;
        }

        private async Task Read(string filePath)
        {
            __excelHandler.ReadFile(filePath);

            await Fill();
            pgbImportacao.Value++;
        }

        private async Task Fill()
        {
            var people = new People();

            var matricula = __excelHandler.GetMatricula();
            var nome = __excelHandler.GetNome();
            var cpf = __excelHandler.GetCpf();
            var cargo = __excelHandler.GetCargo();
            var valorCorrigido = __excelHandler.GetValorCorrigido();
            var totalDevido = __excelHandler.GetTotalDevido();

            people.Create(matricula: matricula,
                        nome: nome,
                        cpf: cpf,
                        cargo: cargo,
                        valorCorrigido: valorCorrigido,
                        totalPagoAdministrativo: totalDevido);

            dtgDados.Rows.Add(people.Matricula,
                              people.Nome,
                              people.Cpf,
                              people.Cargo,
                              people.ValorCorrigido,
                              people.TotalPagoAdministrativo);

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

        private void FrmDataReader_Load(object sender, EventArgs e)
        {
            CarregarLayoutDatagrid();
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
                    { "MATRÍCULA", row.Cells[0].Value },
                    { "NOME", row.Cells[1].Value },
                    { "CPF", row.Cells[2].Value },
                    { "CARGO", row.Cells[3].Value },
                    { "VALOR CORRIGIDO", row.Cells[4].Value },
                    { "TOTAL DEVIDO", row.Cells[5].Value }
                };

                values.Add(rowData);
            }

            MiniExcel.SaveAs(filePath, values);
            MessageBox.Show("Dados exportados para o Excel com sucesso!");
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
    }
}
