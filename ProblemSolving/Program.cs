
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
using System.Linq;
using System.Text;

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


#region 35. Search Insert Position (Binary Search) [Not Solved...]
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


#region 49. Group Anagrams [Not Solved...]
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
//    List<List<string>> outputStrings = new List<List<string>>();
//    Stack<char> stack = new Stack<char>();


//    return outputStrings;
//}

//string[] strs = {"eat", "tea", "tan", "ate", "nat", "bat"};
//Console.WriteLine("Group Anagrams: " + GroupAnagrams(strs)); //[["bat"],["nat","tan"],["ate","eat","tea"]]
//Console.WriteLine();
#endregion


#region 121. Best Time to Buy and Sell Stock (Sliding Window) [Not Solved...]
/*
- You are given an array , prices, where prices[i] is the price of a given stock on the ith day.

- You want to maximize your profit by choosing a single day to buy one stock
    and choosing a different day in the future to sell that stock.

- Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

- Example 1:
    Input: prices = [7,1,5,3,6,4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

- Example 2:
    Input: prices = [7,6,4,3,1]
    Output: 0
    Explanation: In this case, no transactions are done and the max profit = 0.
 
- Constraints:
    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^4
 */

static int MaxProfit(int[] prices)
{
    if (prices.Length < 2)
    {
        return 0;
    }

    Dictionary<int,int> minBasket = new Dictionary<int, int>();
    minBasket.Add(prices[0], 0);

    Stack<int> maxBasket = new Stack<int>();

    for (int i = 1; i < prices.Length; i++)
    {
        if (prices[i] < minBasket.Keys.FirstOrDefault())
        {
            minBasket.Remove(minBasket.Keys.FirstOrDefault());
            minBasket.Add(prices[i],i);
        }
    }

    for (int i = minBasket.Values.FirstOrDefault()+1; i < prices.Length; i++)
    {

    }

    return 0;
}

int[] prices = { 7, 1, 5, 3, 6, 4 };
Console.WriteLine("Max Profit: " + MaxProfit(prices));
Console.WriteLine();

#endregion


#region 125. Valid Palindrome (Two Pointers)
/*
- A phrase is a palindrome if, after converting all uppercase letters into lowercase letters 
    and removing all non-alphanumeric characters, it reads the same forward and backward. 
        Alphanumeric characters include letters and numbers.

- Given a string s, return true if it is a palindrome, or false otherwise.

- Example 1:
    Input: s = "A man, a plan, a canal: Panama"
    Output: true
    Explanation: "amanaplanacanalpanama" is a palindrome.

- Example 2:
    Input: s = "race a car"
    Output: false
    Explanation: "raceacar" is not a palindrome.

- Example 3:
    Input: s = " "
    Output: true
    Explanation: s is an empty string "" after removing non-alphanumeric characters.
                    Since an empty string reads the same forward and backward, it is a palindrome.
 
- Constraints:

    1 <= s.length <= 2 * 10^5
    s consists only of printable ASCII characters.
*/

static bool IsPalindrome(string s)
{
   List<char> chars = new List<char>();
   string result = "";

    for (int i = 0; i < s.Length; i++)
    {
        if (!char.IsAsciiLetterOrDigit(s[i]))
            s.Remove(i,1);
        else
            result = string.Concat(result, s[i]);
    }

    var orderedString = result.ToString().ToLower();

    char[] resArray = result.ToCharArray();
    Array.Reverse(resArray);
    var reversedString = string.Concat(resArray).ToLower();
   
    if (orderedString.SequenceEqual(reversedString))
        return true;
    else
        return false;

}


string pal1 = "A man, a plan, a canal: Panama";
Console.WriteLine("Is Palindrome: " + IsPalindrome(pal1));

string pal2 = "race a car";
Console.WriteLine("Is Palindrome: " + IsPalindrome(pal2));
Console.WriteLine();
#endregion


