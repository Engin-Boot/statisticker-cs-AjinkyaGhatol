using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
namespace Statistics.Test
{
    public class StatsUnitTest
    {
        #region Methods
        private readonly ITestOutputHelper _output;

        public StatsUnitTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        #endregion
        
        #region ReportsNaNForEmptyInput
        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                new List<float>{});
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1
            
            _output.WriteLine("Average:{0},Max:{1},Min:{2}", statsComputer.Average, statsComputer.Max, statsComputer.Min);
            Assert.True(Double.IsNaN(statsComputer.Average));
            Assert.True(Double.IsNaN(statsComputer.Max));
            Assert.True(Double.IsNaN(statsComputer.Min));
        }
        #endregion
        
        #region IntData
        public static IEnumerable<object[]> IntData =>
        new List<object[]>
        {
            new object[] { new List<int>{ 1, 8, 3, 4 }, 4, 8 ,1},
            new object[] { new List<int> { 1, 9, 3, 4 }, 4.25, 9 ,1 },
        };
        #endregion
        #region FLoatData
        public static IEnumerable<object[]> FloatData =>
        new List<object[]>
        {
            new object[] { new List<float>{ 1.5f, 8.9f, 3.2f, 4.5f }, 4.525, 8.9 ,1.5},
        };
        #endregion
        #region DoubleData
        public static IEnumerable<object[]> DoubleData =>
        new List<object[]>
        {
            new object[] { new List<Double>{ 1.5, 8.9, 3.2, 4.5 }, 4.525, 8.9 ,1.5},
        };
        #endregion
        [Theory]
        [MemberData(nameof(IntData))]
        [MemberData(nameof(FloatData))]
        [MemberData(nameof(DoubleData))]
        public void ReportsAverageMinMax<T>(List<T> numbers,Double average_real,Double max_real,Double min_real)
        {
            var statsComputer = new StatsComputer();
            statsComputer.CalculateStatistics(
                numbers);
            float epsilon = 0.001F;
            _output.WriteLine("Average:{0},Max:{1},Min:{2},{3}", statsComputer.Average, statsComputer.Max, statsComputer.Min,average_real);
            Assert.True(Math.Abs(statsComputer.Average - average_real) <= epsilon);
            Assert.True(Math.Abs(statsComputer.Max - max_real) <= epsilon);
            Assert.True(Math.Abs(statsComputer.Min - min_real) <= epsilon);
        }
        
    }
}
//to do store min and max in T datatype
//cant do because can not convert Double to T and no generic nan found