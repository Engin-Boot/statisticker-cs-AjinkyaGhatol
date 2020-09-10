using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
namespace Statistics.Test
{
    public class StatsUnitTest
    {
        private readonly ITestOutputHelper _output;

        public StatsUnitTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        [Fact]
        public void ReportsAverageMinMaxOfFloat()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<float> { 1.5f, 8.9f, 3.2f, 4.5f });
            float epsilon = 0.001F;
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.average, statsComputer.max, statsComputer.min);
            Assert.True(Math.Abs(statsComputer.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(statsComputer.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(statsComputer.min - 1.5) <= epsilon);
        }
        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<float>{});
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1
            
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.average, statsComputer.max, statsComputer.min);
            Assert.True(Double.IsNaN(statsComputer.average));
            Assert.True(Double.IsNaN(statsComputer.max));
            Assert.True(Double.IsNaN(statsComputer.min));
        }
        [Fact]
        public void ReportsAverageMinMaxOfDoube()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<Double> { 1.5, 8.9, 3.2, 4.5 });
            float epsilon = 0.001F;
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.average, statsComputer.max, statsComputer.min);
            Assert.True(Math.Abs(statsComputer.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(statsComputer.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(statsComputer.min - 1.5) <= epsilon);
        }
        [Fact]
        public void ReportsAverageMinMaxOfInt1()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<int> { 1, 8, 3, 4 });
            float epsilon = 0.001F;
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.average, statsComputer.max, statsComputer.min);
            Assert.True(Math.Abs(statsComputer.average - 4) <= epsilon);
            Assert.True(statsComputer.max==8);
            Assert.True(statsComputer.min==1);
        }
        [Fact]
        public void ReportsAverageMinMaxOfInt2()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<int> { 1, 9, 3, 4 });
            float epsilon = 0.001F;
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.average, statsComputer.max, statsComputer.min);
            Assert.True(Math.Abs(statsComputer.average - 4.25) <= epsilon);
            Assert.True(statsComputer.max == 9);
            Assert.True(statsComputer.min == 1);
        }
    }
}
//to do store min and max in T datatype
//cant do because can not convert Double to T and no generic nan found