using CSVKata.Classes;
using CsvFile.Kata.Dependencies;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute.ReceivedExtensions;

namespace CSVKataTests.Classes
{
    [TestFixture]
    public class CsvWriterTests
    {
        private IFileSystem _subFileSystem;

        [SetUp]
        public void SetUp()
        {
            this._subFileSystem = Substitute.For<IFileSystem>();
        }

        private CsvWriter CreateCsvWriter()
        {
            return new CsvWriter(
                this._subFileSystem);
        }

        [Test]
        public void WriteFile_1000Customers_NoDuplicates()
        {
            // Arrange
            var csvWriter = this.CreateCsvWriter();
            string filename = "test";
            TestDataFactory testDataFactory = new TestDataFactory();
            IEnumerable<Customer> customers = testDataFactory.GenerateCustomers(1000);

            // Act
            csvWriter.WriteFile(
                filename,
                customers);

            // Assert
            _subFileSystem.Received(1000).WriteLine(filename, Arg.Any<string>());
        }

    }
}
