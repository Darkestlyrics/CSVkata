using System;
using System.Collections.Generic;
using System.Linq;
using CsvFile.Kata.Dependencies;

namespace CSVKataTests
{
    public class TestDataFactory
    {

        private static Random random = new Random();
        public List<Customer> GenerateCustomers(int num)
        {
            List<Customer> res = new List<Customer>();

            while (res.Count < num)
            {
                Customer temp = new Customer()
                {
                    ContactNumber = generateContactNumber(),
                    Name = generateName()
                };
                res.Add(temp);
            }

            return res;
        }

        private string generateContactNumber()
        {

            return random.Next(999999999).ToString().PadLeft(9, Convert.ToChar(random.Next(9)));
        }

        private string generateName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 13)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}