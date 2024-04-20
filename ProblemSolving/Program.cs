﻿
/*============================================== LeetCode ==============================================*/


#region 1. Two Sum
/*
- Given an array of integers nums and an integer target, 
    return indices of the two numbers such that they add up to target.

- You may assume that each input would have exactly one solution, 
    and you may not use the same element twice.

- You can return the answer in any order.

- Example 1:
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

- Example 2:
    Input: nums = [3,2,4], target = 6
    Output: [1,2]

- Example 3:
    Input: nums = [3,3], target = 6
    Output: [0,1]
 

- Constraints:
    1) 2 <= nums.length <= 10^4
    2) -109 <= nums[i] <= 10^9
    3) -109 <= target <= 10^9
    4) Only one valid answer exists. 
*/

using System.Collections.Immutable;

static int[] TwoSum(int[] nums, int target)
{
    List<int> result = new List<int>();

    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i+1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                result.Add(i);
                result.Add(j);
                break;
            }
        }

        if (result.Count > 0)
        {
            break;
        }
    }

    return result.ToArray();
}

int[] inputs1 = { 2, 7, 11, 15 };
int[] inputs2 = { 3, 2, 4 };
int[] inputs3 = { 3, 3 };
Console.WriteLine("TwoSum: " + "[" + string.Join("," , TwoSum(inputs1, 9)) + "]"); //[0, 1]
Console.WriteLine("TwoSum: " + "[" + string.Join("," , TwoSum(inputs2, 6)) + "]"); //[1, 2]
Console.WriteLine("TwoSum: " + "[" + string.Join("," , TwoSum(inputs3, 6)) + "]"); //[0, 1]
Console.WriteLine();

#endregion


#region 20. Valid Parentheses (Stack)
/*
- Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', 
    determine if the input string is valid.

- An input string is valid if:
    1) Open brackets must be closed by the same type of brackets.
    2) Open brackets must be closed in the correct order.
    3) Every close bracket has a corresponding open bracket of the same type.
 

- Example 1:
    Input: s = "()"
    Output: true

- Example 2:
    Input: s = "()[]{}"
    Output: true

- Example 3:
    Input: s = "(]"
    Output: false
 
- Constraints:
    1) 1 <= s.length <= 10^4
    2) s consists of parentheses only '()[]{}'.
*/

static bool IsValid(string s)
{
    Stack<char> bracketChars = new Stack<char>();

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '(' || s[i] == '[' || s[i] == '{')
        {
            bracketChars.Push(s[i]);
            continue;
        }

        if (s[i] == ')' || s[i] == ']' || s[i] == '}')
        {
            if (bracketChars.Count == 0)
            {
                return false;
            }

            if (s[i] == ')')
            {
                var lastBracket = bracketChars.Pop();
                if (lastBracket != '(')
                {
                    return false;
                }
            }

            if (s[i] == ']')
            {
                var lastBracket = bracketChars.Pop();
                if (lastBracket != '[')
                {
                    return false;
                }
            }

            if (s[i] == '}')
            {
                var lastBracket = bracketChars.Pop();
                if (lastBracket != '{')
                {
                    return false;
                }
            }
        }
        
    }

    if (bracketChars.Count > 0)
    {
        return false;
    }

    return true;
}


string str1 = "()[]{}";
string str2 = "(]";
string str3 = "]";
Console.WriteLine("Is Valid Parentheses: " + IsValid(str1)); //true
Console.WriteLine("Is Valid Parentheses: " + IsValid(str2)); //false
Console.WriteLine("Is Valid Parentheses: " + IsValid(str3)); //false
Console.WriteLine();

#endregion