#region 167. Two Sum II - Input Array Is Sorted (Two Pointers)
/*
- Given a 1-indexed array of integers (numbers) that is already sorted in non-decreasing order, 
    find two numbers such that they add up to a specific target number. 
        Let these two numbers be numbers[index1] and numbers[index2] where (1 <= index1) < (index2 <= numbers.length).

- Return the indices of the two numbers, index1 and index2, 
    added by one as an integer array [index1, index2] of length 2.

- The tests are generated such that there is exactly one solution. You may not use the same element twice.

- Your solution must use only constant extra space.

- Example 1:
    Input: numbers = [2,7,11,15], target = 9
    Output: [1,2]
    Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].

- Example 2:
    Input: numbers = [2,3,4], target = 6
    Output: [1,3]
    Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].

- Example 3:
    Input: numbers = [-1,0], target = -1
    Output: [1,2]
    Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
 
- Constraints:
    2 <= numbers.length <= 3 * 10^4
    -1000 <= numbers[i] <= 1000
    numbers is sorted in non-decreasing order.
    -1000 <= target <= 1000
    The tests are generated such that there is exactly one solution.
 */

static int[] TwoSums(int[] numbers, int target)
{
    List<int> results = new List<int>();

    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = i+1; j < numbers.Length; j++)
        {
            if (numbers[i] + numbers[j] == target)
            {
                results.Add(i+1);
                results.Add(j+1);
            }
            else if (numbers[i] + numbers[j] > target)
                break;
        }
    }

    return results.ToArray();
}

int[] numArr1 = {2,7,11,15};
Console.WriteLine("Two Sums: " + TwoSums(numArr1,9)); //[1,2]
Console.WriteLine();


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


#region 219. Contains Duplicate II (SlidingWindow)

static bool ContainsNearbyDuplicate(int[] nums, int k)
{

    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] == nums[j] && (Math.Abs(i - j)) <= k)
            {
                return true;
            }
        }
    }

    return false;
}


int[] testNums = { 1, 2, 3, 1 };
int numsK = 3;
Console.WriteLine("Contains Nearby Duplicate: " + ContainsNearbyDuplicate(testNums, numsK)); //true
Console.WriteLine();
#endregion


#region 238. Product of Array Except Self [Not Solved...]
/*
- Given an integer array nums, return an array answer such that answer[i] 
    is equal to the product of all the elements of nums except nums[i].

- The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

- You must write an algorithm that runs in O(n) time and without using the division operation.


- Example 1:
    Input: nums = [1,2,3,4]
    Output: [24,12,8,6]

- Example 2:
    Input: nums = [-1,1,0,-3,3]
    Output: [0,0,9,0,0]

- Constraints:
    2 <= nums.length <= 10^5
    -30 <= nums[i] <= 30
    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

- Follow up: Can you solve the problem in O(1) extra space complexity? 
    (The output array does not count as extra space for space complexity analysis.)
*/

static int[] ProductExceptSelf(int[] nums)
{
    int[] soln = new int[nums.Length];

    return soln;
}


int[] ints = { -1, 1, 0, -3, 3 };
Console.WriteLine("Product of Array Except Self: " + ProductExceptSelf(ints)); //[0,0,9,0,0]
Console.WriteLine();
#endregion


#region 242. Valid Anagram (HashTable/Dictionary)
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
    var sWord = s.ToCharArray();
    var tWord = t.ToCharArray();

    Array.Sort(sWord);
    Array.Sort(tWord);

    if (sWord.Length == tWord.Length)
    {
        return sWord.SequenceEqual(tWord);
    }

    return false;
    
}


string s1 = "aaccd";
string w1 = "cddac";
Console.WriteLine("Valid Anagram ? : " + IsAnagram(s1,w1)); //false
                                                            
string s2 = "anagram";
string w2 = "nagaram";
Console.WriteLine("Valid Anagram ? : " + IsAnagram(s2,w2)); //false
Console.WriteLine();

#endregion


