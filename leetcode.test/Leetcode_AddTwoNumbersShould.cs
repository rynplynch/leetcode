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
        public void AddTwoNumbers_ListNode1ListNode1_ReturnsListNode2()
        {
            //Given
            ListNode l1 = CreateListNodeList(1);
            ListNode l2 = CreateListNodeList(1);

            //When
            ListNode mockResult = Solution.AddTwoNumbers(l1, l2);

            //Then
            Assert.Equal(CreateListNodeList(2), mockResult);
        }

        [Fact]
        public void AddTwoNumbers_ListNodes9WithLargeInteger_ReturnsListNodeLargerThanMaxInt()
        {
            //Given
            ListNode l1 = CreateListNodeList(9);
            ListNode l2 = CreateListNodeList(1999999999);

            //When
            ListNode mockResult = Solution.AddTwoNumbers(l1,l2);

            //Then
            // because the return int is larger than
            Assert.Equal(CreateListNodeList(1), mockResult);
        }

        [Fact]
        public void AddTwoNumbers_ListNodeHalfMaxListNodeHalfMax_ReturnsListNodeMaxInt()
        {
            //Given
            double halfMax = int.MaxValue * 0.5;

            double roundedDown = Math.Round(halfMax) - 1;
            double roundedUp = Math.Round(halfMax);

            ListNode l1 = CreateListNodeList((int)roundedDown);
            ListNode l2 = CreateListNodeList((int)roundedUp);

            //When
            ListNode mockResult = Solution.AddTwoNumbers(l1, l2);

            //Then
            Assert.Equal(CreateListNodeList(int.MaxValue), mockResult);
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
            ulong toEncode = 9;

            //When
            ListNode mockResult = Solution.EncodeULongIntoListNodeList(toEncode);

            ListNode expected = new(9, null);

            //Then
            Assert.Equal(expected, mockResult);
        }

        [Fact]
        public void EncodeULongIntoListNodeList_3789_ReturnsListNodesInOrder9873()
        {
            //Given
            ulong toEncode = 3789;

            //When
            ListNode mockResult = Solution.EncodeULongIntoListNodeList(toEncode);

            ListNode expected = new(9, null);
            expected.next = new ListNode(8, null);
            expected.next.next = new ListNode(7, null);
            expected.next.next.next = new ListNode(3, null);

            //Then
            Assert.Equal(expected, mockResult);
        }

        [Fact]
        public void EncodeULongIntoListNodeList_10000000000_ReturnsListNode00000000001()
        {
        //Given
            ulong toEncode = 10000000000;

        //When
            ListNode mockResult = Solution.EncodeULongIntoListNodeList(toEncode);

        //Then
            int i = 0;
            ListNode entry = new (0, null);
            ListNode expected = entry;
            while (i < 9)
            {
                expected.next = new(0,null);
                expected = expected.next;
                i++;
            }
            expected.next = new(1,null);
            Assert.Equal(entry, mockResult);
        }

        [Fact]
        public void ParseListNodes_EmptyListNode_Returns0()
        {
            //Given
            ListNode toParse = CreateEmptyListNode();

            //When
            ulong mockResult = Solution.ParseListNodes(toParse);

            //Then
            Assert.Equal((ulong)0, mockResult);
        }

        [Fact]
        public void ParseListNodes_ListNode9_Returns9()
        {
            //Given
            ListNode toParse = new(9, null);

            //When
            ulong mockResult = Solution.ParseListNodes(toParse);

            //Then
            Assert.Equal((ulong)9, mockResult);
        }

        [Fact]
        public void ParseListNodes_ListNode01_Returns10()
        {
            //Given
            ListNode toParse = CreateListNodeList(10);

            //When
            ulong mockResult = Solution.ParseListNodes(toParse);

            //Then
            Assert.Equal((ulong)10, mockResult);
        }

        [Fact]
        public void ParseListNodes_ListNodeMaxULong_ReturnsMaxULong()
        {
            //Given
            ListNode toParse = CreateListNodeList(ulong.MaxValue);

            //When
            ulong mockResult = Solution.ParseListNodes(toParse);

            //Then
            Assert.Equal(ulong.MaxValue, mockResult);
        }

        private static ListNode CreateEmptyListNode()
        {
            return new ListNode(0, null);
        }

        private static ListNode CreateListNodeList(ulong toEncode)
        {
            return Solution.EncodeULongIntoListNodeList(toEncode);
        }
    }
}
