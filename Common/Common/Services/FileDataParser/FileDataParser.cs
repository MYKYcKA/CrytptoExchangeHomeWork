using System.Text.Json;

namespace Common.Services.FileDataParser;

public class FileDataParser : IFileDataParser
{
    public List<OrderBookDto> GetDataFromFile(string fileName)
    {
        var result = new List<OrderBookDto>();
        var lines = File.ReadAllLines(fileName);

        foreach (var line in lines)
        {
            var rawData = line.Split('\t')[1];
            var data = JsonSerializer.Deserialize<OrderBookDto>(rawData);
            if (data != null)
            {
                result.Add(data);
            }
        }

        return result;
    }
}