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

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public class Solution
    {
        // in this version I can not store the value of operands
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // save the entry point of our solution
            ListNode? entry = null;

            // the pointer we alter in our loop
            ListNode current = new(0, null);

            // flag used to indicate a value needs to be carried
            bool carryFlag = false;

            // while either l1, or l2 have nodes to traverse
            // OR there is a carry digit to handle
            while (l1 != null || l2 != null || carryFlag)
            {
                // if this is the first loop
                if (entry == null)
                {
                    // record the entry point
                    entry = current;
                }
                else
                {
                // make a new node to record the digit at this depth
                current.next = new(0, null);
                current = current.next;
                }

                // the sum at the current node depth
                int sum = 0;

                // make sure l1 is not null
                if (l1 != null)
                {
                    // add the nodes value
                    sum += l1.val;
                    // move to the current node
                    l1 = l1.next;
                }

                // make sure l2 is not null
                if (l2 != null)
                {
                    // add the nodes value
                    sum += l2.val;
                    // move to the current node
                    l2 = l2.next;
                }

                // if there is a carry digit
                if (carryFlag)
                {
                    // add one
                    sum++;

                    // reset carry flag
                    carryFlag = false;
                }

                // if the sum is greater than 10, we must carry a value
                if (sum >= 10)
                {
                    // raise the carry flag
                    carryFlag = true;

                    // solve for the remainder
                    int remainder = sum % 10;

                    // record the remainder
                    current.val = remainder;
                } else
                    // otherwise there is no value to carry
                    current.val = sum;
            }

            return entry;
        }

        // given an integer, encode it into a linked list of ListNode's
        // the integer will never be negative
        public static ListNode EncodeULongIntoListNodeList(ulong val)
        {
            // Entry point of the returned linked list
            ListNode entry = new();

            // if given 0
            if (val == 0)
                // return a single Node list with val = 0
                return entry;

            // we change this reference in the loop
            ListNode current = entry;

            // while the input does not equal 0
            while ( val != 0)
            {
                // solve for the 1's place digit
                ulong remainder = val % 10;

                // this remainder is put into the linked list
                current.val = (int) remainder;


                // we've record this number, remove it from the whole
                val -= remainder;

                // remove the tailing 0
                val /= 10;

                // if we are going to loop again
                if ( val != 0 )
                {
                    // create a new ListNode
                    current.next = new();
                    // make the current node the next node
                    current = current.next;
                }
            }

            return entry;
        }

        // parse a collection of ListNode's, returning an integer value
        public static ulong ParseListNodes(ListNode? ln)
        {
            // track the value
            ulong sum = 0;

            // track node depth, used to determine weight of digit
            int i = 0;

            // while our ListNode is not null
            while (ln != null)
            {
                // solve for the integer to add to the sum
                // use i to make sure the digits weight is represented
                sum += (ulong) ( ln.val * Math.Pow(10,i) );

                // next digit will inhabit next 10's place
                i++;

                // move to the next node
                ln = ln.next;
            }
            return sum;
        }
    }
}