#region 283. Move Zeroes (Two Pointers)
/*
- Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
- Note that you must do this in-place without making a copy of the array.

- Example 1:
    Input: nums = [0,1,0,3,12]
    Output: [1,3,12,0,0]

- Example 2:
    Input: nums = [0]
    Output: [0]
 
- Constraints:
    1 <= nums.length <= 104
    -2^31 <= nums[i] <= 2^31 - 1
*/

static void MoveZeroes(int[] nums)
{
    if (nums.Length < 2) 
        return;

    int LP = 0;
    int RP = 1;

    /*
     {0,  1,  0,  3,  12}
      ^   ^
      LP  RP
    */

    while (RP < nums.Length)
    {
        if (nums[LP] != 0)
        {
            LP++;
            RP++;
        }
        else if (nums[RP] == 0)
        {
            RP++;
        }
        else
        {
            //swap...
            int temp = nums[RP];
            nums[RP] = nums[LP];
            nums[LP] = temp;
        }
    }
}

int[] numbers1 = {0, 1, 0, 3, 12};
MoveZeroes(numbers1);
Console.WriteLine("Move Zeroes: " + numbers1); // {1,3,12,0,0}
Console.WriteLine();
#endregion


#region 347. Top K Frequent Elements [Dictionary + HashSet]
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


#region 392. Is Subsequence [Not Solved...]
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


#region 560. Subarray Sum Equals K
/*
- Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

- A subarray is a contiguous non-empty sequence of elements within an array.

 

- Example 1:
    Input: nums = [1,1,1], k = 2
    Output: 2

- Example 2:
    Input: nums = [1,2,3], k = 3
    Output: 2
 
- Constraints:
    1 <= nums.length <= 2 * 10^4
    -1000 <= nums[i] <= 1000
    -10^7 <= k <= 10^7 
*/

static int SubarraySum(int[] nums, int k)
{
    int count = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        int sum = nums[i];
        if (sum == k)
            count++;

        for (int j = i+1; j < nums.Length; j++)
        {
            sum += nums[j];
            if (sum == k)
                count++;
        }
    }

    return count;
}

int[] numb1 = {1, 1, 1};
int[] numb2 = {1, 2, 3};
int[] numb3 = {1, -1, 0};
int[] numb4 = {1};
int[] numb5 = {100,1,2,3,4};
int[] numb6 = { 0, 0 };
Console.WriteLine("Subarray Sum: " + SubarraySum(numb1, 2)); //2
Console.WriteLine("Subarray Sum: " + SubarraySum(numb2, 3)); //2
Console.WriteLine("Subarray Sum: " + SubarraySum(numb3, 0)); //3
Console.WriteLine("Subarray Sum: " + SubarraySum(numb4, 1)); //1
Console.WriteLine("Subarray Sum: " + SubarraySum(numb5, 6)); //1
Console.WriteLine("Subarray Sum: " + SubarraySum(numb6, 0)); //3
Console.WriteLine();
#endregion


#region 682. Baseball Game (Stack)
static int CalPoints(string[] operations)
{
    Stack<int> records = new Stack<int>();
    int sum = 0;

    for (int i = 0; i < operations.Length; i++)
    {
        if (operations[i].ToLower() == "c")
            records.Pop();
        else if (operations[i].ToLower() == "d")
            records.Push(records.Peek() * 2);
        else if (operations[i].ToLower() == "+")
            records.Push(records.ElementAt(0) + records.ElementAt(1));
        else
            records.Push(int.Parse(operations[i]));
    }

    foreach (var item in records)
    {
        sum += item;
    }

    return sum;
}

string[] ops2 = { "5", "-2", "4", "C", "D", "9", "+", "+" };
Console.WriteLine("CalPoints: " + CalPoints(ops2)); //27
string[] ops = { "5", "2", "C", "D", "+" };
Console.WriteLine("CalPoints: " + CalPoints(ops)); //30
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


