using DocumentFormat.OpenXml.Drawing;
using ExcelAutomation.Domain.Models;
using ExcelAutomation.Layouts;
using ExcelAutomation.UseCases.DadosArquivos;
using ExcelAutomation.UseCases.Helpers;
using MaterialSkin.Controls;
using System.Data;
using System.Windows.Forms;

namespace ExcelAutomation.Formularios
{
    public partial class FrmDataReader : MaterialForm
    {
        private readonly string[] colunas = { "MATRÍCULA", "NOME", "CPF", "CARGO", "VALOR CORRIGIDO", "TOTAL DEVIDO" };
        private readonly bool[] colVisivel = { true, true, true, true, true, true };
        private readonly int[] larguraColunas = { 150, 200, 100, 150, 200, 150 };
        private int __qtdArquivosLidos;
        private int __qtdArquivosSelecionados;
        private DataTable __planilhaValoresPagoAdm;
        private DataTable __planilhaCalculos;
        public FrmDataReader()
        {
            InitializeComponent();
            lblProgressoLeitura.Visible = false;
            pgbImportacao.Visible = false;
        }

        private async void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                __qtdArquivosSelecionados = openFileDialog.FileNames.Length;
                pgbImportacao.Maximum = __qtdArquivosSelecionados;
                label3.Visible = false;
                lblArqLidos.Visible = false;
                lblProgressoLeitura.Visible = true;
                pgbImportacao.Visible = true;

                try
                {
                    btnImportar.Enabled = false;

                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        await Read(filePath);
                    }

                    lblProgressoLeitura.Visible = false;
                    pgbImportacao.Visible = false;
                    label3.Visible = true;
                    lblArqLidos.Visible = true;
                    btnImportar.Enabled = true;

                    pgbImportacao.Value = 0;
                    pgbImportacao.Maximum = __qtdArquivosSelecionados;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
                    btnImportar.Enabled = true;
                }
            }
        }

        private async Task Read(string filePath)
        {
            var dataSet = ExcelHelper.ReadExcelFile(filePath);

            __planilhaValoresPagoAdm = dataSet.Tables[0];
            __planilhaCalculos = dataSet.Tables[1];

            await Fill();
            __qtdArquivosLidos++;
            pgbImportacao.Value++;
            lblArqLidos.Text = __qtdArquivosLidos.ToString();

            // Certifique-se de que o valor da ProgressBar está dentro do intervalo permitido
            if (__qtdArquivosLidos >= pgbImportacao.Minimum && __qtdArquivosLidos <= pgbImportacao.Maximum)
            {
                pgbImportacao.Value = __qtdArquivosLidos;
            }
            else
            {
                // Se estiver fora do intervalo, ajuste-o para o valor máximo ou mínimo
                pgbImportacao.Value = 0;
                pgbImportacao.Maximum = __qtdArquivosSelecionados;
            }
        }

        private async Task Fill()
        {
            if (__planilhaValoresPagoAdm.Rows.Count == 0 || __planilhaCalculos.Rows.Count == 0)
            {
                return;
            }

            var dadosHandler = new DadosHandler(__planilhaValoresPagoAdm);
            for (int i = 0; i < __planilhaValoresPagoAdm.Rows.Count; i++)
            {
                var people = new People();

                var matricula = dadosHandler.ObterMatricula();
                var nome = dadosHandler.ObterNome();
                var cpf = dadosHandler.ObterCpf();
                var cargo = dadosHandler.ObterCargo();
                var valorCorrigido = people.SomarValorCorrigido(__planilhaValoresPagoAdm);
                var totalDevido = people.ObterTotalDevido(__planilhaCalculos);

                people.Criar(matricula: matricula,
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
            }
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

    }
}
