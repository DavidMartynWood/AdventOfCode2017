using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Day1.Tests
{
    [TestFixture]
    public class SpiralMemoryTests
    {
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(10, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        [TestCase(289326, 419)]
        public void Execute_Always_ReturnsCorrectResult(int input, int expectedResult)
        {
            var sut = new SpiralMemory();
            var result = sut.Evaluate(input);
            result.ShouldBe(expectedResult);
        }
    }
}
