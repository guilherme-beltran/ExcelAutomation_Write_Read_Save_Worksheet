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

            Matricula = GetMatricula(matrizValorPagoAdm[0][2]);
            Nome = GetNome(matrizValorPagoAdm[1][2]);
            Cpf = GetCpf(matrizValorPagoAdm[2][2]);
            Cargo = GetCargo(matrizValorPagoAdm[3][2]);
            ValorCorrigido = CalcularValorCorrigidoAteAgosto2004_ValorPagoAdm(matrizValorPagoAdm);
            TotalDevido = CalcularValorCorrigidoAteMaio2001(matrizPlanilhaCalculos);
        }

        public string GetMatricula(string matricula)
        {
            var matriculaLimpa = matricula.Trim();
            return new string(matriculaLimpa.Where(char.IsDigit).ToArray());
        }

        public string GetNome(string nome)
        {
            var nomeOriginal = nome.Trim();
            var prefixo = "Nome";
            return nomeOriginal.Substring(prefixo.Length).Trim();
        }

        public string GetCpf(string cpf)
        {
            cpf = cpf.Trim();
            var textoLimpo = cpf!.Trim();

            return new string(textoLimpo.Where(char.IsDigit).ToArray());
        }

        public string GetCargo(string cargo)
        {
            var cargoOriginal = cargo.Trim();
            var prefixo = "Cargo";

            return cargoOriginal.Substring(prefixo.Length).Trim();
        }

        public decimal CalcularValorCorrigidoAteAgosto2004_ValorPagoAdm(List<List<string>> matriz)
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

        //public decimal CalcularValorCorrigidoAteMaio2001(List<List<string>> matriz)
        //{
        //    decimal valorCorrigido = 0;

        //    for (int row = 7; row < matriz.Count; row++)
        //    {

        //        var ano = Convert.ToInt32(matriz[row][2]);
        //        var mes = Convert.ToInt32(matriz[row][3]);
        //        var valor = Convert.ToDecimal(matriz[row][8]);

        //        if ((ano < 2001) || (ano == 2001 && mes <= 5))
        //        {
        //            valorCorrigido += valor;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    return valorCorrigido;
        //}

        public decimal CalcularValorCorrigidoAteMaio2001_PlanilhaCalculo(List<List<string>> matriz)
        {
            decimal valorCorrigido = 0;
            bool pularDuasLinhas = false;

            for (int row = 7; row < matriz.Count; row++)
            {
                var anoString = matriz[row][2];
                var mesString = matriz[row][3];
                var valorString = matriz[row][8];

                // Verificar se as células contêm valores válidos
                if (int.TryParse(anoString, out int ano) && int.TryParse(mesString, out int mes) && decimal.TryParse(valorString, out decimal valor))
                {
                    // Verificar a condição do ano e do mês
                    if ((ano < 2001) || (ano == 2001 && mes <= 5))
                    {
                        if (!pularDuasLinhas)
                        {
                            valorCorrigido += valor;
                        }
                    }
                    else
                    {
                        // Se encontrar um novo ano, pule duas linhas
                        pularDuasLinhas = true;
                    }
                }
                else
                {
                    // Se não puder converter para números válidos, pule duas linhas
                    pularDuasLinhas = true;
                }
            }

            return valorCorrigido;
        }

        public decimal CalcularValorCorrigidoAteMaio2001(List<List<string>> matriz)
        {
            decimal valorCorrigido = 0;
            bool pularDuasLinhas = false;

            for (int row = 7; row < matriz.Count; row++)
            {
                var anoString = matriz[row][2];
                var mesString = matriz[row][3];
                var valorString = matriz[row][8];

                // Verificar se as células contêm valores válidos
                if (!string.IsNullOrWhiteSpace(anoString) && !string.IsNullOrWhiteSpace(mesString) && !string.IsNullOrWhiteSpace(valorString))
                {
                    // Converter as strings para int e decimal fora do if
                    int ano = int.Parse(anoString);
                    int mes = int.Parse(mesString);
                    decimal valor = decimal.Parse(valorString);

                    // Verificar a condição do ano e do mês
                    if (ano < 2001 || (ano == 2001 && mes <= 5))
                    {
                        if (!pularDuasLinhas)
                        {
                            valorCorrigido += valor;
                        }
                    }
                    else
                    {
                        // Se encontrar um novo ano, pule duas linhas
                        pularDuasLinhas = true;
                    }
                }
                else
                {
                    // Se uma das células estiver vazia, pule duas linhas
                    pularDuasLinhas = true;
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

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
