using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewMatrixRotator.Contracts;

namespace InterviewMatrixRotator.UnitTests
{
	[TestClass]
	public class MatrixRotatorContractTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotatorContract_ContractRequires_Throws_ArgumentOutOfRangeException_InvalidColumnsCountMessage_When_Matrix_Columns_Count_Greater_Than_300()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new[]
			{
				new int[301]
			};

			try
			{
				matrixRotatorContract.ContractRequires(matrix, 1);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				if (ex.Message.Contains(MatrixRotatorContract.InvalidColumnsCountMessage))
					throw;
			}

			//assert - Assert is the exception
		}

		[TestMethod]
		public void MatrixRotatorContract_ContractRequires_Does_Not_Throw_ArgumentOutOfRangeException_InvalidColumnsCountMessage_When_Matrix_Columns_Count_Less_Than_Or_Equals_300()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new[]
			{
				new int[300]
			};

			var matrix1 = new[]
			{
				new int[299]
			};

			try
			{
				matrixRotatorContract.ContractRequires(matrix, 1);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				if (ex.Message.Contains(MatrixRotatorContract.InvalidColumnsCountMessage))
					throw;
			}


			try
			{
				matrixRotatorContract.ContractRequires(matrix1, 1);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				if (ex.Message.Contains(MatrixRotatorContract.InvalidColumnsCountMessage))
					throw;
			}

			//assert - No exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotatorContract_ContractRequires_Throws_ArgumentOutOfRangeException_When_R_Greater_Than_109()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new[]
			{
				new int[0]
			};

			matrixRotatorContract.ContractRequires(matrix, 110);

			//assert - Assert is the exception
		}

		[TestMethod]
		public void MatrixRotatorContract_ContractRequires_Does_Not_Throw_Exception_When_R_Less_Than_Or_Equals_109()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new []
			{
				new int[0]
			};

			matrixRotatorContract.ContractRequires(matrix, 109);
			matrixRotatorContract.ContractRequires(matrix, 108);

			//assert - No exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotatorContract_ContractRequires_Throws_ArgumentOutOfRangeException_When_Any_Element_Of_Matrix_Greater_Than_108()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new[]
			{
				new[] {109}
			};

			matrixRotatorContract.ContractRequires(matrix, 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		public void MatrixRotatorContract_ContractRequires_Does_Not_Throw_Exception_When_All_Element_Of_Matrix_Less_Than_Or_Equals_108()
		{
			var matrixRotatorContract = CreateMatrixRotatorContract();

			var matrix = new[]
			{
				new[] {108, 107}
			};

			matrixRotatorContract.ContractRequires(matrix, 1);

			//assert - No exception
		}

		private IMatrixRotatorContract CreateMatrixRotatorContract()
		{
			return new MatrixRotatorContract();
		}
	}
}
