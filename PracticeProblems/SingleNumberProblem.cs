/*
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1
 */



namespace PracticeProblems
{
    public class SingleNumberProblem : IBaseProblem
    {
        private int[] _nums = [0, 1, 0, 1, 0, 1, 99];

        public SingleNumberProblem()
        {
        }

        public override void Solve()
        {
            Console.WriteLine("Solution 1: " + SingleNumberS1());
            Console.WriteLine("Solution 2: " + SingleNumberS2());
        }

        //Solution 1
        //HashSet vs SortedSet https://code-maze.com/csharp-hashset-vs-sortedset/
        /*With Sorted set: time complexity: O(n*logn), space complexity: O(n)
           With Hash set: time complexity: ~O(n), space complexity: O(n) */
        public int SingleNumberS1()
        {
            var numSet = new HashSet<int>();
            foreach (var n in _nums)
            {
                if (numSet.Contains(n))
                {
                    numSet.Remove(n);
                }
                else
                {
                    numSet.Add(n);
                }
            }

            if (numSet.Count == 1)
            {
                return numSet.First();
            }
            else return -1;
        }

        //Solution 2
        //time complexity: O(n*logn) + O(n-2) = O(nlogn), space complexity: O(n)
        public int SingleNumberS2()
        {
            var sortedNums = _nums.OrderBy(n => n).ToArray();
            for(int i = 1; i < sortedNums.Length - 1; i++)
            {
                if (sortedNums[i] != sortedNums[i - 1] && sortedNums[i] != sortedNums[i + 1])
                {
                    return sortedNums[i];
                }
            }

            return -1;
        }
    }
}
