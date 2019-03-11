using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 72;
            SmallestMultiple(i);

            var oddPal = new LinkedList<int>(new List<int> { 1, 2, 3, 2, 1});
            var evenPal = new LinkedList<int>(new List<int> { 1, 2, 2, 1 });
            var notPal = new LinkedList<int>(new List<int> { 1, 1, 3, 2, 1 });
            var empty = new LinkedList<int>();

            Console.WriteLine(IsPalindrome(oddPal));
            Console.WriteLine(IsPalindrome(evenPal));
            Console.WriteLine(IsPalindrome(notPal));
            Console.WriteLine(IsPalindrome(empty));

            var list = new int[] { 1, 2, 3, 4 };
            var sum = 4;

            GetPairEqualsInput(list, sum);


        }

        private static Tuple<int, int> GetPairEqualsInput(int[] list, int input)
        {

            var pairs = new Dictionary<int, int>();

            for (int i=0; i<list.Length; i++)
            {
                var temp = input - list[i];
                if (pairs.ContainsKey(temp))
                {
                    return new Tuple<int, int>(list[i], temp);
                }
                pairs[list[i]] = i;
            }

            return null;
        }

        private static bool IsPalindrome(LinkedList<int> list)
        {
            var curr = list.First;
            var runner = list.First;
            var stack = new Stack<int>();

            while (runner != null && runner.Next != null)
            {
                stack.Push(curr.Value);
                curr = curr.Next;
                runner = runner.Next.Next;
            }

            // list length is odd, ignore the middle element
            if (runner != null)
            {
                curr = curr.Next;
            }

            while (curr != null)
            {
                if (stack.Pop() != curr.Value)
                {
                    return false;
                }
                curr = curr.Next;
            }

            return true;
        }

        // Function to prints the smallest number 
        // whose digits multiply to n 
        private static void SmallestMultiple(int input)
        {
            var result = new List<int>();

            if (input < 10)
            {
                Console.WriteLine($"{input + 10}");
                return;
            }

            for (int i = 9; i > 1; i--)
            {
                while (input % i == 0)
                {
                    input /= i;
                    result.Add(i);
                }
            }

            if (input > 10)
            {
                Console.WriteLine("Not possible.");
            }

            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
        }
    }

    public class Node
    {
        public int Data { get; private set; }
        public Node Next { get; private set; }
        public Node(int data)
        {
            Data = data;
        }

        public void Add(Node node)
        {
            Next = node;
        }
    }
}
