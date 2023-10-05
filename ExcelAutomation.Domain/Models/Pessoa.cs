using ExcelAutomation.Shared.Entities;
using Microsoft.Office.Interop.Excel;

namespace ExcelAutomation.Domain.Models
{
    public sealed class Pessoa : Entity
    {
        public Pessoa()
        {
            
        }
        public Pessoa(string matricula, string nome, string cpf, string cargo, decimal valorCorrigido, decimal totalPagoAdministrativo)
        {
            Matricula = matricula;
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            ValorCorrigido = valorCorrigido;
            TotalPagoAdministrativo = totalPagoAdministrativo;
        }

        public string Matricula { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Cargo { get; private set; }
        public decimal ValorCorrigido { get; private set; }
        public decimal TotalPagoAdministrativo { get; private set; }

        public void Criar(string matricula,
                          string nome,
                          string cpf,
                          string cargo,
                          decimal valorCorrigido,
                          decimal totalPagoAdministrativo)
        {
            Matricula = matricula;
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            ValorCorrigido = valorCorrigido;
            TotalPagoAdministrativo = totalPagoAdministrativo;
        }

        public decimal SomarValorCorrigido(Worksheet worksheet)
        {
            decimal soma = 0;

            for (int row = 8; row <= worksheet.Rows.Count; row++)
            {
                int ano = Convert.ToInt32(worksheet.Cells[row, 3].Value2);
                int mes = Convert.ToInt32(worksheet.Cells[row, 4].Value2);

                // Verificar se o ano é menor ou igual a 2004 e o mês é menor ou igual a 8
                if (ano < 2004 || (ano == 2004 && mes <= 8))
                {
                    decimal valorCorrigido = Convert.ToDecimal(worksheet.Cells[row, 7].Value2);
                    soma += valorCorrigido;
                }
                else
                {
                    break;
                }
            }

            return soma;
        }

        public async Task<decimal> ObterTotalDevido(Worksheet worksheet)
        {
            return Convert.ToDecimal(worksheet.Cells[86, 9].Value2);
            //decimal soma = 0;

            //for (int row = 8; row <= worksheet.Rows.Count; row++)
            //{
            //    int ano = Convert.ToInt32(worksheet.Cells[row, 3].Value2);
            //    int mes = Convert.ToInt32(worksheet.Cells[row, 4].Value2);

            //    // Verificar se o ano é menor ou igual a 2004 e o mês é menor ou igual a 8
            //    if (ano < 2004 || (ano == 2004 && mes <= 8))
            //    {
            //        decimal valorCorrigido = Convert.ToDecimal(worksheet.Cells[86, 9].Value2);
            //        soma += valorCorrigido;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return soma;
        }
    }
}