#region 1768. Merge Strings Alternately (Two Pointers) [Not Solved...]
/*
- You are given two strings word1 and word2. 
    Merge the strings by adding letters in alternating order, starting with word1. 
        If a string is longer than the other, append the additional letters onto the end of the merged string.

- Return the merged string. 

- Example 1:
    Input: word1 = "abc", word2 = "pqr"
    Output: "apbqcr"
    Explanation: The merged string will be merged as so:
    word1:  a   b   c
    word2:    p   q   r
    merged: a p b q c r

- Example 2:
    Input: word1 = "ab", word2 = "pqrs"
    Output: "apbqrs"
    Explanation: Notice that as word2 is longer, "rs" is appended to the end.
    word1:  a   b 
    word2:    p   q   r   s
    merged: a p b q   r   s

- Example 3:
    Input: word1 = "abcd", word2 = "pq"
    Output: "apbqcd"
    Explanation: Notice that as word1 is longer, "cd" is appended to the end.
    word1:  a   b   c   d
    word2:    p   q 
    merged: a p b q c   d
 
- Constraints:
    1 <= word1.length, word2.length <= 100
    word1 and word2 consist of lowercase English letters.
 */

static string MergeAlternately(string word1, string word2)
{
    Dictionary<char, int> valuePairs = new Dictionary<char, int>();
    int countWord1 = 1;
    int countWord2 = 2;
    string res = "";

    for (int i = 0; i < word1.Length; i++)
    {
        valuePairs.Add(word1[i], countWord1);
        countWord1 += 2;
    }

    for (int i = 0; i < word2.Length; i++)
    {
        valuePairs.Add(word2[i], countWord2);
        countWord2 += 2;
    }

    for (int i = 1; i < valuePairs.Values.Max() + 1; i++)
    {
        if (valuePairs.ContainsValue(i))
            res = string.Concat(res, valuePairs.Keys.FirstOrDefault(key => valuePairs[key] == i));
        else
            continue;
    }

    return res;
     
}

string wordEx1 = "ab";
string wordEx2 = "pqrs";
Console.WriteLine("Merge Alternately: " + MergeAlternately(wordEx1,wordEx2));

string wordEx3 = "abcd";
string wordEx4 = "pq";
Console.WriteLine("Merge Alternately: " + MergeAlternately(wordEx3,wordEx4));
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


#region 3120. Count the Number of Special Characters I
/*
- You are given a string word. A letter is called special if it appears both in lowercase and uppercase in word.
- Return the number of special letters in word.

- Example 1:
    Input: word = "aaAbcBC"
    Output: 3
    Explanation:
    The special characters in word are 'a', 'b', and 'c'.

- Example 2:
    Input: word = "abc"
    Output: 0
    Explanation:
    No character in word appears in uppercase.

- Example 3:
    Input: word = "abBCab"
    Output: 1
    Explanation:
    The only special character in word is 'b'.

- Constraints:
    1 <= word.length <= 50
    word consists of only lowercase and uppercase English letters. 
*/

static int NumberOfSpecialChars(string word)
{
    HashSet<char> result = new HashSet<char>();
    Dictionary<char,int> valuePairs = new Dictionary<char,int>();
    int count = 0;

    for (int i = 0; i < word.Length; i++)
    {
        result.Add(word[i]);
    }

    foreach (var item in result)
    {
        if (!valuePairs.ContainsKey(char.ToLower(item)))
            valuePairs.Add(char.ToLower(item), 1);
        else
            valuePairs[char.ToLower(item)]++;
    }

    foreach (var item in valuePairs)
    {
        if (item.Value > 1)
            count++;
    }

    return count;
}

string word1 = "aaAbcBC";
string word2 = "Cc";
Console.WriteLine("Number Of Special Chars: " + NumberOfSpecialChars(word1)); //3
Console.WriteLine("Number Of Special Chars: " + NumberOfSpecialChars(word2)); //1
#endregion


