using System.Collections.Generic;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata.Classes
{
    public class LeaveDuplicates : IDuplicateOptions
    {
        public IEnumerable<Customer> Apply(IEnumerable<Customer> customers)
        {
            return customers;
        }
    }
}