#region 35. Search Insert Position (Binary Search) [Not Solved]
/*
- Given a sorted array of distinct integers and a target value, return the index if the target is found. 
    If not, return the index where it would be if it were inserted in order.

- You must write an algorithm with O(log n) runtime complexity.

- Example 1:
    Input: nums = [1,3,5,6], target = 5
    Output: 2

- Example 2:
    Input: nums = [1,3,5,6], target = 2
    Output: 1

- Example 3:
    Input: nums = [1,3,5,6], target = 7
    Output: 4
 

- Constraints:
    1) 1 <= nums.length <= 10^4
    2) -10^4 <= nums[i] <= 10^4
    3) nums contains distinct values sorted in ascending order.
    4) -10^4 <= target <= 10^4 
*/

static int SearchInsert(int[] nums, int target)
{
    int lowerBound = 0; //first element
    int upperBound = nums.Length - 1; //last element
    int valueAtMidPoint = 0;
    int result = 0;

    if (!nums.Contains(target))
    {
        while (lowerBound < upperBound)
        {
            var midPoint = (lowerBound + upperBound) / 2;
            valueAtMidPoint = nums[midPoint];

            if (target < valueAtMidPoint)
                upperBound = midPoint - 1;
            else if (target > valueAtMidPoint)
                lowerBound = midPoint + 1;
        }

        if (lowerBound == upperBound)
        {
            if (target < valueAtMidPoint)
            {
                nums.Append(target);
            }

        }
    }
    if (nums.Contains(target))
    {
        while (lowerBound <= upperBound)
        {
            var midPoint = (lowerBound + upperBound) / 2;
            valueAtMidPoint = nums[midPoint];

            if (target == valueAtMidPoint)
            {
                result = midPoint;
                break;
            }
            else if (target < valueAtMidPoint)
                upperBound = midPoint - 1;
            else if (target > valueAtMidPoint)
                lowerBound = midPoint + 1;
        }

        return result;
    }

    else
        return -1;
}


#endregion


#region 49. Group Anagrams [waiting...]
/*
- Given an array of strings strs, group the anagrams together. You can return the answer in any order.

- An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
    typically using all the original letters exactly once.

 

- Example 1:
    Input: strs = ["eat","tea","tan","ate","nat","bat"]
    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

- Example 2:
    Input: strs = [""]
    Output: [[""]]

- Example 3:
    Input: strs = ["a"]
    Output: [["a"]]

- Constraints:
    1 <= strs.length <= 10^4
    0 <= strs[i].length <= 100
    strs[i] consists of lowercase English letters.
*/

//static IList<IList<string>> GroupAnagrams(string[] strs)
//{

//}
#endregion


#region 217. Contains Duplicate (HashTable/Dictionary) 
/*
* Given an integer array nums, 
    return true if any value appears at least twice in the array, 
        and return false if every element is distinct.
* Example 1:
    Input: nums = [1,2,3,1]
    Output: true

  Example 2:
    Input: nums = [1,2,3,4]
    Output: false

  Example 3:
    Input: nums = [1,1,1,3,3,4,3,2,4,2]
    Output: true
* Constraints:
    1) 1 <= nums.length <= 10^5
    2) -109 <= nums[i] <= 10^9
*/

static bool ContainsDuplicate(int[] nums)
{
    Dictionary<int, bool> keyValuePairs = new Dictionary<int, bool>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (keyValuePairs.ContainsKey(nums[i]))
        {
            return true;
        }
        else
        {
            keyValuePairs.Add(nums[i], true);
        }
    }

    return false;
}

int[] nums1 = {1, 2, 3, 1};
int[] nums2 = {1, 2, 3, 4};
int[] nums3 = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };

Console.WriteLine("Contains Duplicate ? : " + ContainsDuplicate(nums1)); //true
Console.WriteLine("Contains Duplicate ? : " + ContainsDuplicate(nums2)); //false
Console.WriteLine("Contains Duplicate ? : " + ContainsDuplicate(nums3)); //true
Console.WriteLine();

#endregion


