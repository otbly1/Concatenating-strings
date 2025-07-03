using System;
using System.Diagnostics;
using System.Text;

class Program
{

    static void Main()
    {
        int count = 1000; // Set how many random words you want to concatenate

        TestPlusEqualsOperator(count);
        TestStringInterpolation(count);
        TestStringBuilder(count);
        TestStringJoin(count);
        TestStringConcat(count);
    }
    static Random random = new Random(); 


    static string GenerateRandomWord()
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";

        int length = random.Next(3, 11); //.Next(3, 11) means the minimum is 3 and the maximum is 10, since the upper limit is exclusive in C#.

        char[] word = new char[length];//This array will store each random letter before turning them into a full string.
        for (int i = 0; i < length; i++)//If length = 5, the loop will run while i is 0, 1, 2, 3, 4 (5 times in total) which is less than length .
        {
            word[i] = chars[random.Next(chars.Length)];//random.Next(26) picks a random number from 0 to 25.
        }

        return new string(word);//This converts that array into a string:
    }

    static void TestPlusEqualsOperator(int count)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += GenerateRandomWord();
        }
        sw.Stop();
        Console.WriteLine($"+= Operator with {count} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringInterpolation(int count)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result = $"{result}{GenerateRandomWord()}";
        }
        sw.Stop();
        Console.WriteLine($"$Interpolation with {count} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringBuilder(int count)
    {
        Stopwatch sw = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(GenerateRandomWord());
        }
        string sbResult = sb.ToString();
        sw.Stop();
        Console.WriteLine($"StringBuilder.Append() with {count} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringJoin(int count)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string[] words = new string[count];
        for (int i = 0; i < count; i++)
        {
            words[i] = GenerateRandomWord();
        }
        string joinResult = string.Join("", words);
        sw.Stop();
        Console.WriteLine($"String.Join() with {count} random words: {sw.Elapsed.TotalSeconds:F6} seconds");
    }

    static void TestStringConcat(int count)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string[] words = new string[count];
        for (int i = 0; i < count; i++)
        {
            words[i] = GenerateRandomWord();
        }
        string concatResult = string.Concat(words);
        sw.Stop();
        Console.WriteLine($"String.Concat() with {count} random words: {sw.Elapsed.TotalSeconds:F6} seconds{Environment.NewLine}");
    }
}
