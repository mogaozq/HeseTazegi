using HeseTazegi.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HeseTazegi.Application.UnitTests.Utilities
{
    public class SetUtilityTests
    {
        [Fact]
        public void CreateSubsets_ReturnsSubsetsWithMinSize()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4 };
            int minSize = 2;

            // Act
            var subsets = SetUtility.CreateSubsets(items, minSize);

            // Assert
            Assert.Equal(11, subsets.Count);
            Assert.Contains(new List<int> { 1, 2 }, subsets);
            Assert.Contains(new List<int> { 1, 3 }, subsets);
            Assert.Contains(new List<int> { 2, 3 }, subsets);
            Assert.Contains(new List<int> { 1, 4 }, subsets);
            Assert.Contains(new List<int> { 2, 4 }, subsets);
            Assert.Contains(new List<int> { 3, 4 }, subsets);
            Assert.Contains(new List<int> { 1, 2, 3 }, subsets);
            Assert.Contains(new List<int> { 1, 2, 4 }, subsets);
            Assert.Contains(new List<int> { 1, 3, 4 }, subsets);
            Assert.Contains(new List<int> { 2, 3, 4 }, subsets);
            Assert.Contains(new List<int> { 1, 2, 3, 4 }, subsets);
        }

        [Fact]
        public void CreateSubsets_ReturnsCorrectSubsets()
        {
            // Arrange
            var input = new List<int> { 1, 2, 3 };
            var expectedOutput = new List<List<int>>
            {
                new List<int>(),
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 1, 2 },
                new List<int> { 3 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            // Act
            var actualOutput = SetUtility.CreateSubsets(input);

            // Assert
            Assert.Equal(expectedOutput.Count, actualOutput.Count);
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                Assert.Equal(expectedOutput[i], actualOutput[i]);
            }
        }
    }
}
