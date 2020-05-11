using System.Collections;
using System.Collections.Generic;
using CsvFile.Kata.Dependencies;

namespace CSVKata.Interfaces
{
    public interface ICSVWriter
    {
        void WriteFile(string filename, IEnumerable<Customer> customers);
    }
}