using System;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main()
    {
        int[] drawNumbers = DrawNumbers();
        int[] chosenNum = RequestNumbers(drawNumbers.Length);
        CompareNumbers(chosenNum, drawNumbers, drawNumbers.Length);


    }

    public static int[] RequestNumberToDraw()
    {

        bool isValid = false;
        int x  = 0;

        while (!isValid) {

            Console.WriteLine("How many numbers do you want to draw?");
            var readString = Console.ReadLine()!;
            
            bool y = int.TryParse(readString, out x);

            if (y == true)
            {
                Console.WriteLine($"You selected {x} times to draw \n");
                isValid = true;
            }
            else
            {
                Console.WriteLine($"{readString} is not a valide integer number \n");
            }
        }


        int[] resp = new int[x];

        return resp;
    }
    
    public static int[] DrawNumbers()
    {
        int[] answer = RequestNumberToDraw();

        Random numRdm = new Random();

        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = numRdm.Next(1,20);
        }

        return answer;
    }

    public static int[] RequestNumbers(int x)
    {
        int[] chosenNum = new int[x];

        for (int i = 0; i < x; i++)
        {
            Console.WriteLine($"Chose {x} numbers beteween 1 to 10");
            var answer = Console.ReadLine()!;
            int y;
            bool b = int.TryParse(answer, out y);

            if (b == true && y < 10)
            {
                chosenNum[i] = y;
            }
            else
            {
                Console.WriteLine($"{answer} is not a number or is bigger then 10, restart");
                i--;
            }
        }
        return chosenNum;
    }

    public static void CompareNumbers(int[] numDraw, int[] chosenNum, int x)
    {
        var comunNum = numDraw.Intersect(chosenNum);
        int equals = comunNum.Count();

        if (equals == x)
        {
            Console.WriteLine($"You got all the numbers right / {equals}");
        }
        else
        {
            Console.WriteLine($"You just got it right {equals}");
        }
    }

}