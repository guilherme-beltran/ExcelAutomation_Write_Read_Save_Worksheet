using System.Data;

namespace ExcelAutomation.UseCases.DadosArquivos
{
    public class DadosHandler
    {
        public DataTable DataTable { get; private set; }
        public DadosHandler(DataTable dataTable)
        {
            DataTable = dataTable;
        }
        public string ObterMatricula()
        {
            var matriculaOriginal = DataTable.Rows[0][2].ToString();
            var textoLimpo = matriculaOriginal!.Trim();

            return new string(textoLimpo.Where(char.IsDigit).ToArray());
        }

        public string ObterNome()
        {
            var nomeOriginal = DataTable.Rows[1][2].ToString().Trim();
            var prefixo = "Nome";
            return nomeOriginal.Substring(prefixo.Length).Trim();
        }

        public string ObterCpf()
        {
            var cpf = DataTable.Rows[2][2].ToString();
            var textoLimpo = cpf!.Trim();

            return new string(textoLimpo.Where(char.IsDigit).ToArray());
        }

        public string ObterCargo()
        {
            var cargoOriginal = DataTable.Rows[3][2].ToString().Trim();
            var prefixo = "Cargo";

            return cargoOriginal.Substring(prefixo.Length).Trim();
        }
    }
}