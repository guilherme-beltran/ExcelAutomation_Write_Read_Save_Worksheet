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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataReader));
            btnImportar = new MaterialSkin.Controls.MaterialButton();
            btnExportar = new MaterialSkin.Controls.MaterialButton();
            pgbImportacao = new MaterialSkin.Controls.MaterialProgressBar();
            lblArqLidos = new Label();
            panelDados = new Panel();
            dtgDados = new DataGridView();
            lblAguardando = new MaterialSkin.Controls.MaterialLabel();
            btnLimpar = new MaterialSkin.Controls.MaterialButton();
            panelDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDados).BeginInit();
            SuspendLayout();
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
            btnExportar.Location = new Point(506, 428);
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
            btnExportar.Visible = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // pgbImportacao
            // 
            pgbImportacao.Depth = 0;
            pgbImportacao.Location = new Point(15, 452);
            pgbImportacao.MouseState = MaterialSkin.MouseState.HOVER;
            pgbImportacao.Name = "pgbImportacao";
            pgbImportacao.Size = new Size(310, 5);
            pgbImportacao.Style = ProgressBarStyle.Marquee;
            pgbImportacao.TabIndex = 22;
            pgbImportacao.Visible = false;
            // 
            // lblArqLidos
            // 
            lblArqLidos.AutoSize = true;
            lblArqLidos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblArqLidos.Location = new Point(831, 434);
            lblArqLidos.Name = "lblArqLidos";
            lblArqLidos.Size = new Size(125, 21);
            lblArqLidos.TabIndex = 20;
            lblArqLidos.Text = "Arquivos lidos: 0";
            lblArqLidos.Visible = false;
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
            // lblAguardando
            // 
            lblAguardando.AutoSize = true;
            lblAguardando.Depth = 0;
            lblAguardando.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAguardando.Location = new Point(15, 427);
            lblAguardando.MouseState = MaterialSkin.MouseState.HOVER;
            lblAguardando.Name = "lblAguardando";
            lblAguardando.Size = new Size(281, 19);
            lblAguardando.TabIndex = 27;
            lblAguardando.Text = "Importando dados... Por favor, aguarde.";
            lblAguardando.Visible = false;
            // 
            // btnLimpar
            // 
            btnLimpar.AutoSize = false;
            btnLimpar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLimpar.Depth = 0;
            btnLimpar.HighEmphasis = true;
            btnLimpar.Icon = null;
            btnLimpar.Location = new Point(403, 428);
            btnLimpar.Margin = new Padding(4, 6, 4, 6);
            btnLimpar.MouseState = MaterialSkin.MouseState.HOVER;
            btnLimpar.Name = "btnLimpar";
            btnLimpar.NoAccentTextColor = Color.Empty;
            btnLimpar.Size = new Size(95, 36);
            btnLimpar.TabIndex = 28;
            btnLimpar.Text = "Limpar";
            btnLimpar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLimpar.UseAccentColor = false;
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Visible = false;
            btnLimpar.Click += pbLimpar_Click;
            // 
            // FrmDataReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 521);
            Controls.Add(btnLimpar);
            Controls.Add(lblAguardando);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(pgbImportacao);
            Controls.Add(lblArqLidos);
            Controls.Add(panelDados);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1007, 521);
            MinimumSize = new Size(1007, 521);
            Name = "FrmDataReader";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Excel Automation";
            Load += FrmDataReader_Load;
            panelDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnImportar;
        private MaterialSkin.Controls.MaterialButton btnExportar;
        private MaterialSkin.Controls.MaterialProgressBar pgbImportacao;
        private Label lblArqLidos;
        private Panel panelDados;
        private DataGridView dtgDados;
        private MaterialSkin.Controls.MaterialLabel lblAguardando;
        private MaterialSkin.Controls.MaterialButton btnLimpar;
    }
}