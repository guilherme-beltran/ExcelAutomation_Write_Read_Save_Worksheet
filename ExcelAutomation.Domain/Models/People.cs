using ExcelAutomation.Shared.Entities;
//using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Text;

namespace ExcelAutomation.Domain.Models
{
    public sealed class People : Entity
    {
        public People()
        {
            
        }
        public People(string matricula, string nome, string cpf, string cargo, decimal valorCorrigido, decimal totalPagoAdministrativo)
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

        public void Create(string matricula,
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

        public decimal SomarValorCorrigido(DataTable dataTable)
        {
            decimal soma = 0;

            for (int row = 7; row < dataTable.Rows.Count; row++)
            {
                try
                {
                    int ano = Convert.ToInt32(dataTable.Rows[row][2]);
                    int mes = Convert.ToInt32(dataTable.Rows[row][3]);
                    object valorCorrigidoObj = dataTable.Rows[row][6];

                    if (!Convert.IsDBNull(valorCorrigidoObj))
                    {
                        decimal valorCorrigido = Convert.ToDecimal(valorCorrigidoObj);

                        if (ano < 2004 || (ano == 2004 && mes <= 8))
                        {
                            soma += valorCorrigido;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erro ao converter valor na linha {row}: {ex.Message}");
                }
            }

            return soma;
        }

        public decimal ObterTotalDevido(DataTable dataTable)
        {
            return Convert.ToDecimal(dataTable.Rows[85][8]);
        }
    }
}