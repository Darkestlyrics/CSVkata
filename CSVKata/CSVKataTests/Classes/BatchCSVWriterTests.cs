using CSVKata.Classes;
using CSVKata.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using CsvFile.Kata.Dependencies;

namespace CSVKataTests.Classes
{
    [TestFixture]
    public class BatchCSVWriterTests
    {
        private ICSVWriter _subCsvWriter;

        [SetUp]
        public void SetUp()
        {
            this._subCsvWriter = Substitute.For<ICSVWriter>();

        }

        private BatchCSVWriter CreateBatchCSVWriter(IDuplicateOptions duplicateOptions)
        {
            return new BatchCSVWriter(
                this._subCsvWriter,
                duplicateOptions);
        }

        [Test]
        public void WriteFile_150000Customers_150000BatchSize_DuplicatesLeft()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new LeaveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(150000);
            int batchSize = 150000;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            _subCsvWriter.Received(1).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }

        [Test]
        public void WriteFile_100Customers_10BatchSize_DuplicatesLeft()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new LeaveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(1000);
            int batchSize = 10;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            _subCsvWriter.Received(100).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }

        [Test]
        public void WriteFile_150000Customers_1500BatchSize_DuplicateLeft()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new LeaveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(150000);
            int batchSize = 1500;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            _subCsvWriter.Received(100).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }


        [Test]
        public void WriteFile_150000Customers_150000BatchSize_DuplicatesRemoved()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new RemoveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(150000);
            int batchSize = 150000;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            _subCsvWriter.Received(1).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }

        [Test]
        public void WriteFile_100Customers_10BatchSize_DuplicatesRemoved()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new RemoveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(1000);
            int batchSize = 10;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            _subCsvWriter.Received(100).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }

        [Test]
        public void WriteFile_150000Customers_1500BatchSize_DuplicatesRemoved()
        {
            // Arrange
            var batchCSVWriter = this.CreateBatchCSVWriter(new RemoveDuplicates());
            string filename = "BatchTest";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(150000);
            int batchSize = 1500;

            // Act
            batchCSVWriter.WriteFile(
                filename,
                customers,
                batchSize);

            // Assert
            //_subCsvWriter.Received(100).WriteFile(Arg.Any<string>(), Arg.Any<List<Customer>>());
        }
    }
}
