﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainsDuplicateIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 3, 1};
            int k = 3, t = 0;
            Console.WriteLine(ContainsNearbyAlmostDuplicate(nums, k, t));
        }
        static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            var sorted = nums.Select((value, index) => new {value, index}).OrderBy(x => x.value).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                long cur = sorted[i].value;
                for (int j = i + 1; j < sorted.Length && sorted[j].value - cur <= t; j++)
                {
                    if (Math.Abs(sorted[i].index - sorted[j].index) <= k)
                        return true;
                }
            }
            return false;
        }
    }
}
