
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

