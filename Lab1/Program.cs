
using Lab1;
using System;

int[] nums1 = { 1, 3 };
int[] nums2 = { 2 };

// Problem 1
double result = MedianOfTwoSortedArrays
    .FindMedianSortedArrays(nums1, nums2);

Console.WriteLine(result);

// Problem 2
int num1 = -12;
int num2 = -2;

int problem2Result = DivideTwoIntegers.Divide(num1, num2);

Console.WriteLine(problem2Result);

// Problem 3
char[][] board =
{
    new char[] { 'A', 'B', 'C', 'E' },
    new char[] { 'S', 'F', 'C', 'S' },
    new char[] { 'A', 'D', 'E', 'E' }
};

Console.WriteLine(WordSearch.Exist(board, "ABCCED"));
Console.WriteLine(WordSearch.Exist(board, "SEE"));
Console.WriteLine(WordSearch.Exist(board, "ABCB"));