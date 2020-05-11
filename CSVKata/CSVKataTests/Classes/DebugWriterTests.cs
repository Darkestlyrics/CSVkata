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
    public class DebugWriterTests
    {
        private ICSVWriter _subCsvWriter;
        private IBatchCSVWriter debugBatchCsvWriter;
        private IBatchCSVWriter legitBatchCsvWriter;


        [SetUp]
        public void SetUp()
        {
            this._subCsvWriter = Substitute.For<ICSVWriter>();
            this.legitBatchCsvWriter = Substitute.For<BatchCSVWriter>(_subCsvWriter, new RemoveDuplicates());
            this.debugBatchCsvWriter = Substitute.For<BatchCSVWriter>(_subCsvWriter, new LeaveDuplicates());

        }

        private DebugWriter CreateDebugWriter()
        {

            return new DebugWriter(
                this.debugBatchCsvWriter,
                this.legitBatchCsvWriter);
        }

        [Test]
        public void WriteFiles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugWriter = this.CreateDebugWriter();
            TestDataFactory testDataDataFactory= new TestDataFactory();
            IEnumerable<Customer> customers = testDataDataFactory.GenerateCustomers(1000000);

            // Act
            debugWriter.WriteFiles(
                customers);

            // Assert
           
        }
    }
}
