using System;
using System.Diagnostics;
using InterviewMatrixRotator.Contracts;

namespace InterviewMatrixRotator.PerfomanceTests
{
	class Program
	{
		const int Repetitions = 1000;

		static readonly IMatrixRotator MatrixRotator = CreateMatrixRotator();

		static void Main(string[] args)
		{
			var matrix = GenerateMatrix();

			//warm up
			for (var i = 0; i < Repetitions; i++)
			{
				MatrixRotator.Rotate(matrix, MatrixRotatorContract.RMaxValue / 2);
			}

			RunRotations(matrix, MatrixRotatorContract.RMaxValue / 2 - 1);
			RunRotations(matrix, 1);
			RunRotations(matrix, MatrixRotatorContract.RMaxValue - 1);

			Console.WriteLine();
		}

		static int[][] GenerateMatrix()
		{
			var matrix = new int[MatrixRotatorContract.MatrixMaxColumnsCount][];
			for (var i = 0; i < MatrixRotatorContract.MatrixMaxColumnsCount; i++)
			{
				matrix[i] = new int[MatrixRotatorContract.MatrixMaxColumnsCount];
				for (var j = 0; j < matrix[i].Length; j++)
				{
					matrix[i][j] = new Random(i + j).Next(MatrixRotatorContract.ElementMinValue, MatrixRotatorContract.ElementMaxValue);
				}
			}
			return matrix;
		}

		static void RunRotations(int[][] matrix, int r)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Reset();
			stopwatch.Start();
			for (var i = 0; i < Repetitions; i++)
			{
				MatrixRotator.Rotate(matrix, 1);
			}
			stopwatch.Stop();
			Console.WriteLine("Rotations of matrix {0}*{1} with r = {2} takes {3} milliseconds", matrix.Length, matrix[0].Length, r, stopwatch.Elapsed.TotalMilliseconds / Repetitions);
		}

		static IMatrixRotator CreateMatrixRotator()
		{
			return new MatrixRotator(new MatrixRotatorContract());
		}
	}
}
