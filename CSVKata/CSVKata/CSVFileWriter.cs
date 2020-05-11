using System;
using System.Collections.Generic;
using System.Linq;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata
{
    public class CSVFileWriter : ICSVWriter
    {

        private readonly IFileSystem _fileSystem;

        public CSVFileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }


        public void WriteFile(string filename, IEnumerable<Customer> customers)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename cannot be empty");
            if (customers.Count() == 0)
                throw new ArgumentException("Customers cannot be empty");

            foreach (var customer in customers)
            {
                _fileSystem.WriteLine(filename, customer.ToString());
            }

        }
    }
}

