using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SeminarOne
{
    internal class Program
    {
        private static int[,] matrix;
        private static int N;
        static Stack<int[]> stack = new Stack<int[]>();
        public static void Main(string[] args)
        {
            CreateMatrix(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Вид матрицы До");
            ShowMatrix(matrix);
            Console.WriteLine("Вид матрицы После");
            FillMatrix(matrix, 2, 2);
            ShowMatrix(matrix);
            Count(matrix);
        }

        static void CreateMatrix(int N)
        {
            matrix = new int[N, N];
            Random rnd = new Random(4);
            for (int i=0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Convert.ToInt32(rnd.Next(0, 4)) == 3)
                        matrix[i, j] = 1;
                }
            }
        }
        static void ShowMatrix(int[,] matrix)
        {
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                for (int j=0;j<matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void FillMatrix(int[,] matrix, int x, int y)
        {
            const byte c = 2;
            stack.Push(new[] { x, y });
            while (stack.Count > 0)
            {
                int[] tmp = stack.Pop();
                if (tmp[0] >= 0 && tmp[1] >= 0 && tmp[0] < matrix.GetLength(0) &&
                    tmp[1] < matrix.GetLength(0) &&
                    matrix[tmp[0], tmp[1]] == 0)
                {
                    matrix[tmp[0], tmp[1]] = c;
                    stack.Push(new[] { tmp[0], tmp[1] - 1 });
                    stack.Push(new[] { tmp[0] - 1, tmp[1] });
                    stack.Push(new[] { tmp[0], tmp[1] + 1 });
                    stack.Push(new[] { tmp[0] + 1, tmp[1] });
                }
            }
        }

        static void Count(int[,] matrix)
        {
            byte a = 0;
            byte b = 0;
            byte c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 1)
                        a++;
                    if (matrix[i, j] == 2)
                        b++;
                    if (matrix[i, j] == 0)
                        c++;
                }
            }

            Console.WriteLine("Кол-во единиц: " + a);
            Console.WriteLine("Кол-во двоек: " + b);
            Console.WriteLine("Кол-во нулей: " + c);
            Console.WriteLine();
        }


    }
}
