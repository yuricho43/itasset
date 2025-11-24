using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace AssetManagement.Common
{
    public class ExcelLoader
    {
        public static Workbook LoadExcelFile(string filePath)
        {
            // 1. 파일 포맷 제공자 생성
            XlsxFormatProvider formatProvider = new XlsxFormatProvider();

            // 2. 파일을 읽어 Workbook으로 변환
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return formatProvider.Import(stream);
            }
        }
    }
}
