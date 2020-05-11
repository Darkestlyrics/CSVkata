using System.Collections.Generic;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata.Classes
{
    public class CsvWriter : ICSVWriter
    {
        private readonly IFileSystem _fileSystem;

        public CsvWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void WriteFile(string filename, IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                _fileSystem.WriteLine(filename,customer.ToString());
            }
        }
    }
}