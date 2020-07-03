﻿//回溯算法，用DFS拼串，每次更新maxLen。
//注意需要额外检查一下，每个字符串本身是否有重复字母。
using System;
using System.Collections.Generic;

namespace MaximumLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "yy","bkhwmpbiisbldzknpm" };
            Console.WriteLine(MaxLength(arr));
        }

        static int maxLen;
        static int MaxLength(IList<string> arr)
        {
            var letters = new HashSet<char>();
            var cur = "";
            Generate(arr, cur, 0, letters);
            return maxLen;
        }

        static void Generate(IList<string> arr, string cur, int index, HashSet<char> letters)
        {
            maxLen = Math.Max(maxLen, cur.Length);
            for (int i = index; i < arr.Count; i++)
            {
                bool hasRepeat = false;
                var check = new HashSet<char>();
                foreach (var letter in arr[i])
                {
                    if (letters.Contains(letter) || !check.Add(letter))
                    {
                        hasRepeat = true;
                        break;
                    }
                }
                if (!hasRepeat)
                {
                    foreach (var letter in arr[i])
                        letters.Add(letter);
                    Generate(arr, cur + arr[i], i, letters);
                    foreach (var letter in arr[i])
                        letters.Remove(letter);
                }
            }
        }
    }
}
