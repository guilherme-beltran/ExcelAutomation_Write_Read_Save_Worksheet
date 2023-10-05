namespace ExcelAutomation.Formularios
{
    partial class FrmListarDados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dtgDadosPlanilhas = new DataGridView();
            btnCarregar = new Button();
            lblArquivosSelecionados = new Label();
            lblQtdRegistros = new Label();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            lblPctCarregamento = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDadosPlanilhas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dtgDadosPlanilhas);
            panel1.Location = new Point(12, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 337);
            panel1.TabIndex = 0;
            // 
            // dtgDadosPlanilhas
            // 
            dtgDadosPlanilhas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDadosPlanilhas.Dock = DockStyle.Fill;
            dtgDadosPlanilhas.Location = new Point(0, 0);
            dtgDadosPlanilhas.Name = "dtgDadosPlanilhas";
            dtgDadosPlanilhas.RowTemplate.Height = 25;
            dtgDadosPlanilhas.Size = new Size(776, 337);
            dtgDadosPlanilhas.TabIndex = 0;
            // 
            // btnCarregar
            // 
            btnCarregar.Location = new Point(309, 413);
            btnCarregar.Name = "btnCarregar";
            btnCarregar.Size = new Size(114, 33);
            btnCarregar.TabIndex = 1;
            btnCarregar.Text = "Carregar";
            btnCarregar.UseVisualStyleBackColor = true;
            btnCarregar.Click += btnCarregar_Click;
            // 
            // lblArquivosSelecionados
            // 
            lblArquivosSelecionados.AutoSize = true;
            lblArquivosSelecionados.Location = new Point(24, 403);
            lblArquivosSelecionados.Name = "lblArquivosSelecionados";
            lblArquivosSelecionados.Size = new Size(128, 15);
            lblArquivosSelecionados.TabIndex = 2;
            lblArquivosSelecionados.Text = "Arquivos selecionados:";
            // 
            // lblQtdRegistros
            // 
            lblQtdRegistros.AutoSize = true;
            lblQtdRegistros.Location = new Point(24, 431);
            lblQtdRegistros.Name = "lblQtdRegistros";
            lblQtdRegistros.Size = new Size(58, 15);
            lblQtdRegistros.TabIndex = 3;
            lblQtdRegistros.Text = "Registros:";
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(558, 423);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(230, 23);
            progressBar1.TabIndex = 4;
            progressBar1.Visible = false;
            // 
            // lblPctCarregamento
            // 
            lblPctCarregamento.AutoSize = true;
            lblPctCarregamento.Location = new Point(558, 403);
            lblPctCarregamento.Name = "lblPctCarregamento";
            lblPctCarregamento.Size = new Size(97, 15);
            lblPctCarregamento.TabIndex = 5;
            lblPctCarregamento.Text = "Carregando... 0%";
            lblPctCarregamento.Visible = false;
            // 
            // FrmListarDados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(lblPctCarregamento);
            Controls.Add(progressBar1);
            Controls.Add(lblQtdRegistros);
            Controls.Add(lblArquivosSelecionados);
            Controls.Add(btnCarregar);
            Controls.Add(panel1);
            Name = "FrmListarDados";
            Text = "FrmListarDados";
            FormClosing += FrmListarDados_FormClosing;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDadosPlanilhas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtgDadosPlanilhas;
        private Button btnCarregar;
        private Label lblArquivosSelecionados;
        private Label lblQtdRegistros;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ProgressBar progressBar1;
        private Label lblPctCarregamento;
    }
}