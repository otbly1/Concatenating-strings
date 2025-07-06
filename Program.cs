using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        int count = 100; 

        // Generate the list of random words before starting the benchmarking
        string[] words = GenerateRandomWordsList(count); //generate random words once and send to the other methods

        // Benchmark using the same list of generated words
        TestPlusEqualsOperator(words);
        TestStringInterpolation(words);
        TestStringBuilder(words);
        TestStringJoin(words);
        TestStringConcat(words);
    }

    static Random random = new Random(); // Shared random instance

    static string[] GenerateRandomWordsList(int count)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz"; 
        string[] words = new string[count]; // we will save the generated words here

        for (int i = 0; i < count; i++)//If count = 5, it means: "Create 5 different random words." It fills the words[] array (your list of words).
        {
            int length = random.Next(3, 11); // .Next(3, 11) means the minimum is 3 and the maximum is 10, since the upper limit is exclusive in C#.
            char[] word = new char[length];//This array will store each random letter before turning them into a full string.

            for (int j = 0; j < length; j++)  //if length = 7, the inner loop will add 7 random letters to build one full word . It builds a single word, letter by letter.
            {
                word[j] = chars[random.Next(chars.Length)];//random.Next(26) picks a random number from 0 to 25.
            }
            words[i] = new string(word); //It converts a character array (char[]) into a string, then stores it in the words array at index i.
                                         //word is a char[], like   //char[] word = { 'h', 'e', 'l', 'l', 'o' };
                                         //new string(word) takes that array and creates a full string from it:      //new string(word) → "hello"
                                         //words[i] = saves that string into the array words:      //words[0] = "hello"; words[1] = "world";
        }

        return words; // return the final list
    }

    static void TestPlusEqualsOperator(string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string result = "";
        for (int i = 0; i < words.Length; i++)
        {
            result += words[i];
        }
        sw.Stop();
        Console.WriteLine($"+= Operator with {words.Length} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringInterpolation(string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string result = "";
        for (int i = 0; i < words.Length; i++)
        {
            result = $"{result}{words[i]}";
        }
        sw.Stop();
        Console.WriteLine($"$Interpolation with {words.Length} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringBuilder(string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder(); //StringBuilder is not a regular string.its like Box: [a] [b] [c] [d] But this box isn't readable as one word unless you open it and get the full word out.
        for (int i = 0; i < words.Length; i++)
        {
            sb.Append(words[i]);
        }
        string sbResult = sb.ToString(); //What does .ToString() do? It converts the contents of the StringBuilder into a regular string.
        sw.Stop();
        Console.WriteLine($"StringBuilder.Append() with {words.Length} random words: {sw.Elapsed.TotalSeconds:F6} seconds{sbResult}");
    }

    static void TestStringJoin(string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string joinResult = string.Join("", words); // join all the list in one string
        sw.Stop();
        Console.WriteLine($"String.Join() with {words.Length} random words: {sw.Elapsed.TotalSeconds:F6} seconds ");
    }

    static void TestStringConcat(string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string concatResult = string.Concat(words); // concat all the list in one string
        sw.Stop();
        Console.WriteLine($"String.Concat() with {words.Length} random words: {sw.Elapsed.TotalSeconds:F6} seconds{Environment.NewLine}");
    }
}


/*  +=, string interpolation ($"{x}{y}"), and StringBuilder.Append() all build the final string one word at a time.
So we need to loop through each word in the list and add it to the result manually.*/

/* string.Join("", words) and string.Concat(words) are already designed to take an entire array of strings and join them in one line.
  Internally, these methods already loop through the array for you.*/