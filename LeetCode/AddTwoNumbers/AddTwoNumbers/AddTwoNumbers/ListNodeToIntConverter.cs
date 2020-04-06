namespace AddTwoNumbers
{
    class ListNodeToIntConverter
    {
        public int GenerateIntFromListNode(ListNode listNode)
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
    }
}
