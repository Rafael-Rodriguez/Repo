using System.Collections.Generic;

namespace AddTwoNumbers
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1Value = GenerateIntFromListNode(l1);
            var l2Value = GenerateIntFromListNode(l2);

            return GenerateListNodeFromInt(l1Value + l2Value);
        }

        private int GenerateIntFromListNode(ListNode listNode)
        {
            int result = 0;
            int power = 1;

            while (listNode != null)
            {
                result += listNode.val * power;
                power *= 10;
                listNode = listNode.next;
            }

            return result;
        }

        private ListNode GenerateListNodeFromInt(int value)
        {
            var listOfInts = new List<int>();
            if (value == 0)
            {
                listOfInts.Add(value);
            }
            else
            {
                while (value > 0)
                {
                    listOfInts.Add(value % 10);
                    value = value / 10;
                }
            }

            ListNode head = null;
            ListNode previousNode = null;

            foreach (var i in listOfInts)
            {
                if (head == null)
                {
                    head = new ListNode(i);
                    previousNode = head;
                }
                else
                {
                    var currentNode = new ListNode(i);
                    previousNode.next = currentNode;
                    previousNode = currentNode;
                }
            }

            return head;
        }
    }
}
