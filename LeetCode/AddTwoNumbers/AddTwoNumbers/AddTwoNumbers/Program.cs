using System;
using System.Collections.Generic;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteTests();
            Console.ReadLine();
        }

        static void ExecuteTests()
        {
            ExecuteTest(342, 465);
            ExecuteTest(342, 0);
            ExecuteTest(0, 465);
            ExecuteTest(0, 0);
            ExecuteTest(0, 10000);
            ExecuteTest(5000, 5000);
            ExecuteTest(50000, 5);
            ExecuteTest(int.MaxValue, 0);
            ExecuteTest(int.MaxValue - 1, 1);
        }

        static void ExecuteTest(int num1, int num2)
        {
            var listNodeBuilder = new ListNodeBuilder();
            var l1 = listNodeBuilder.GenerateListNodeFromInt(num1);
            var l2 = listNodeBuilder.GenerateListNodeFromInt(num2);
            
            PrintListNode(l1);
            PrintListNode(l2);

            var s1 = new Solution();
            var result = s1.AddTwoNumbers(l1, l2);
            PrintResult(result, num1, num2);
        }

        static void PrintListNode(ListNode listNode)
        {
            while(listNode != null)
            {
                Console.Write(listNode.val + (listNode.next != null ? "->" : ""));
                listNode = listNode.next;
            }
            Console.WriteLine();
        }

        static void PrintResult(ListNode result, int num1, int num2)
        {
            var expectedResult = num1 + num2;
            var listNodeToIntConverter = new ListNodeToIntConverter();
            var valueOfResult = listNodeToIntConverter.GenerateIntFromListNode(result);

            Console.WriteLine($"{valueOfResult} == {expectedResult} = {valueOfResult == expectedResult}");
            Console.WriteLine(); Console.WriteLine();
        }

    }
}
