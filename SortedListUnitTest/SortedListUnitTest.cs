using SortedList;
using Xunit;
using System.Linq;

namespace SortedListUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertFirst_Test()
        {
            // Arrange
            var singleLinkedList = new SortedList.SingleLinkedList();
            singleLinkedList.InsertLast(1);
            singleLinkedList.InsertLast(2);
            singleLinkedList.InsertLast(3);
            singleLinkedList.InsertLast(4);
            int expectedFirst = 10;

            // Act
            singleLinkedList.InsertFirst(expectedFirst);

            // Assert
            Assert.Equal(expectedFirst, singleLinkedList.head.data);
        }
        [Fact]
        public void Sort_Test()
        {
            // Arrange
            // The first list
            var firstSingleLinkedList = new SortedList.SingleLinkedList();
            firstSingleLinkedList.InsertLast(1);
            firstSingleLinkedList.InsertLast(2);
            firstSingleLinkedList.InsertLast(5);

            // The second list
            var secondSingleLinkedList = new SortedList.SingleLinkedList();
            secondSingleLinkedList.InsertLast(2);
            secondSingleLinkedList.InsertLast(3);
            secondSingleLinkedList.InsertLast(7);
            // Act
            string expectedResult = "{1 -> 2 -> 2 -> 3 -> 5 -> 7}";
            var result = SortedList.SortedList.SortedJoin(firstSingleLinkedList,secondSingleLinkedList);

            // Assert
            Assert.Equal(expectedResult, result.ToString());
        }
    }
}
