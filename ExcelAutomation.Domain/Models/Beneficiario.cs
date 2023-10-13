using ExcelAutomation.Shared.Entities;

namespace ExcelAutomation.Domain.Models
{
    public sealed class Beneficiario : Entity
    {
        public Beneficiario() { }
        public Beneficiario(string matricula, string nome, string cpf, string cargo, decimal valorCorrigido, decimal totalPagoAdministrativo)
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

    }
}