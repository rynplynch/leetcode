namespace Leetcode.AddTwoNumbers
{
    //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode(int val=0, ListNode? next=null) {
            this.val = val;
            this.next = next;
        }
        // override object.Equals
        // we are really testing for equality among all the linked ListNodes here
        public override bool Equals(object? obj)
        {
            // if the object we are comparing is null or a different type
            if (obj == null || GetType() != obj.GetType())
                // return false
                return false;
            else
            {
            // we know the object is the same type, cast it
            ListNode? other = obj as ListNode;

            // if the values are equal
            if (val.Equals(other?.val))
            {
                // if both the of the nodes point to another node
                if ( next != null && other.next != null )
                    // we have to test those nodes for equality
                    return next.Equals(other.next);
                // the two list do not have another node, they are equal
                return next == null && other.next == null;
            // the values are not equal
            } else
                //return false
                return false;
            }
        }
    }

    public class Solution
    {
        public static ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            ListNode answer = new();
            return answer;
        }

        // given an integer, encode it into a linked list of ListNode's
        // the integer will never be negative
        public static ListNode EncodeIntIntoListNodeList(int val)
        {
            // Entry point of the returned linked list
            ListNode entry = new();

            // if given 0
            if (val == 0)
                // return a single Node list with val = 0
                return entry;

            // while the input does not equal 0
            while ( val != 0)
            {
                // solve for the 1's place digit
                int remainder = val % 10;

                // this remainder is put into the linked list
                entry.val = remainder;

                // we've record this number, remove it from the whole
                val -= remainder;

                // remove the tailing 0
                val /= 10;
            }

            return entry;
        }
    }
}
