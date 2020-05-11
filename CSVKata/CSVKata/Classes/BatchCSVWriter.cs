using System.Collections.Generic;
using System.Linq;
using CsvFile.Kata.Dependencies;
using CSVKata.Interfaces;

namespace CSVKata.Classes
{
    public class BatchCSVWriter: IBatchCSVWriter
    {
        private readonly ICSVWriter _csvWriter;
        private readonly IDuplicateOptions _duplicateOptions;

        public BatchCSVWriter(ICSVWriter csvWriter, IDuplicateOptions duplicateOptions)
        {
            _csvWriter = csvWriter;
            _duplicateOptions = duplicateOptions;
        }


        private IEnumerable<IEnumerable<Customer>> SplitBatches(IEnumerable<Customer> customers, int batchSize)
        {
            return customers
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / batchSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

        }

        public void WriteFile(string filename, IEnumerable<Customer> customers, int batchSize)
        {
            var temp = _duplicateOptions.Apply(customers);
            var batched = SplitBatches(temp,batchSize);
            int fileNo = 1;
            foreach (var list in batched)
            {
                _csvWriter.WriteFile(filename + fileNo,list);
                fileNo++;
            }
        }
    }
}