using System;

namespace CSVReaderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kindly enter the file name with path!");
            string path = Console.ReadLine();

            CsvApplicationSelector obj = new CsvApplicationSelector(new CsvTOUStrategy());
            obj.GetCsv(path);
        }
    }
}
