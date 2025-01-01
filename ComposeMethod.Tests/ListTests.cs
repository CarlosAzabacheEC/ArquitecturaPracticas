using System;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace RefactoringToPatterns.ComposeMethod.Tests
{
    public class ListShould
    {
        [Fact]
        public void NotAddElementWhenIsReadOnly()
        {
            var list = new Lista(true);
            
            list.Add(1);
            
            Object[] expectedElements = { };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void AddElement()
        {
            var list = new Lista(false);
            
            list.Add(1);
            
            Object[] expectedElements = { 1, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void GrowListIfElementsExceedSize()
        {
            var list = new Lista(false);

            foreach (int value in Enumerable.Range(1, 11))
            {
                list.Add(value);
            }

            Object[] expectedElements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
    }
}