#region 3121. Count the Number of Special Characters II
/*
- You are given a string word. A letter c is called special if it appears both in lowercase and uppercase in word,
    and every lowercase occurrence of c appears before the first uppercase occurrence of c.

- Return the number of special letters in word.

- Example 1:
    Input: word = "aaAbcBC"
    Output: 3
    Explanation:
    The special characters are 'a', 'b', and 'c'.
    
- Example 2:
    Input: word = "abc"
    Output: 0
    Explanation:
    There are no special characters in word.

- Example 3:
    Input: word = "AbBCab"
    Output: 0
    Explanation:
    There are no special characters in word.

Constraints:

1 <= word.length <= 2 * 105
word consists of only lowercase and uppercase English letters. 
*/

static int NumberOfSpecialCharsII(string word)
{
    Dictionary<char, int> uppercaseLetters = new Dictionary<char, int>();
    Dictionary<char, int> lowercaseLetters = new Dictionary<char, int>();
    int count = 0;

    for (int i = 0; i < word.Length; i++) 
    {
        if (char.IsUpper(word[i]) && !uppercaseLetters.ContainsKey(word[i]))
        {
            uppercaseLetters.Add(word[i], i);
        }

        if (char.IsLower(word[i]))
        {
            if (!lowercaseLetters.ContainsKey(word[i]))
                lowercaseLetters.Add(word[i], i);
            else
                lowercaseLetters[word[i]] = i;
        }
    }

    foreach (var item in lowercaseLetters)
    {
        if (uppercaseLetters.ContainsKey(char.ToUpper(item.Key)))
        {
            if (uppercaseLetters[char.ToUpper(item.Key)] > lowercaseLetters[item.Key])
            {
                count++;
            }
        }
    }

    return count;
}

string wo1 = "AbBCab";
Console.WriteLine("Number Of Special Chars II: " + NumberOfSpecialCharsII(wo1)); //0
#endregion


#region 225. Implement Stack using Queues (Stack)
/*
- Implement a last-in-first-out (LIFO) stack using only two queues. 
    The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).

- Implement the (MyStack) class:
    [void push(int x)] : Pushes element x to the top of the stack.
    [int pop()]        : Removes the element on the top of the stack and returns it.
    [int top()]        : Returns the element on the top of the stack.
    [boolean           : empty()] Returns true if the stack is empty, false otherwise.

- Notes:
    You must use only standard operations of a queue, which means that only (push to back),
        (peek/pop from front), (size) and (is empty) operations are valid.
    Depending on your language, the queue may not be supported natively. 
        You may simulate a queue using a list or deque (double-ended queue) 
            as long as you use only a queue's standard operations.
 

- Example 1:
    Input
    ["MyStack", "push", "push", "top", "pop", "empty"]
    [[], [1], [2], [], [], []]
    Output
    [null, null, null, 2, 2, false]

** Explanation **
    MyStack myStack = new MyStack();
    myStack.push(1);
    myStack.push(2);
    myStack.top(); // return 2
    myStack.pop(); // return 2
    myStack.empty(); // return False
 
- Constraints:
    1 <= x <= 9
    At most 100 calls will be made to push, pop, top, and empty.
    All the calls to pop and top are valid.
 */
MyStack myStack = new MyStack();
Console.WriteLine("MyStack: " + myStack);
myStack.Push(50);
Console.WriteLine("MyStack: " + myStack);
myStack.Push(25);
Console.WriteLine("MyStack: " + myStack);
myStack.Top(); // return 2
Console.WriteLine("MyStack: " + myStack);
myStack.Pop(); // return 2
Console.WriteLine("MyStack: " + myStack);
myStack.Empty(); // return False
Console.WriteLine("MyStack: " + myStack);



public class MyStack
{
    public List<int> Stack = new List<int>();

    public MyStack()
    {

    }

    public void Push(int x)
    {
        Stack.Add(x);
    }

    public int Pop()
    {
        var elementPoped = Top();
        if (Stack.Count < 1)
            return 0;

        Stack.RemoveAt(Stack.Count - 1);
        return elementPoped;
    }

    public int Top()
    {
        return Stack.LastOrDefault();
    }

    public bool Empty()
    {
        if (Stack.Count > 0)
            return false;

        return true;
    }
}
#endregion



