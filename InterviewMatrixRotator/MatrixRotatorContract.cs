using System;
using InterviewMatrixRotator.Contracts;
using System.Diagnostics.Contracts;

namespace InterviewMatrixRotator
{
	public class MatrixRotatorContract : IMatrixRotatorContract
	{
		public const int MatrixMaxColumnsCount = 300;
		public const int RMaxValue = 109;
		public const int ElementMinValue = 1;
		public const int ElementMaxValue = 108;

		public void ContractRequires(int[][] matrix, int r)
		{
			Contract.Requires<ArgumentOutOfRangeException>(matrix[0].Length <= MatrixMaxColumnsCount,
				InvalidColumnsCountMessage);

			Contract.Requires<ArgumentOutOfRangeException>(r <= RMaxValue, InvalidRMessage);

			Contract.Requires<ArgumentOutOfRangeException>(ValidateElements(matrix), InvalidElementMessage);
		}

		public bool ValidateElements(int[][] matrix)
		{
			foreach (var row in matrix)
			{
				foreach (var element in row)
				{
					if (element < ElementMinValue)
						return false;

					if (element > ElementMaxValue)
						return false;
				}
			}

			return true;
		}

		internal static readonly string InvalidColumnsCountMessage = string.Format("Matrix must have columns count <= {0}",
			MatrixMaxColumnsCount);

		internal static readonly string InvalidRMessage = string.Format("R must be <= {0}", RMaxValue);

		internal static readonly string InvalidElementMessage = string.Format("Matrix element must be >= {0} and <= {1}", ElementMinValue, ElementMaxValue);
	}
}
