using ExcelAutomation.Domain.Models;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ExcelAutomation.Formularios
{
    public partial class FrmListarDados : Form
    {
        private List<Pessoa> __pessoas;
        private int __totalArquivosSelecionados = 0;
        private int __totalArquivosLidos = 0;
        private  Microsoft.Office.Interop.Excel.Application __excel;
        private Workbook __workbook;
        private Worksheet __worksheetValorPagoAdm;
        private Worksheet __worksheetPlanilhaCalculo;
        private const int __limiteArquivos = 100;

        public FrmListarDados()
        {
            InitializeComponent();
        }

        #region Eventos

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LerArquivo(e);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPctCarregamento.Text = $"Carregando... {e.ProgressPercentage}%";
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar os arquivos: {e.Error.Message}");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Carregamento cancelado.");
            }
            else
            {
                MessageBox.Show("Carregamento concluído.");
                List<Pessoa> pessoas = (List<Pessoa>)e.Result;
                dtgDadosPlanilhas.DataSource = pessoas;
                lblQtdRegistros.Text = $"Qtd registros: {pessoas.Count}";
            }
        }

        #endregion

        #region Botões

        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK && SelecaoValida(openFileDialog.FileNames.Length))
            {
                __totalArquivosSelecionados = openFileDialog.FileNames.Length;
                lblArquivosSelecionados.Text = $"Arquivos Selecionados: {__totalArquivosSelecionados}";

                lblPctCarregamento.Visible = true;
                progressBar1.Visible = true;

                try
                {
                    backgroundWorker.RunWorkerAsync(openFileDialog.FileNames);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um falha ao executar a ação. Detalhe: {ex.Message}");
                }

            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Verificar se a quantidade de arquivos selecionados é maior que 50. Se for, não permitir operar no sistema.
        /// </summary>
        /// <param name="quantidadeSelecionada"></param>
        /// <returns></returns>
        private bool SelecaoValida(int quantidadeSelecionada)
        {
            if (quantidadeSelecionada > __limiteArquivos)
            {
                MessageBox.Show($"Por favor, selecione no máximo {__limiteArquivos} arquivos.");
                return false;
            }
            return true;
        }


        private void LerArquivo(DoWorkEventArgs e)
        {
            try
            {
                string[] fileNames = (string[])e.Argument;
                List<Pessoa> pessoas = new List<Pessoa>();

                for (int i = 0; i < fileNames.Length; i++)
                {
                    var filePath = fileNames[i];
                    __excel = new Microsoft.Office.Interop.Excel.Application();
                    __workbook = __excel.Workbooks.Open(filePath);

                    __worksheetValorPagoAdm = __workbook.Worksheets[1];
                    __worksheetPlanilhaCalculo = __workbook.Worksheets[2];

                    PreencherLista(pessoas);

                    KillExcel(__excel);

                    var progressPercentage = (i + 1) * 100 / fileNames.Length;
                    backgroundWorker.ReportProgress(progressPercentage, pessoas);


                    //KillExcel(filePath);
                }

                e.Result = pessoas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro. Detalhe:" + ex.Message);
            }
        }


        private async void PreencherLista(List<Pessoa> pessoas)
        {
            var pessoa = new Pessoa();

            var valorCorrigido = pessoa.SomarValorCorrigido(__worksheetValorPagoAdm);
            var totalDevido = await pessoa.ObterTotalDevido(__worksheetPlanilhaCalculo);

            pessoa.Criar(matricula: __worksheetValorPagoAdm.Cells[1, 3].Value2?.ToString()!.Substring(__worksheetValorPagoAdm.Cells[1, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim(),
                        nome: __worksheetValorPagoAdm.Cells[2, 3].Value2?.ToString()!.Substring(__worksheetValorPagoAdm.Cells[2, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim(),
                        cpf: __worksheetValorPagoAdm.Cells[3, 3].Value2?.ToString()!.Substring(__worksheetValorPagoAdm.Cells[3, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim(),
                        cargo: __worksheetValorPagoAdm.Cells[4, 3].Value2?.ToString()!.Substring(__worksheetValorPagoAdm.Cells[4, 3].Value2.ToString().IndexOf(" ") + 1)?.Trim(),
                        valorCorrigido: valorCorrigido,
                        totalPagoAdministrativo: totalDevido);

            pessoas.Add(pessoa);
        }

        #endregion


        private void FrmListarDados_FormClosing(object sender, FormClosingEventArgs e)
        {
            //KillExcel(__excel);
        }

        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);
        private static void KillExcel(Microsoft.Office.Interop.Excel.Application app)
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
    }
}
