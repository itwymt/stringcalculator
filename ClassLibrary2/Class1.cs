using System;
using Xunit;
using FluentAssertions;

namespace ClassLibrary2
{
    public class TestStringCalculator
    {
        [Fact]
        public void should_return_0_for_empty_string()
        {
            //aggreggate
            //var calculator = new StringCalculator();

            //act 
            var result = StringCalculator.Add("");

            //assert
            result.Should().Be(0);
        }

        [Fact]
        public void should_return_result_for_one_number()
        {
            //aggreggate 
            //var calculator = new StringCalculator();

            //act 
            var result = StringCalculator.Add("1");

            //assert
            result.Should().Be(1);
        }

        [Fact]
        public void should_handle_miltiple_numbers()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            var result = StringCalculator.Add("1,2,3");

            //assert
            result.Should().Be(6);
        }

        [Fact]
        public void should_handle_new_line_delimiter()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            var result = StringCalculator.Add("1\n2,3,4");

            //assert
            result.Should().Be(10);
        }

        [Fact]
        public void should_handle_specified_delimiter()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            var result = StringCalculator.Add("//##\n1,2,3##10##12");

            //assert
            result.Should().Be(28);
        }

        [Fact]
        public void should_report_error_for_neagtives()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            Action action = () => StringCalculator.Add("//@@\n-1@@3@@-3@@-4,7");

            //assert
            action.ShouldThrow<Exception>().WithMessage("Negatives are not allowed. Negative values: -1, -3, -4");
        }

        [Fact]
        public void souldnot_support_numbers_bigger_then_1000()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            var result = StringCalculator.Add("//qq\n1002,2000,3qq2");

            //assert
            result.Should().Be(5);
        }

        [Fact]
        public void should_support_multiple_delimiters()
        {
            //assign
            //var calculator = new StringCalculator();

            //act
            var result = StringCalculator.Add("//[%][$$][^^D]\n1$$5^^D4,1,1002,3%1");

            //assert
            result.Should().Be(15);
        }
    }
}