#region 242. Valid Anagram (HashTable/Dictionary) [Not Solved]
/*
- Given two strings s and t, return true if t is an anagram of s, and false otherwise.
- An Anagram : is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

- Example 1:
	Input: s = "anagram", t = "nagaram"
	Output: true

- Example 2:
	Input: s = "rat", t = "car"
	Output: false

- Constraints:
	1) 1 <= s.length, t.length <= 5 * 10^4
	2) s and t consist of lowercase English letters.
*/

static bool IsAnagram(string s, string t)
{
    string sWord = s.ToLower();
    string tWord = t.ToLower();
    Dictionary<char, int> sPairs = new Dictionary<char, int>();
    Dictionary<char, int> tPairs = new Dictionary<char, int>();
    bool foundMatch = false;


	if (sWord.Length == tWord.Length && 1 <= sWord.Length && tWord.Length <= 5 * (10^4))
	{
        for (int i = 0; i < sWord.Length; i++)
        {
            if (!sPairs.ContainsKey(sWord[i]))
                sPairs.Add(sWord[i], 1);
            else
                sPairs[sWord[i]] += 1;
        }

        for (int i = 0; i < tWord.Length; i++)
        {
            if (!tPairs.ContainsKey(tWord[i]))
                tPairs.Add(tWord[i], 1);
            else
                tPairs[tWord[i]] += 1;

            
            if (sPairs.ContainsKey(tWord[i]))
            {
                if (sPairs[tWord[i]] == tPairs[tWord[i]])
                {
                    foundMatch = true;
                }
                else
                {
                    foundMatch = false;
                }
            }
            else
            {
                foundMatch = false;
                break;
            }

        }

        return foundMatch;
    }

    return false;
    
}


string s1 = "aaccd";
string s2 = "cddac";
Console.WriteLine("Valid Anagram ? : " + IsAnagram(s1,s2)); //false
Console.WriteLine();

#endregion


#region 347. Top K Frequent Elements
/*
- Given an integer array nums and an integer k, return the k most frequent elements. 
    You may return the answer in any order.

- Example 1:
    Input: nums = [1,1,1,2,2,3], k = 2
    Output: [1,2]

- Example 2:
    Input: nums = [1], k = 1
    Output: [1]
 
- Constraints:
    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4
    k is in the range [1, the number of unique elements in the array].
    It is guaranteed that the answer is unique.
 
- Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size. 
*/

static int[] TopKFrequent(int[] nums, int k)
{
    HashSet<int> results = new HashSet<int>();
    Dictionary<int, int> values = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (values.ContainsKey(nums[i]))
        {
            values[nums[i]]++;
        }
        else
            values.Add(nums[i], 1);
    }

    var orderedValues = values.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    int count = 0;
    while (count < k)
    {
        results.Add(orderedValues.Keys.FirstOrDefault());
        orderedValues.Remove(orderedValues.Keys.FirstOrDefault());
        count++;
    }
 
    return results.ToArray();
}

int[] num1 = { 1, 1, 1, 2, 2, 3 };
int k1 = 2;
Console.WriteLine("Top K Frequent: " + "[" + string.Join(",", TopKFrequent(num1, k1)) + "]"); // [1,2]


int[] num2 = {1};
int k2 = 1;
Console.WriteLine("Top K Frequent: " + "[" + string.Join(",", TopKFrequent(num2, k2)) + "]"); // [1]

int[] num3 = { 1, 2 };
int k3 = 2;
Console.WriteLine("Top K Frequent: " + "[" + string.Join(",", TopKFrequent(num3, k3)) + "]"); // [1,2]

int[] num4 = { 3, 0, 1, 0 };
int k4 = 1;
Console.WriteLine("Top K Frequent: " + "[" + string.Join(",", TopKFrequent(num4, k4)) + "]"); // [0]

Console.WriteLine();
#endregion


