using System;
using InterviewMatrixRotator.Contracts;

namespace InterviewMatrixRotator.ConsoleApp
{
	class Program
	{
		static readonly IMatrixRotator MatrixRotator = CreateMatrixRotator();

		static void Main(string[] args)
		{
			Console.WriteLine("--------------------------------------");

			var matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8},
				new[] {9, 10, 11, 12},
				new[] {13, 14, 15, 16}
			};
			RotateAndPrint(matrix, rotationsNumber: 1);

			matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8},
				new[] {9, 10, 11, 12},
				new[] {13, 14, 15, 16}
			};
			RotateAndPrint(matrix, rotationsNumber: 2);

			matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {7, 8, 9, 10},
				new[] {13, 14, 15, 16},
				new[] {19, 20, 21, 22},
				new[] {25, 26, 27, 28}
			};
			RotateAndPrint(matrix, rotationsNumber: 7);

			Console.ReadLine();
		}

		static IMatrixRotator CreateMatrixRotator()
		{
			return new MatrixRotator(new MatrixRotatorContract());
		}

		static void PrintMatrix(int[][] matrix)
		{
			foreach (var row in matrix)
			{
				foreach (var element in row)
				{
					Console.Write("{0} ", element.ToString().PadLeft(2));
				}
				Console.WriteLine();
			}
		}

		static void RotateAndPrint(int[][] matrix, int rotationsNumber)
		{
			PrintMatrix(matrix);
			Console.WriteLine("\nThe matrix is rotated {0} time{1}:\n", rotationsNumber,
				rotationsNumber == 1 ? string.Empty : "s");
			MatrixRotator.Rotate(matrix, rotationsNumber);
			PrintMatrix(matrix);
			Console.WriteLine("--------------------------------------");
		}
	}
}
