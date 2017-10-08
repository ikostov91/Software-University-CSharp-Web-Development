using System;

public class SubstringBroken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char Search = (char)112;
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;

                int endIndex = jump;

                if (endIndex > (text.Length - i - 1))
                {
                    endIndex = text.Length - i - 1;
                }

                // Substring Method parameters are start index and length of string

                string matchedString = text.Substring(i, endIndex + 1);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
