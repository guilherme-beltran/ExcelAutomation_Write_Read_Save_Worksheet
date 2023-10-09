using ExcelDataReader;
using System.Data;
using System.Text;

namespace ExcelAutomation.UseCases.Handler
{
    public sealed class ExcelHandler : IDisposable
    {
        private bool disposedValue;

        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public decimal ValorCorrigido { get; set; }
        public decimal TotalDevido { get; set; }

        public void ReadFile(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var matrizValorPagoAdm = new List<List<string>>();
            var matrizPlanilhaCalculos = new List<List<string>>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                do
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "VALOR PAGO ADM.")
                        {
                            var row = new List<string>();
                            for (int col = 0; col < reader.FieldCount; col++)
                            {
                                string cellValue = reader.GetValue(col)?.ToString() ?? string.Empty;
                                row.Add(cellValue);
                            }
                            matrizValorPagoAdm.Add(row);
                        }
                        if (reader.Name == "PLANILHA CÁLCULO")
                        {
                            var row = new List<string>();
                            for (int col = 0; col < reader.FieldCount; col++)
                            {
                                string cellValue = reader.GetValue(col)?.ToString() ?? string.Empty;
                                row.Add(cellValue);
                            }
                            matrizPlanilhaCalculos.Add(row);
                        }
                    }
                } while (reader.NextResult());
            }

            Matricula = matrizValorPagoAdm[0][2];
            Nome = matrizValorPagoAdm[1][2];
            Cpf = matrizValorPagoAdm[2][2];
            Cargo = matrizValorPagoAdm[3][2];
            ValorCorrigido = CalcularValorCorrigidoAteAgosto2004(matrizValorPagoAdm);
            TotalDevido = Convert.ToDecimal(matrizPlanilhaCalculos[85][8]);
        }

        public string GetMatricula()
        {
            var matriculaLimpa = Matricula.Trim();
            return new string(matriculaLimpa.Where(char.IsDigit).ToArray());
        }

        public string GetNome()
        {
            var nomeOriginal = Nome.Trim();
            var prefixo = "Nome";
            return nomeOriginal.Substring(prefixo.Length).Trim();
        }

        public string GetCpf()
        {
            var cpf = Cpf.Trim();
            var textoLimpo = cpf!.Trim();

            return new string(textoLimpo.Where(char.IsDigit).ToArray());
        }

        public string GetCargo()
        {
            var cargoOriginal = Cargo.Trim();
            var prefixo = "Cargo";

            return cargoOriginal.Substring(prefixo.Length).Trim();
        }

        public decimal GetValorCorrigido()
            => ValorCorrigido;

        public decimal GetTotalDevido()
            => TotalDevido;

        public decimal CalcularValorCorrigidoAteAgosto2004(List<List<string>> matriz)
        {
            decimal valorCorrigido = 0;

            for (int row = 7; row < matriz.Count; row++)
            {

                var ano = Convert.ToInt32(matriz[row][2]);
                var mes = Convert.ToInt32(matriz[row][3]);
                var valor = Convert.ToDecimal(matriz[row][6]);

                if ((ano < 2004) || (ano == 2004 && mes <= 8))
                {
                    valorCorrigido += valor;
                }
                else
                {
                    break;
                }
            }

            return valorCorrigido;
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ExcelHelper()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
