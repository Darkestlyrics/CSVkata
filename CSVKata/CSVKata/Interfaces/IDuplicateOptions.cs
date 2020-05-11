using System.Collections.Generic;
using CsvFile.Kata.Dependencies;

namespace CSVKata.Interfaces
{
    public interface IDuplicateOptions
    {
        IEnumerable<Customer> Apply(IEnumerable<Customer> customers);
    }
}