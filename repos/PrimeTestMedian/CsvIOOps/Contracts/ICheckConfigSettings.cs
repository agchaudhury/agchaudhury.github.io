namespace CsvOps.Contracts
{
    public interface ICheckConfigSettings
    {
        string strFilePath { get; set; }
        string strFileExt { get; set; }
        string strFilePreFix { get; set; }
        string strDelimiter { get; set; }
        bool CheckConfigSetting();
    }
}
