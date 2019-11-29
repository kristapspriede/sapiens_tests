using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SapiensCsharp;
using Xunit;
using Object = SapiensCsharp.Object;

namespace SapiensTest.Test
{
    public class SapiensTest
    {
        [Fact]
        public void SafeDivision_ShouldDivide()
        {
            var obj = new Object();
            var expected = 2;

            var actual = obj.SafeDivision(4, 2);

            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void Multiplication_ShouldMultiply()
        {
            var obj = new Object();
            var expected = 8;

            var actual = obj.Multiplication(4, 2);

            Assert.Equal(expected, actual);

        }
        [Fact]
        public void SafeDivision_ShouldThrowException()
        {
            var testObject = new Object();

            Action act = () => testObject.divided = testObject.SafeDivision(5, 0);

            var exception = Assert.Throws<DivideByZeroException>(act);

            Assert.Equal("Attempted to divide by zero.", exception.Message);

        }

        [Fact]
        public void IsValidPath_ShouldBeValidPath()
        {
            var inputPath = @"C:/Users/krist/OneDrive/Desktop/Sapiens tests/C#/input.xml";
            var inputPath2 = @"C:/Users/krist/OneDrive/Desktop/Sapiens tests/C#/text.txt";

            Assert.True(SapiensCsharp.Program.IsValidPath(inputPath));
            Assert.True(SapiensCsharp.Program.IsValidPath(inputPath2));
        }

        [Fact]
        public void IsValidPath_ShouldNotBeValidPath()
        {
            var inputPath = @"input.xml";
            var inputPath2 = @"text.txt";

            Assert.False(SapiensCsharp.Program.IsValidPath(inputPath));
            Assert.False(SapiensCsharp.Program.IsValidPath(inputPath2));
        }


    }
}
