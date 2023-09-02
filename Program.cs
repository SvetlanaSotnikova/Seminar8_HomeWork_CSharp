// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// выполненно на семинаре

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
/*
int[,] CreateRandArr(int rows, int colums, int minVal, int maxVal)
{
    int[,] arr = new int[rows, colums];
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = new Random().Next(minVal, maxVal + 1);
    return arr;
}
void WriteArr(int[,] arr)
{
    Console.WriteLine();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            Console.Write($"{arr[i, j]} ");
        Console.WriteLine();
    }
}
void GetSumRows(int[,] arr)
{
    int minSum = 0;
    int indexRow = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j];
        }
        if (indexRow == 0 || sum <= minSum)
        {
            minSum = sum;
            indexRow = i;
        }
    }
    Console.WriteLine($"the minimum amount equal to {minSum} is on the line {indexRow + 1}"); // sorry for my english
}
Console.Write("Input a quantity of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a quantity of colums: ");
int colums = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a minVal: ");
int minVal = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a maxVal: ");
int maxVal = Convert.ToInt32(Console.ReadLine());

int[,] arr = CreateRandArr(rows, colums, minVal, maxVal);
WriteArr(arr);
GetSumRows(arr);
*/

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
/*
int[,] CreateRandArr()
{
    Console.Write("Input a quantity of rows: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input a quantity of colums: ");
    int colums = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input a minVal: ");
    int minVal = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input a maxVal: ");
    int maxVal = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    int[,] arr = new int[rows, colums];
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = new Random().Next(minVal, maxVal + 1);
    return arr;
}
void WriteArr(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            Console.Write($"{arr[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}
int[,] MultiplicationMatrixs(int[,] A, int[,] B)
{
    if (A.GetLength(0) == B.GetLength(1))
    {
        int[,] res = new int[A.GetLength(0), B.GetLength(1)];
        for (int i = 0; i < res.GetLength(0); i++)
        {
            for (int j = 0; j < res.GetLength(1); j++)
            {
                int sum = 0;
                for (int k = 0; k < A.GetLength(1); k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                res[i, j] = sum;
            }
        }
        return res;
    }
    else
    {
        Console.WriteLine("Incorrect size. Try again");
        return null;
    }
}
Console.WriteLine("Enter first matrix");
int[,] A = CreateRandArr();
Console.WriteLine("Enter second matrix");
int[,] B = CreateRandArr();
Console.WriteLine("First matrix:");
WriteArr(A);
Console.WriteLine("Second matrix:");
WriteArr(B);
Console.WriteLine("Result martix:");
int[,] res = MultiplicationMatrixs(A, B);
WriteArr(res);
*/

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
/*
int[,,] CreateArrRand(int rows, int colums, int index, int minVal, int maxVal)
{
    int[,,] arr = new int[rows, colums, index];
    int maxTrying = maxVal-minVal+1;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                int number = 0;

                while (maxTrying > 0) // была проблема бесконечного цикла если матрица больше чем 2х2х2, надеюсь такое ошибок не выдаст
                {
                    number = new Random().Next(minVal, maxVal + 1);
                    if (Math.Abs(number) > 9 && Math.Abs(number) < 100 && !ContainsValueArr(arr, number))
                    {
                        arr[i, j, k] = number;
                        break;
                    }
                }
                if (maxTrying <= 0) arr[i, j, k] = 0;
                maxTrying--;
            }
        }
    }
    return arr;
}
bool ContainsValueArr(int[,,] arr, int num)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (num == arr[i, j, k]) return true;
            }
        }
    }
    return false;
}
void GetPositionIndexOfElementsAndWriteArr(int[,,] arr)
{
    Console.WriteLine();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
                Console.Write($"{arr[i, j, k]}({i},{j},{k}) "); // в примере задания видимо была использованна последовательность i,k,j, но я не знаю насколькоправильно считать от второго индекса а не от последнего, поэтому поставлю по своему
            Console.WriteLine();
        }
    }
}

Console.Write("Input a quantity of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a quantity of colums: ");
int colums = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a quantity of index of elemet: "); // без понятия как это назвать
int index = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a minVal: ");
int minVal = Convert.ToInt32(Console.ReadLine());
Console.Write("Input a maxVal: ");
int maxVal = Convert.ToInt32(Console.ReadLine());

if (minVal < -99) minVal = -99;
if (maxVal > 99) maxVal = 99;
if ((Math.Abs(minVal) < 10) && (Math.Abs(maxVal) < 10) || (minVal > maxVal))
    Console.Write("There are no three-digit numbers in this interval !");
else
{
    int[,,] arr = CreateArrRand(rows, colums, index, minVal, maxVal);
    GetPositionIndexOfElementsAndWriteArr(arr);
}
*/

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

