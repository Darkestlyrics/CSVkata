using System.Collections.Generic;
using System.Linq;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata.Classes
{
    public class RemoveDuplicates :IDuplicateOptions
    {
        public IEnumerable<Customer> Apply(IEnumerable<Customer> customers)
        {
            return customers.Distinct(new DistinctCustomerComparer());
        }
    }
    class DistinctCustomerComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return
                x.Name == y.Name;
        }

        public int GetHashCode(Customer obj)
        {
            return obj.Name.GetHashCode();

        }
    }
}