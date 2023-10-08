namespace ExcelAutomation.Formularios
{
    partial class FrmDataReader
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
            label3 = new Label();
            btnImportar = new MaterialSkin.Controls.MaterialButton();
            btnExportar = new MaterialSkin.Controls.MaterialButton();
            pgbImportacao = new MaterialSkin.Controls.MaterialProgressBar();
            lblArqLidos = new Label();
            lblProgressoLeitura = new Label();
            panelDados = new Panel();
            dtgDados = new DataGridView();
            panelDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDados).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(857, 427);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 26;
            label3.Text = "Arq. Lidos:";
            label3.Visible = false;
            // 
            // btnImportar
            // 
            btnImportar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnImportar.Depth = 0;
            btnImportar.HighEmphasis = true;
            btnImportar.Icon = null;
            btnImportar.Location = new Point(12, 35);
            btnImportar.Margin = new Padding(4, 6, 4, 6);
            btnImportar.MouseState = MaterialSkin.MouseState.HOVER;
            btnImportar.Name = "btnImportar";
            btnImportar.NoAccentTextColor = Color.Empty;
            btnImportar.Size = new Size(95, 36);
            btnImportar.TabIndex = 24;
            btnImportar.Text = "Importar";
            btnImportar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnImportar.UseAccentColor = false;
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
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
            btnExportar.Location = new Point(879, 35);
            btnExportar.Margin = new Padding(4, 6, 4, 6);
            btnExportar.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportar.Name = "btnExportar";
            btnExportar.NoAccentTextColor = Color.Empty;
            btnExportar.Size = new Size(95, 36);
            btnExportar.TabIndex = 23;
            btnExportar.Text = "Exportar";
            btnExportar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExportar.UseAccentColor = false;
            btnExportar.UseVisualStyleBackColor = true;
            // 
            // pgbImportacao
            // 
            pgbImportacao.Depth = 0;
            pgbImportacao.Location = new Point(15, 452);
            pgbImportacao.MouseState = MaterialSkin.MouseState.HOVER;
            pgbImportacao.Name = "pgbImportacao";
            pgbImportacao.Size = new Size(268, 5);
            pgbImportacao.Style = ProgressBarStyle.Marquee;
            pgbImportacao.TabIndex = 22;
            pgbImportacao.Visible = false;
            // 
            // lblArqLidos
            // 
            lblArqLidos.AutoSize = true;
            lblArqLidos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblArqLidos.Location = new Point(937, 428);
            lblArqLidos.Name = "lblArqLidos";
            lblArqLidos.Size = new Size(19, 21);
            lblArqLidos.TabIndex = 20;
            lblArqLidos.Text = "0";
            lblArqLidos.Visible = false;
            // 
            // lblProgressoLeitura
            // 
            lblProgressoLeitura.AutoSize = true;
            lblProgressoLeitura.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgressoLeitura.Location = new Point(12, 423);
            lblProgressoLeitura.Name = "lblProgressoLeitura";
            lblProgressoLeitura.Size = new Size(100, 25);
            lblProgressoLeitura.TabIndex = 19;
            lblProgressoLeitura.Text = "Progresso:";
            lblProgressoLeitura.Visible = false;
            // 
            // panelDados
            // 
            panelDados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDados.Controls.Add(dtgDados);
            panelDados.Location = new Point(19, 99);
            panelDados.Name = "panelDados";
            panelDados.Size = new Size(962, 295);
            panelDados.TabIndex = 16;
            // 
            // dtgDados
            // 
            dtgDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDados.Dock = DockStyle.Fill;
            dtgDados.Location = new Point(0, 0);
            dtgDados.Name = "dtgDados";
            dtgDados.RowTemplate.Height = 25;
            dtgDados.Size = new Size(962, 295);
            dtgDados.TabIndex = 0;
            // 
            // FrmDataReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 521);
            Controls.Add(label3);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(pgbImportacao);
            Controls.Add(lblArqLidos);
            Controls.Add(lblProgressoLeitura);
            Controls.Add(panelDados);
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MaximumSize = new Size(1007, 521);
            MinimumSize = new Size(1007, 521);
            Name = "FrmDataReader";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDataReader";
            Load += FrmDataReader_Load;
            panelDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private MaterialSkin.Controls.MaterialButton btnImportar;
        private MaterialSkin.Controls.MaterialButton btnExportar;
        private MaterialSkin.Controls.MaterialProgressBar pgbImportacao;
        private Label lblArqLidos;
        private Label lblProgressoLeitura;
        private Panel panelDados;
        private DataGridView dtgDados;
    }
}