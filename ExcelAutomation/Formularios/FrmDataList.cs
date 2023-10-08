using ExcelAutomation.Domain.Models;
using ExcelAutomation.Layouts;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExcelAutomation.Formularios
{
    public partial class FrmDataList : MaterialForm
    {
        #region Variavies e propriedades

        private List<People> __pessoas;
        private Microsoft.Office.Interop.Excel.Application __excel;
        private Workbook __workbook;
        private Worksheet __worksheet1;
        private Worksheet __worksheet2;
        private int __qtdArquivosLidos;
        private Stopwatch __stopwatch;
        private List<Stopwatch> __stopwatches;


        private readonly string[] colunas = { "Matrícula", "Nome", "Cpf", "Cargo", "Valor Corrigido", "Total Devido" };
        private readonly bool[] colVisivel = { true, true, true, true, true, true };
        private readonly int[] larguraColunas = { 150, 200, 100, 150, 150, 150 };

        #endregion

        #region Construtores

        public FrmDataList()
        {
            InitializeComponent();
            __stopwatch = new Stopwatch();
            __stopwatches = new List<Stopwatch>();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue900, Primary.Blue900, Accent.Blue700, TextShade.WHITE);
        }

        #endregion

        #region Botões

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*",
                FileName = "nome_do_arquivo.xlsx" // Nome padrão do arquivo
            };


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Export(filePath);
            }
        }

        private async void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*"
            };
            //await Production(openFileDialog);
            #region Benchmark
            await Benchmark(openFileDialog);
            #endregion
        }

        private async Task Production(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblProgressoLeitura.Visible = true;
                pbImportacao.Maximum = openFileDialog.FileNames.Length;
                pbImportacao.Visible = true;

                lblArqSelecionados.Text = openFileDialog.FileNames.Length.ToString();

                try
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        await Read(file);
                        __qtdArquivosLidos++;
                        pbImportacao.Value = __qtdArquivosLidos;
                        lblArqLidos.Text = __qtdArquivosLidos.ToString();
                    }
                    pbImportacao.Value = 0;
                    pbImportacao.Visible = false;
                    lblProgressoLeitura.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
                }

            }
        }

        private async Task Benchmark(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblProgressoLeitura.Visible = true;
                pbImportacao.Maximum = openFileDialog.FileNames.Length;
                pbImportacao.Value = 0;
                pbImportacao.Visible = true;
                lblArqSelecionados.Text = openFileDialog.FileNames.Length.ToString();

                lblTempoTotal.Visible = true;
                lblTempoArquivo.Visible = true;

                __stopwatch = new Stopwatch();
                __stopwatch.Start();

                __stopwatches.Clear();
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    __stopwatches.Add(new Stopwatch());
                }
                try
                {
                    pbImportacao.Maximum = openFileDialog.FileNames.Length;
                    for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                    {
                        __stopwatches[i].Start();
                        await Read(openFileDialog.FileNames[i]);
                        __stopwatches[i].Stop();

                        lblTempoArquivo.Text = $"Tempo arquivo {i + 1}: {__stopwatches[i].Elapsed.ToString(@"mm\:ss\.fff")}";

                        __qtdArquivosLidos++;
                        pbImportacao.Value = __qtdArquivosLidos;
                        lblArqLidos.Text = __qtdArquivosLidos.ToString();
                    }
                    lblProgressoLeitura.Visible = false;
                    pbImportacao.Value = 0;
                    pbImportacao.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
                }
                finally
                {
                    __stopwatch.Stop();
                    lblTempoTotal.Text = $"Tempo total: {__stopwatch.Elapsed.ToString(@"mm\:ss")}";
                }

            }
        }

        private async Task Epplus(OpenFileDialog openFileDialog)
        {

        }

        #endregion

        #region Métodos

        private async Task Read(string filePath)
        {
            __excel = new Microsoft.Office.Interop.Excel.Application();
            __workbook = __excel.Workbooks.Open(filePath);

            __worksheet1 = __workbook.Worksheets[1];
            __worksheet2 = __workbook.Worksheets[2];

            await Fill();

            await CloseExcel(__excel);
        }
        private async Task Fill()
        {
            //var pessoa = new People();

            //var matricula = __worksheet1.Cells[1, 3].Value2?.ToString()!.Substring(__worksheet1.Cells[1, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim();
            //var nome = __worksheet1.Cells[2, 3].Value2?.ToString()!.Substring(__worksheet1.Cells[2, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim();
            //var cpf = __worksheet1.Cells[3, 3].Value2?.ToString()!.Substring(__worksheet1.Cells[3, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim();
            //var cargo = __worksheet1.Cells[4, 3].Value2?.ToString()!.Substring(__worksheet1.Cells[4, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim();
            //var valorCorrigido = pessoa.SomarValorCorrigido(__worksheet1);
            //var totalDevido = await pessoa.ObterTotalDevido(__worksheet2);

            //pessoa.Criar(matricula: matricula,
            //            nome: nome,
            //            cpf: cpf,
            //            cargo: cargo,
            //            valorCorrigido: valorCorrigido,
            //            totalPagoAdministrativo: totalDevido);

            ////"Matrícula", "Nome", "Cpf", "Cargo", "Valor Corrigido", "Total Devido"
            //dtgDados.Rows.Add(pessoa.Matricula,
            //                  pessoa.Nome,
            //                  pessoa.Cpf,
            //                  pessoa.Cargo,
            //                  pessoa.ValorCorrigido,
            //                  pessoa.TotalPagoAdministrativo);
        }
        private async Task Export(string filePath)
        {
            try
            {
                __excel = new Microsoft.Office.Interop.Excel.Application();

                var workbook = __excel.Workbooks.Add();
                var worksheet = workbook.Worksheets[1];

                for (int col = 0; col < dtgDados.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1] = dtgDados.Columns[col].HeaderText;
                }

                for (int row = 0; row < dtgDados.Rows.Count; row++)
                {
                    for (int col = 0; col < dtgDados.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1] = dtgDados.Rows[row].Cells[col].Value.ToString();
                    }
                }

                workbook.SaveAs(filePath);
                MessageBox.Show("Dados exportados para o Excel com sucesso!");

                await CloseExcel(__excel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}");
            }
        }
        private void CarregarLayoutDatagrid()
        {
            LayoutDataGridView.GerarLayoutDataGridView(
                           dataGridView: dtgDados,
                           corFundoColunaSelecionada: Color.White,
                           corLetraColunaSelecionada: Color.Black,
                           corFundoColunaNaoSelecionada: Color.White,
                           corLetraColunaNaoSelecionada: Color.Black,
                           corFundoLinhaSelecionada: Color.RoyalBlue,
                           corLetraLinhaSelecionada: Color.Black,
                           corFundoLinhaNaoSelecionada: Color.White,
                           corLetraLinhaNaoSelecionada: Color.Black,
                           null,
                           new System.Drawing.Font("Segoe UI", 10)
                           );
            LayoutDataGridView.PreencherDataGridView(dataGridView: dtgDados, nomesColunas: colunas, colunaVisivel: colVisivel, tamanhoColunas: larguraColunas);
        }
        private static async Task CloseExcel(Microsoft.Office.Interop.Excel.Application app)
        {
            var id = 0;
            var intptr = new IntPtr(app.Hwnd);
            Process? p = null;
            try
            {
                GetWindowThreadProcessId(intptr, out id);
                p = Process.GetProcessById(id);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao executar KillExcel: {ex.Message}");
            }
        }

        #endregion

        #region Eventos

        private void FrmDataList_Load(object sender, EventArgs e)
        {
            CarregarLayoutDatagrid();
        }
        [DllImport("User32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        #endregion
    }
}
