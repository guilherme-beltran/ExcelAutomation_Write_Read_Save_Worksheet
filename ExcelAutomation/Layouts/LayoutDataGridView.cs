namespace ExcelAutomation.Layouts
{
    public static class LayoutDataGridView
    {
        public static void GerarLayoutDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;

            //Cor da divisoria entre as linhas
            dataGridView.GridColor = Color.White;

            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersHeight = 54;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 234, 255);
            dataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
            dataGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.DividerHeight = 3;
            dataGridView.RowTemplate.Height = 40;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.ScrollBars = ScrollBars.Both;
        }
        public static void GerarLayoutDataGridView(DataGridView dataGridView, Color corFundoColunaSelecionadaOuNao, Color corLetraColunaSelecionadaOuNao)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;

            //Cor da divisoria entre as linhas
            dataGridView.GridColor = Color.White;

            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = corFundoColunaSelecionadaOuNao;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = corLetraColunaSelecionadaOuNao;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = corFundoColunaSelecionadaOuNao;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = corLetraColunaSelecionadaOuNao;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersHeight = 54;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 234, 255);
            dataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 17, 153, 248);
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
            dataGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.DividerHeight = 3;
            dataGridView.RowTemplate.Height = 40;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.ScrollBars = ScrollBars.Both;
        }
        public static void GerarLayoutDataGridView(DataGridView dataGridView, Color corFundoColunaSelecionada, Color corLetraColunaSelecionada, Color corFundoColunaNaoSelecionada, Color corLetraColunaNaoSelecionada, Color corFundoLinhaSelecionada, Color corLetraLinhaSelecionada, Color corFundoLinhaNaoSelecionada, Color corLetraLinhaNaoSelecionada, Font fonteColuna = null, Font fonteLinha = null, int[] tamanhoColunas = null)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersHeight = 54;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.DividerHeight = 3;
            dataGridView.RowTemplate.Height = 40;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ScrollBars = ScrollBars.Both;
            //dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Cor da divisória entre as linhas
            dataGridView.GridColor = Color.White;

            // Cor de fundo da coluna quando não está selecionada
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = corFundoColunaNaoSelecionada;
            // Cor da letra da coluna quando não está selecionada
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = corLetraColunaNaoSelecionada;
            // Cor de fundo da coluna quando for selecionada
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = corFundoColunaSelecionada;
            // Cor da letra da coluna quando for selecionada
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = corLetraColunaSelecionada;
            // Fonte da coluna
            dataGridView.ColumnHeadersDefaultCellStyle.Font = fonteColuna ?? new Font("Segoe UI", 12, FontStyle.Regular);

            // Cor de fundo da linha quando não está selecionada
            dataGridView.RowTemplate.DefaultCellStyle.BackColor = corFundoLinhaNaoSelecionada;
            // Cor da letra da linha quando não está selecionada
            dataGridView.RowTemplate.DefaultCellStyle.ForeColor = corLetraLinhaNaoSelecionada;
            // Cor de fundo da linha quando for selecionada
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = corFundoLinhaSelecionada;
            // Cor da letra da linha quando for selecionada
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = corLetraLinhaSelecionada;
            // Fonte da linha
            dataGridView.RowTemplate.DefaultCellStyle.Font = fonteLinha ?? new Font("Segoe UI", 9.75f, FontStyle.Regular);

            if (tamanhoColunas != null && tamanhoColunas.Length == dataGridView.Columns.Count)
            {
                for (int i = 0; i < tamanhoColunas.Length; i++)
                {
                    dataGridView.Columns[i].Width = tamanhoColunas[i];
                }
            }
        }

        public static void PreencherDataGridView(DataGridView dataGridView, string[] nomesColunas)
        {
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.Columns.Clear();

            for (int i = 0; i < nomesColunas.Length; i++)
            {
                var coluna = new DataGridViewTextBoxColumn();
                coluna.HeaderText = nomesColunas[i];
                coluna.Name = nomesColunas[i];
                coluna.Resizable = DataGridViewTriState.True;
                dataGridView.Columns.Add(coluna);
            }
        }

        public static void PreencherDataGridView(DataGridView dataGridView, string[] nomesColunas, bool[] colunaVisivel)
        {
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.Columns.Clear();

            for (int i = 0; i < nomesColunas.Length; i++)
            {
                var coluna = new DataGridViewTextBoxColumn();
                coluna.HeaderText = nomesColunas[i];
                coluna.Resizable = DataGridViewTriState.True;
                dataGridView.Columns.Add(coluna);
            }
            for (int i = 0; i < colunaVisivel.Length; i++)
            {
                dataGridView.Columns[i].Visible = colunaVisivel[i];
            }
        }

        public static void PreencherDataGridView(DataGridView dataGridView, string[] nomesColunas, bool[] colunaVisivel, int[] tamanhoColunas = null)
        {
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.Columns.Clear();

            for (int i = 0; i < nomesColunas.Length; i++)
            {
                var coluna = new DataGridViewTextBoxColumn();
                coluna.HeaderText = nomesColunas[i];
                coluna.Resizable = DataGridViewTriState.True;
                coluna.Width = tamanhoColunas[i];
                dataGridView.Columns.Add(coluna);
            }
            for (int i = 0; i < colunaVisivel.Length; i++)
            {
                dataGridView.Columns[i].Visible = colunaVisivel[i];
            }


        }

    }
}
