using System;

namespace LongestSubstringWithoutRepeatingCharacters
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
            var originalString = "abcabcbb";
            var expectedLongestSubstring = "abc";

            var solution = new Solution();
            var longestSubstring = solution.LongestSubstring(originalString);

            PrintResult(originalString, expectedLongestSubstring, longestSubstring);
        }

        static void PrintResult(string originalString, string expectedLongestSubstring, string longestSubstring)
        {
            Console.WriteLine($"{originalString}: Longest expected substring [{expectedLongestSubstring}] == Longest substring found [{longestSubstring}] = {expectedLongestSubstring == longestSubstring}");
            Console.WriteLine(); Console.WriteLine();
        }
    }
}
