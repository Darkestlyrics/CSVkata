using System.Collections.Generic;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata.Classes
{
    public class DebugWriter //pretending I had 15 minutes
    {
        private readonly IBatchCSVWriter _batchCsvWriter;
        private readonly IBatchCSVWriter _debug;

        public DebugWriter(IBatchCSVWriter debug, IBatchCSVWriter batchCsvWriter)
        {
            _debug = debug;
            _batchCsvWriter = batchCsvWriter;
        }

        public void  WriteFiles(IEnumerable<Customer> customers)
        {
            _batchCsvWriter.WriteFile("Customers",customers,15000);
            _debug.WriteFile("debug",customers,20);
        }

    }
}