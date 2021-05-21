//Ahmet Yiğit Arıtürk
using System;


namespace TechnicalAssignment
{
    public static class Program
    {

        private const string input = @"215
193 124
117 237 442
218 935 347 235
320 804 522 417 345
229 601 723 835 133 124
248 202 277 433 207 263 257
359 464 504 528 516 716 871 182
461 441 426 656 863 560 380 171 923
381 348 573 533 447 632 387 176 975 449
223 711 445 645 245 543 931 532 937 541 444
330 131 333 928 377 733 017 778 839 168 197 197
131 171 522 137 217 224 291 413 528 520 227 229 928
223 626 034 683 839 053 627 310 713 999 629 817 410 121
924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";


        public static void Main(string[] args)
        {

            Console.WriteLine("Result: " + MoveFunction(RemovePrimeNumbers(convertToMatrix(input))));

        }


        private static int MoveFunction(int[,] matrixOfTriangle)
        {

            int lines = matrixOfTriangle.GetLength(0);
            


            for (int i = (lines - 2); i >= 0; i--)
            {
                for (int j = 0; j < (lines - 1); j++)
                {
                    int temp= calculateMaxValue(matrixOfTriangle[i + 1, j], matrixOfTriangle[i + 1, j + 1]);
                    if (temp == -1)
                    {
                        matrixOfTriangle[i, j] = -1;
                    }
                    else
                    {
                        matrixOfTriangle[i, j] += temp;
                    }
                        
                }
            }
            return matrixOfTriangle[0,0];
        }


        private static int calculateMaxValue(int number1, int number2)  //returns max value
        {
            if (number1 == -1 && number2 == -1 || number1 == 0 && number2 == 0)
                return -1;
            else
                return Math.Max(number1, number2);
        }

        private static int[,] RemovePrimeNumbers(int[,] matrixOfTriangle)
        {

            int lines = matrixOfTriangle.GetLength(0);
            for (int i = 0; i <lines; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    if (IsPrime(matrixOfTriangle[i,j]))
                    {
                        matrixOfTriangle[i, j] = -1; // replaces prime numbers with -1
                    }
                }
            }

            return matrixOfTriangle;
        }


        private static bool IsPrime(int number)
        {
            if (number == 1 || number == 0)
            {
                return false;
            }

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }


        private static int[,] convertToMatrix(string value)
        {
            var charArray = value.Split('\n');
            int[,] matrixOfTriangle = new int[charArray.Length, charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                var numArr = charArray[i].Trim().Split(' ');

                for (int j = 0; j < numArr.Length; j++)
                {
                    int number = Convert.ToInt32(numArr[j]);
                    matrixOfTriangle[i, j] = number;
                }
            }
            return matrixOfTriangle;
        }

    }
}

