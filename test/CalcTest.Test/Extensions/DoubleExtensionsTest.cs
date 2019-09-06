using CalcTest.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalcTest.Test.Extensions
{
    public class DoubleExtensionsTest
    {
        [Fact]
        public void TruncateTest()
        {
            //arrange
            var value = 10.186;

            //act
            var truncated = value.Truncate();

            //assert
            Assert.Equal(10.18, truncated);
        }

        [Fact]
        public void Truncate2Test()
        {
            //arrange
            var value = 10.184;

            //act
            var truncated = value.Truncate();

            //assert
            Assert.Equal(10.18, truncated);
        }
    }
}
