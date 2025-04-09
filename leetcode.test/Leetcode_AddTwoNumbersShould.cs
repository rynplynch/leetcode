using Leetcode.AddTwoNumbers;

namespace Leetcode.Test
{
    public class Leetcode_AddTwoNumbersShould
    {
        [Fact]
        public void AddTwoNumbers_EmptyListNodes_ReturnsEmptyListNode()
        {
            //Given
            Solution solution = new();

            ListNode l1 = CreateEmptyListNode();
            ListNode l2 = CreateEmptyListNode();

            //When
            ListNode mockResult = solution.AddTwoNumbers(l1, l2);

            //Then
            Assert.Equal(0, mockResult.val);
        }

        private static ListNode CreateEmptyListNode()
        {
            return new ListNode(0, null);
        }
    }
}
