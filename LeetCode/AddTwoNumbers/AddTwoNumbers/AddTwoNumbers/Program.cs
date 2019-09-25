﻿using System;
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
            ExecuteTest1();
        }

        static void ExecuteTest1()
        {
            ListNode l1 = GenerateListNodeListFromNumber(342);
            ListNode l2 = GenerateListNodeListFromNumber(465);

            PrintListNode(l1);
            PrintListNode(l2);
        }

        static ListNode GenerateListNodeListFromNumber(int value)
        {
            List<int> listOfInts = new List<int>();
            if(value == 0)
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
            ListNode currentNode = null;

            foreach (int i in listOfInts)
            {
                if(head == null)
                {
                    head = new ListNode(i);
                    previousNode = head;
                }
                else
                {
                    currentNode = new ListNode(i);
                    previousNode.next = currentNode;
                    previousNode = currentNode;
                }
            }

            return head;
        }

        static void PrintListNode(ListNode listNode)
        {
            while(listNode != null)
            {
                Console.WriteLine(" \"" + listNode.val + " \"");
                listNode = listNode.next;
            }
        }

    }
}
