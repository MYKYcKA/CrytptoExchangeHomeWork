namespace Common.Services.FileDataParser;

public interface IFileDataParser
{
    public List<OrderBookDto> GetDataFromFile(string fileName);
}