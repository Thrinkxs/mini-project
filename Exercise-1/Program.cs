﻿using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // You have two arrays/lists as follows
            int[] list1 = new int[] { 1, 2, 3, 4, 5 };
            int[] list2 = new int[] { 3, 4, 5, 6, 7 };

            // a. Show the common elements in both lists. E.g the common elements are "3 4 5", because they are contained in both lists.
            var list3 = list1.Intersect(list2);
            Console.WriteLine("Common elements in both lists: " + string.Join(" ", list3));

            // b. Show the elements from list 1, but is not found in list2. E.g 1 2"
            var list4 = list1.Except(list2);
            Console.WriteLine("Elements in List1 that does not appear in List2: " + string.Join(" ", list4));

            // c. Show the elements from list 2, but is not found in list1. E.g 6 7"
            var list5 = list2.Except(list1);
            Console.WriteLine("Elements in List2 that does not appear in List1: " + string.Join(" ", list5));

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadLine();
        }
    }
}
