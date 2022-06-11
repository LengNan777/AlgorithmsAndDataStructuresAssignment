using System;

/*Ask strings from user and call compressString() fucntion with it.
All Console.WriteLine() method in this project just for convenience to check.*/
Console.WriteLine("Please Enter some capital letters: ");
string toCompressString = Console.ReadLine();
compressString(toCompressString);

//Ask strings from user and call deCompressString() fucntion with it.
Console.WriteLine("Please Enter some capital letters and numbers: ");
string toDecompressString = Console.ReadLine();
decompressString(toDecompressString);

//This function accepts a string as parameter, and returns a string whose consective letters would be replaced by number.
string compressString(string str)
{
    //Create a char array with same size of length of entered string for store compressed chars.
    char[] chars = new char[str.Length];
    //Record last appear letter.
    char lastChar = '.';
    //Record the times of last letter appear continuely.
    int counter = 1;
    //The index of new char to ensure every letter could be added to the right place of new char array.
    int j = 0;

    //According whether the letter is same to the last one, do different things.
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == lastChar)
        {
            counter++;
            if (counter >= 3)
            {
                chars[j-1] = char.Parse(counter.ToString());
                j--;
            }
            else
            {
                chars[j] = str[i];
            }
        }
        else
        {
            chars[j] = str[i];
            lastChar = str[i];
            counter = 1;
        }
        j++;   
    }

    //Transfer char arrays to string and return it.
    string charString = new string(chars);
    Console.WriteLine(charString);
    return charString;
}

//This function accepts a string as parameter, and returns a string whose number part would be replaced by consective letters.
string decompressString(string str)
{
    //Transfer entered string to an array.
    char[] originChars = str.ToCharArray();
    //Create a new char array to store letters in decompressed string.
    char[] decompressedChars = new char[50];
    //Record last appear letter.
    char lastChar = '.';
    //The index of new char to ensure every letter could be added to the right place of new char array.
    int j = 0;

    /*Transfer every letter in origin char array to new one.
    When there is a number, transfer it to the appropriate amount of last appear number.*/
    for (int i = 0;i < originChars.Length; i++)
    {
        if (Char.IsDigit(originChars[i]))
        {
            int charInt = int.Parse(originChars[i].ToString());
            while(charInt > 1)
            {
                decompressedChars[j] = lastChar;
                j++;
                charInt--;
            }
        }
        else
        {
            decompressedChars[j] = originChars[i];
            lastChar= originChars[i];
            j++;
        }       
    }

    //Transfer char arrays to string and return it.
    string decompressedString = new string(decompressedChars);
    Console.WriteLine(decompressedString);
    return decompressedString;
}