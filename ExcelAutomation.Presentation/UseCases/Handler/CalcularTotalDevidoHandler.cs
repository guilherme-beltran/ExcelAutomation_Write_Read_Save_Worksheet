using ExcelAutomation.Presentation.UseCases.Interface;
using Microsoft.Office.Interop.Excel;

namespace ExcelAutomation.Presentation.UseCases.Handler
{
    public sealed class CalcularTotalDevidoHandler : ICalcularTotalDevidoHandler
    {
        private readonly Worksheet worksheet;
        private int __ano;
        private int __mes;

        public decimal TotalDevido { get; private set; }
        public int Ano { get; }
        public int Mes { get; }

        public CalcularTotalDevidoHandler(int ano, int mes)
        {
            Ano = ano;
            Mes = mes;
        }

        public CalcularTotalDevidoHandler(Worksheet worksheet)
        {
            this.worksheet = worksheet;
        }

        public decimal SomarTotalDevido()
        {
            decimal soma = 0;

            for (int row = 8; row <= worksheet.Rows.Count; row++)
            {
                __ano = Convert.ToInt32(worksheet.Cells[row, 3].Value2);
                __mes = Convert.ToInt32(worksheet.Cells[row, 4].Value2);

                #region Verificar se o ano é menor ou igual a 2004 e o mês é menor ou igual a 8

                if (__ano < 2004 || __ano == 2004 && __mes <= 8)
                {
                    decimal valorCorrigido = Convert.ToDecimal(worksheet.Cells[row, 10].Value2);
                    soma += valorCorrigido;
                }
                else
                {
                    break;
                }

                #endregion
            }

            return soma;
        }
    }
}
