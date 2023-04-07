using static Laplace.Models.CsvData;
using System.Globalization;

namespace Laplace;
public static class Code
{
    static readonly CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
    public static List<EodValues> ParseCsvValues(string Path)
    {

        // Read all lines from the csv file
        string[] lines = File.ReadAllLines(Path);

        // Split the first line by comma separator to get column names
        string[] columns = lines[0].Replace("\"", "").Split(',');

        // Create a list of objects to store the data
        List<EodValues> data = new List<EodValues>();

        // Loop through the remaining lines and create an object for each row
        for (int i = 1; i < lines.Length; i++)
        {
            // Split the line by comma separator and store the values as an array of string
            string[] values = lines[i].Replace("\",", ";").Replace("\"", "").Replace(",", ".").Split(";");

            EodValues wData = new();

            if (DateTime.TryParse(values[0], out DateTime Data)) wData.Data = Data;
            if (double.TryParse(values[1], NumberStyles.AllowDecimalPoint, culture, out double Ultimo)) wData.Ultimo = Ultimo;
            if (double.TryParse(values[2], NumberStyles.AllowDecimalPoint, culture, out double Abertura)) wData.Abertura = Abertura;
            if (double.TryParse(values[3], NumberStyles.AllowDecimalPoint, culture, out double Alta)) wData.Alta = Alta;
            if (double.TryParse(values[4], NumberStyles.AllowDecimalPoint, culture, out double Baixa)) wData.Baixa = Baixa;
            if (double.TryParse(values[5], NumberStyles.AllowDecimalPoint, culture, out double Vol)) wData.Vol = Vol;
            if (double.TryParse(values[6], NumberStyles.AllowDecimalPoint, culture, out double Var)) wData.Var = Var;

            // Add the row to the list of objects
            data.Add(wData);
        }
        return data;
    }
}