#region 392. Is Subsequence [Not Solved]
/*
- Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

- A subsequence of a string is a new string that is formed from the original string by
    deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters.
        (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

 

- Example 1:
    Input: s = "abc", t = "ahbgdc"
    Output: true

- Example 2:
    Input: s = "axc", t = "ahbgdc"
    Output: false
 

- Constraints:
    0 <= s.length <= 100
    0 <= t.length <= 10^4
    s and t consist only of lowercase English letters.
 

- Follow up: 
    Suppose there are lots of incoming s, say s1, s2, ..., sk where k >= 10^9, 
        and you want to check one by one to see if t has its subsequence. 
            In this scenario, how would you change your code?
*/

static bool IsSubsequence(string s, string t)
{
    Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
    Stack<int> checkKeys = new Stack<int>();
    for (int i = 0; i < t.Length; i++)
    {
        keyValuePairs.Add(t[i], i + 1);
    }
    for (int i = 0; i < s.Length; i++)
    {
        if (keyValuePairs.ContainsKey(s[i]))
        {
            if (checkKeys.Count > 0)
            {
                if (checkKeys.Peek() > keyValuePairs[s[i]])
                {
                    return false;
                }
                else
                    checkKeys.Push(keyValuePairs[s[i]]);
            }
            else
                checkKeys.Push(keyValuePairs[s[i]]);
        }
        else
            return false;
    }

    return true;
}

string st1 = "ace";
string st2 = "aec";
string t1 = "abcde";

Console.WriteLine("Is Subsequence: " + IsSubsequence(st2, t1)); //false
Console.WriteLine("Is Subsequence: " + IsSubsequence(st1, t1)); //true


string st3 = "axc";
string t2 = "ahbgdc";

Console.WriteLine("Is Subsequence: " + IsSubsequence(st3, t2)); //false

//string st4 = "aaaaaa";
//string t3 = "bbaaaa";

//Console.WriteLine("Is Subsequence: " + IsSubsequence(st4, t3)); //false
Console.WriteLine();
#endregion


#region 704. Binary Search
/*
- Given an array of integers nums which is sorted in ascending order, and an integer target, 
    write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

- You must write an algorithm with O(log n) runtime complexity. 

Example 1:
    Input: nums = [-1,0,3,5,9,12], target = 9
    Output: 4
    Explanation: 9 exists in nums and its index is 4

- Example 2:
    Input: nums = [-1,0,3,5,9,12], target = 2
    Output: -1
    Explanation: 2 does not exist in nums so return -1
 

- Constraints:

    1) 1 <= nums.length <= 10^4
    2) -10^4 < nums[i], target < 10^4
    3) All the integers in nums are unique.
    4) nums is sorted in ascending order.
*/

static int Search(int[] nums, int target)
{
    int lowerBound = 0; //first element
    int upperBound = nums.Length - 1; //last element
    int result = 0;

    if (nums.Contains(target))
    {
        while (lowerBound <= upperBound)
        {
            var midPoint = (lowerBound + upperBound) / 2;
            var valueAtMidPoint = nums[midPoint];

            if (target == valueAtMidPoint)
            {
                result = midPoint;
                break;
            }
            else if (target < valueAtMidPoint)
                upperBound = midPoint - 1;
            else if (target > valueAtMidPoint)
                lowerBound = midPoint + 1;
        }

        return result;
    }

    else 
        return -1;

}

int[] inputArray = { -1, 0, 3, 5, 9, 12 };
Console.WriteLine("Binary Search: " + Search(inputArray, 9)); //4
Console.WriteLine("Binary Search: " + Search(inputArray, 2)); //-1

#endregion


#region 2390. Removing Stars From a String (Stack)

static string RemoveStars(string s)
{
	Stack<char> values = new Stack<char>();

    for (int i = 0; i < s.Length; i++)
	{
		if (s[i] != '*')
		{
            values.Push(s[i]);
        } 
		else
		{
			values.Pop();
		}

	}

    return String.Concat(values.Reverse());    
}


string starString = "leet**cod*e";
Console.WriteLine("String without stars '*' : " + RemoveStars(starString));
Console.WriteLine();

#endregion

