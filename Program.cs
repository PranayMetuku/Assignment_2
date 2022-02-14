/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 1, 2, 2, 3, 3, 3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            //int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            //[[0,2],[1,3]]
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };

            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                //For this we use the binary search algo to find the positon of the target , if not found it will give us the next possible position
                int L = nums.Length - 1, position = 0;

                //int index;
                while (position <= L)
                {
                    int m = position + (L - position) / 2;    //binary search algorithm begins
                    if (nums[m] == target)
                    {
                        return m;
                    }
                    if (nums[m] < target)
                    {
                        position = m + 1;

                    }
                    else
                    {
                        L = m - 1;

                    }


                }
                return position;   //Returns the position of the target
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string strg1 = paragraph.ToLower();
                string strg2 = " ";
                foreach (char ch in strg1)   //Removes the punctuation in the paragraph
                {
                    if (!char.IsPunctuation(ch))
                    {
                        strg2 = strg2 + ch;
                    }
                }
                strg2 = strg2.Trim();
                string[] wordArray = strg2.Split(" ");
                int tempCount = 1;           //using  max count to get the frequency of the words
                int maxCount = 1;
                string maxWord = "";         //to store the frequently occuring word
                Array.Sort(wordArray);
                string tempWord = wordArray[0];
                for (int i = 1; i < wordArray.Length - 1; i++)
                {
                    if (wordArray[i].ToLower() == tempWord.ToLower())
                    {
                        tempCount++;
                    }
                    else
                    {
                        tempWord = wordArray[i];
                        tempCount = 1;
                    }
                    if (tempCount > maxCount)
                    {
                        int flag = 0;
                        for (int j = 0; j < banned.Length; j++)   //To remove the banned words from the paragrapgh string
                        {

                            if (banned[j].ToLower() == tempWord.ToLower())
                            {
                                flag = 1;
                            }
                        }
                        if (flag == 0)
                        {
                            maxCount = tempCount;
                            maxWord = tempWord;

                        }

                    }
                }

                return maxWord;   //Returns the words with highest frqueency excluding the banned words

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]

        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {

                int[] array = new int[500];
                int max = -1;
                foreach (int i in arr)
                {
                    array[i + 1] = array[i + 1] + 1;
                }

                foreach (int i in array)  //Checks the max value in the array
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
                return max;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int bulls_num = 0;
                int cows_num = 0;
                int[] sec_array = new int[10];   //Stores the count of cows in the sec_array
                int[] gue_array = new int[10];   //Stores the count of cow in gue_array


                for (int i = 0; i < secret.Length; i++) //Using While Loop to compute bulls and store the counts of each number in both arrays
                {
                    int A = guess[i] - 48;
                    int B = secret[i] - 48;
                    if (A == B)   //If position are same then we increase the bull count and not add this to our cow arrays
                    {
                        bulls_num++;
                    }
                    else
                    {  //If they are not bulls then we increment the positions of respective numbers in cow arrays
                        sec_array[B]++;
                        gue_array[A]++;
                    }

                }

                for (int j = 0; j < 10; j++)
                {
                    cows_num = cows_num + Math.Min(sec_array[j], gue_array[j]); //Matching cows in both the strings , we take the min count of 

                }
                return bulls_num + "A" + cows_num + "B";

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {

                s = s.ToLower();
                int Len = s.Length;            //To store the lenght of the string
                string str = "";
                List<int> Part = new List<int>();

                // The integer array L_Index stores the last index of characters in  s
                int[] L_Index = new int[26];
                for (int i = 0; i < 26; i++)
                {
                    L_Index[i] = -1;
                }

                for (int i = Len - 1; i >= 0; --i)         // Using the for loop we store the last position of each character in the string
                {


                    if (L_Index[s[i] - 97] == -1)       // Updating the last index
                    {
                        L_Index[s[i] - 97] = i;
                    }
                }
                int m = -1;


                for (int i = 0; i < Len; ++i)
                {
                    int lp = L_Index[s[i] - 97];
                    str += s[i];

                    //We use the Max function to check the current char position is > than the sub-string's max last position and take the max
                    m = Math.Max(m, lp);

                    // Check if postion of present character is equal to the min pos 

                    if (i == m)
                    {
                        Part.Add(str.Length);           // inserting lenght to the list 
                        m = -1;
                        str = "";
                    }
                }
                return Part;   //Returns the List varaibale to the fucntion call


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.





         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide`
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {

                int count = 0;  //To stores the length of the last remaining line
                List<int> op = new List<int>();
                int temp = 0;   //to store the number of possible lines 
                foreach (char ch in s)
                {

                    if (count + widths[Convert.ToInt32(ch) - 97] > 100) //Assignng width to their respective character
                    {
                        temp++;
                        if (count + widths[Convert.ToInt32(ch) - 97] > 100)
                        {
                            count = widths[Convert.ToInt32(ch) - 97];
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    else
                    {
                        count = count + widths[Convert.ToInt32(ch) - 97];
                    }

                }
                if (count < 100 && count > 0)
                {
                    temp++;
                }
                op.Add(temp);  //Adds the number of lines to the list
                op.Add(count); //Adds the width size to the list 

                //to get the length of the last reamining line
                return op;




            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //We use the conditional statements and counter to see if punctutaions are in order,if not we just increment the counter
                int len = bulls_string10.Length;

                int count = 0;
                while (len != 0)
                {

                    if (bulls_string10[1] != ')')
                    {
                        count++;
                    }
                    else if (bulls_string10[3] != ']')
                    {
                        count++;
                    }
                    else if (bulls_string10[5] != '}')
                    {
                        count++;
                    }
                    len--;
                }


                if (count == 0) //if they are in order then its valid
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //string[] letters = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

                string[] codes = new string[26] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                string temp = "";
                int count = 0;
                Dictionary<string, int> store = new Dictionary<string, int>();
                foreach (string str in words)
                {
                    foreach (char ch in str)                            //we use the for loop 
                    {
                        temp = temp + codes[Convert.ToInt32(ch) - 97];  //assign the character to their respective codes
                    }
                    if (store.ContainsKey(temp))
                    {
                        store[temp] = store[temp] + 1;                  //Checks if there are any same morse codes for the strings
                    }
                    else
                    {
                        store.Add(temp, 1);
                    }
                    temp = string.Empty;

                }
                count = store.Count;

                return count;




            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            int element = grid[0, 0];
            int rowLength = grid.GetLength(0);
            int colLength = grid.GetLength(1);
            try
            {/*
                for(int i =0; i < grid.GetLength(0)-1;i++)
                {
                    for (int j = 0; j < grid.GetLength(0)-1; j++)
                    {
                        if (i< rowLength & j< colLength & grid[i + 1, j] <= element)
                        {
                            i = i + 1;
                            continue;
                        }
                        else if(i < rowLength & j < colLength & grid[i, j + 1] <= element){
                            j=j + 1;
                            continue;
                        }
                        else
                        {
                            if (i < rowLength & j < colLength & grid[i, j + 1] >= grid[i + 1, j])
                            {
                                element = grid[i + 1, j];
                                i = i + 1;
                            }
                            else if(i < rowLength & j < colLength)
                            {
                                element = grid[i, j+1];
                                j = j + 1;

                            }

                        }
                    }
                }

                if (element < grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1])
                {
                    Console.WriteLine(grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1]);
                }
                else
                {
                    Console.WriteLine(element);
                }
                */
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int a = word1.Length;  //Stores the  length of the Word 1
                int b = word2.Length;  //Stores the  length of the Word 2

                //Intialising two dimesnioanl array to store the Matrix 
                int[,] matrix = new int[a + 1, b + 1];


                for (int i = 0; i <= a; i++) //Filling matrix from bottom-top order
                {
                    for (int j = 0; j <= b; j++)
                    {
                        // If first string is empty,then copy second string to first string
                        if (i == 0)
                        {

                            matrix[i, j] = j;
                        }
                        // If second string is empty,then copy first string to second string
                        else if (j == 0)
                        {

                            matrix[i, j] = i;
                        }
                        // If last characters of strings are same, no operation is needed .so, repeat the process for remaining string
                        else if (word1[i - 1] == word2[j - 1])
                        {
                            matrix[i, j] = matrix[i - 1, j - 1];
                        }

                        else
                        {
                            matrix[i, j] = 1 + Math.Min(matrix[i, j - 1],   //Insert operation
                                Math.Min(matrix[i - 1, j],                  //Remove operation
                                 matrix[i - 1, j - 1]));                    //Replace operation
                        }
                    }
                }

                return matrix[a, b];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
