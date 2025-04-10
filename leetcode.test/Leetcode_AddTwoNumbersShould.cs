using Leetcode.AddTwoNumbers;

namespace Leetcode.Test
{
    public class Leetcode_AddTwoNumbersShould
    {
        [Fact]
        public void AddTwoNumbers_EmptyListNodes_ReturnsEmptyListNode()
        {
            //Given
            ListNode l1 = CreateEmptyListNode();
            ListNode l2 = CreateEmptyListNode();

            //When
            ListNode mockResult = Solution.AddTwoNumbers(l1, l2);

            //Then
            Assert.Equal(CreateEmptyListNode(), mockResult);
        }

        [Fact]
        public void EncodeIntIntoListNodeList_0_ReturnsListNodeWith0()
        {
            //Given
            int toEncode = 0;

            //When
            ListNode mockResult = Solution.EncodeIntIntoListNodeList(toEncode);

            //Then
            Assert.Equal(CreateEmptyListNode(), mockResult);
        }

        [Fact]
        public void EncodeIntIntoListNodeList_9_ReturnsListNodeWith9()
        {
            //Given
            int toEncode = 9;

            //When
            ListNode mockResult = Solution.EncodeIntIntoListNodeList(toEncode);

            ListNode expected = new(9, null);

            //Then
            Assert.Equal(expected, mockResult);
        }

        [Fact]
        public void EncodeIntIntoListNodeList_3789_ReturnsListNodesInOrder9873()
        {
            //Given
            int toEncode = 3789;

            //When
            ListNode mockResult = Solution.EncodeIntIntoListNodeList(toEncode);

            ListNode expected = new(9, null);
            expected.next = new ListNode(8, null);
            expected.next.next = new ListNode(7, null);
            expected.next.next.next = new ListNode(3, null);

            //Then
            Assert.Equal(expected, mockResult);
        }

        private static ListNode CreateEmptyListNode()
        {
            return new ListNode(0, null);
        }
    }
}
