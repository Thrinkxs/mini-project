using NUnit.Framework;
using CSVProcessor;
using System.Collections.Generic;

namespace CSVProcessorTests
{
    public class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [Test]
        public void GetFrequencyTest()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe" },
                new Person { FirstName = "Jane", LastName = "Doe" },
                new Person { FirstName = "John", LastName = "Smith" }
            };

            // Act
            var frequency = _program.GetFrequency(people, p => p.FirstName);

            // Assert
            Assert.AreEqual(2, frequency["John"]);
            Assert.AreEqual(1, frequency["Jane"]);
        }
    }
}