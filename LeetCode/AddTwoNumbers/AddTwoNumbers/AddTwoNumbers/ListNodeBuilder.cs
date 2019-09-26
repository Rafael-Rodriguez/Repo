using System.Collections.Generic;

namespace AddTwoNumbers
{
    class ListNodeBuilder
    {
        public ListNode GenerateListNodeFromInt(int value)
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
