namespace ExcelAutomation.Formularios
{
    partial class FrmDataList
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
            dtgDados = new DataGridView();
            lblTempoTotal = new Label();
            lblTempoArquivo = new Label();
            lblProgressoLeitura = new Label();
            lblArqLidos = new Label();
            lblArqSelecionados = new Label();
            pbImportacao = new MaterialSkin.Controls.MaterialProgressBar();
            btnExportar = new MaterialSkin.Controls.MaterialButton();
            btnImportar = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dtgDados);
            panel1.Location = new Point(12, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(983, 311);
            panel1.TabIndex = 0;
            // 
            // dtgDados
            // 
            dtgDados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtgDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDados.Location = new Point(0, 0);
            dtgDados.Name = "dtgDados";
            dtgDados.RowTemplate.Height = 25;
            dtgDados.Size = new Size(983, 311);
            dtgDados.TabIndex = 0;
            // 
            // lblTempoTotal
            // 
            lblTempoTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTempoTotal.AutoSize = true;
            lblTempoTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTempoTotal.Location = new Point(757, 432);
            lblTempoTotal.Name = "lblTempoTotal";
            lblTempoTotal.Size = new Size(91, 21);
            lblTempoTotal.TabIndex = 3;
            lblTempoTotal.Text = "Tempo total";
            lblTempoTotal.Visible = false;
            // 
            // lblTempoArquivo
            // 
            lblTempoArquivo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTempoArquivo.AutoSize = true;
            lblTempoArquivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTempoArquivo.Location = new Point(757, 455);
            lblTempoArquivo.Name = "lblTempoArquivo";
            lblTempoArquivo.Size = new Size(186, 21);
            lblTempoArquivo.TabIndex = 4;
            lblTempoArquivo.Text = "Tempo leitura do arquivo:";
            lblTempoArquivo.Visible = false;
            // 
            // lblProgressoLeitura
            // 
            lblProgressoLeitura.AutoSize = true;
            lblProgressoLeitura.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgressoLeitura.Location = new Point(12, 468);
            lblProgressoLeitura.Name = "lblProgressoLeitura";
            lblProgressoLeitura.Size = new Size(100, 25);
            lblProgressoLeitura.TabIndex = 5;
            lblProgressoLeitura.Text = "Progresso:";
            lblProgressoLeitura.Visible = false;
            // 
            // lblArqLidos
            // 
            lblArqLidos.AutoSize = true;
            lblArqLidos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblArqLidos.Location = new Point(92, 434);
            lblArqLidos.Name = "lblArqLidos";
            lblArqLidos.Size = new Size(19, 21);
            lblArqLidos.TabIndex = 6;
            lblArqLidos.Text = "0";
            // 
            // lblArqSelecionados
            // 
            lblArqSelecionados.AutoSize = true;
            lblArqSelecionados.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblArqSelecionados.Location = new Point(152, 409);
            lblArqSelecionados.Name = "lblArqSelecionados";
            lblArqSelecionados.Size = new Size(19, 21);
            lblArqSelecionados.TabIndex = 7;
            lblArqSelecionados.Text = "0";
            // 
            // pbImportacao
            // 
            pbImportacao.Depth = 0;
            pbImportacao.Location = new Point(15, 497);
            pbImportacao.MouseState = MaterialSkin.MouseState.HOVER;
            pbImportacao.Name = "pbImportacao";
            pbImportacao.Size = new Size(268, 5);
            pbImportacao.Style = ProgressBarStyle.Marquee;
            pbImportacao.TabIndex = 11;
            pbImportacao.Visible = false;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExportar.Depth = 0;
            btnExportar.HighEmphasis = true;
            btnExportar.Icon = null;
            btnExportar.Location = new Point(891, 40);
            btnExportar.Margin = new Padding(4, 6, 4, 6);
            btnExportar.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportar.Name = "btnExportar";
            btnExportar.NoAccentTextColor = Color.Empty;
            btnExportar.Size = new Size(95, 36);
            btnExportar.TabIndex = 12;
            btnExportar.Text = "Exportar";
            btnExportar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExportar.UseAccentColor = false;
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImportar
            // 
            btnImportar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnImportar.Depth = 0;
            btnImportar.HighEmphasis = true;
            btnImportar.Icon = null;
            btnImportar.Location = new Point(12, 40);
            btnImportar.Margin = new Padding(4, 6, 4, 6);
            btnImportar.MouseState = MaterialSkin.MouseState.HOVER;
            btnImportar.Name = "btnImportar";
            btnImportar.NoAccentTextColor = Color.Empty;
            btnImportar.Size = new Size(95, 36);
            btnImportar.TabIndex = 13;
            btnImportar.Text = "Importar";
            btnImportar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnImportar.UseAccentColor = false;
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 409);
            label2.Name = "label2";
            label2.Size = new Size(136, 21);
            label2.TabIndex = 14;
            label2.Text = "Arq. Selecionados:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 434);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 15;
            label3.Text = "Arq. Lidos:";
            // 
            // FrmDataList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 521);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(pbImportacao);
            Controls.Add(lblArqSelecionados);
            Controls.Add(lblArqLidos);
            Controls.Add(lblProgressoLeitura);
            Controls.Add(lblTempoArquivo);
            Controls.Add(lblTempoTotal);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MaximumSize = new Size(1007, 521);
            MinimumSize = new Size(1007, 521);
            Name = "FrmDataList";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDataList";
            Load += FrmDataList_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtgDados;
        private Label lblTempoTotal;
        private Label lblTempoArquivo;
        private Label lblProgressoLeitura;
        private Label lblArqLidos;
        private Label lblArqSelecionados;
        private MaterialSkin.Controls.MaterialProgressBar pbImportacao;
        private MaterialSkin.Controls.MaterialButton btnExportar;
        private MaterialSkin.Controls.MaterialButton btnImportar;
        private Label label2;
        private Label label3;
    }
}