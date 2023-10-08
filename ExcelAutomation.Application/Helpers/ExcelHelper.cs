using ExcelDataReader;
using System.Data;
using System.Text;

namespace ExcelAutomation.UseCases.Helpers
{
    public static class ExcelHelper
    {
        public static DataSet ReadExcelFile(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var configs = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = false
                }
            };

            return reader.AsDataSet(configs);
        }
    }
}
