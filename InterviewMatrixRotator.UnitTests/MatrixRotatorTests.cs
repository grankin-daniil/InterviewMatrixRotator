using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewMatrixRotator.Contracts;

namespace InterviewMatrixRotator.UnitTests
{
	[TestClass]
	public class MatrixRotatorTests
	{
		#region MatrixRotator_Rotate_Throws tests
		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void MatrixRotator_Rotate_Throws_NullReferenceException_When_Matrix_Is_Null()
		{
			var matrixRotator = CreateMatrixRotator();

			matrixRotator.Rotate(null, 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotator_Rotate_Throws_ArgumentOutOfRangeException_When_Matrix_Rows_Count_Less_Than_2()
		{
			var matrixRotator = CreateMatrixRotator();

			matrixRotator.Rotate(new int[0][], 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void MatrixRotator_Rotate_Throws_NullReferenceException_When_Matrix_Has_Null_Row()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new int[2], 
				null
			};

			matrixRotator.Rotate(matrix, 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotator_Rotate_Throws_ArgumentOutOfRangeException_When_Matrix_Is_Jagged_Array()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new int[4], 
				new int[5]
			};

			matrixRotator.Rotate(matrix, 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotator_Rotate_Throws_ArgumentOutOfRangeException_When_R_Less_Than_1()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new int[2], 
				new int[2]
			};

			matrixRotator.Rotate(matrix, 0);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotator_Rotate_Throws_ArgumentOutOfRangeException_When_Array_Min_Dimension_Columns_Is_Not_Even()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new int[1],
				new int[1]
			};

			matrixRotator.Rotate(matrix, 1);

			//assert - Assert is the exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MatrixRotator_Rotate_Throws_ArgumentOutOfRangeException_When_Array_Min_Dimension_Rows_Is_Not_Even()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new int[4],
				new int[4],
				new int[4]
			};

			matrixRotator.Rotate(matrix, 1);

			//assert - Assert is the exception
		} 
		#endregion

		#region MatrixRotator_RotateLayer_R_Times_Success tests
		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Min_Allowable_Size()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2},
				new[] {3, 4}
			};

			matrixRotator.RotateLayer(matrix, 0, 3);

			var expected = new[]
			{
				new[] {3, 1},
				new[] {4, 2}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Single_Layer_And_N_Greater_M()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0}
			};

			matrixRotator.RotateLayer(matrix, 0, 3);

			var expected = new[]
			{
				new[] {4, 5, 0, 9, 8},
				new[] {3, 2, 1, 6, 7}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Single_Layer_And_M_Greater_N()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2},
				new[] {3, 4},
				new[] {5, 6},
				new[] {7, 8},
				new[] {9, 0}
			};

			matrixRotator.RotateLayer(matrix, 0, 3);

			var expected = new[]
			{
				new[] {6, 8},
				new[] {4, 0},
				new[] {2, 9},
				new[] {1, 7},
				new[] {3, 5}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Multiple_Layers_And_Layer_Is_External_And_N_Greater_M()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0},
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0}
			};

			matrixRotator.RotateLayer(matrix, 0, 5);

			var expected = new[]
			{
				new[] {0, 5, 0, 9, 8},
				new[] {5, 7, 8, 9, 7},
				new[] {4, 2, 3, 4, 6},
				new[] {3, 2, 1, 6, 1}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Multiple_Layers_And_Layer_Is_External_And_M_Greater_N()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8},
				new[] {9, 0, 1, 2},
				new[] {3, 4, 5, 6},
				new[] {7, 8, 9, 0}
			};

			matrixRotator.RotateLayer(matrix, 0, 9);

			var expected = new[]
			{
				new[] {8, 7, 3, 9},
				new[] {9, 6, 7, 5},
				new[] {0, 0, 1, 1},
				new[] {6, 4, 5, 2},
				new[] {2, 8, 4, 3}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Multiple_Layers_And_Layer_Is_Internal_And_N_Greater_M()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0},
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0}
			};

			matrixRotator.RotateLayer(matrix, 1, 5);

			var expected = new[]
			{
				new[] {1, 2, 3, 4, 5},
				new[] {6, 2, 7, 8, 0},
				new[] {1, 3, 4, 9, 5},
				new[] {6, 7, 8, 9, 0}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_RotateLayer_R_Times_Success_When_Matrix_Has_Multiple_Layers_And_Layer_Is_Internal_And_M_Greater_N()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8},
				new[] {9, 0, 1, 2},
				new[] {3, 4, 5, 6},
				new[] {7, 8, 9, 0}
			};

			matrixRotator.RotateLayer(matrix, 1, 5);

			var expected = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 0, 6, 8},
				new[] {9, 4, 7, 2},
				new[] {3, 5, 1, 6},
				new[] {7, 8, 9, 0}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}
		#endregion

		#region MatrixRotator_Rotate_Success tests
		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Single_Layer_And_R_Equals_To_Elements_Count()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2},
				new[] {3, 4}
			};

			matrixRotator.Rotate(matrix, 4);

			var expected = new[]
			{
				new[] {1, 2},
				new[] {3, 4}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Single_Layer_And_R_Equals_To_1()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2},
				new[] {3, 4}
			};

			matrixRotator.Rotate(matrix, 1);

			var expected = new[]
			{
				new[] {2, 4},
				new[] {1, 3}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Single_Layer_And_R_Greater_Than_Elements_Count()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2},
				new[] {3, 4}
			};

			matrixRotator.Rotate(matrix, 5);

			var expected = new[]
			{
				new[] {2, 4},
				new[] {1, 3}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Single_Layer_And_R_Has_No_Common_Divisor_With_Elements_Count()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8}
			};

			matrixRotator.Rotate(matrix, 5);

			var expected = new[]
			{
				new[] {7, 6, 5, 1},
				new[] {8, 4, 3, 2}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Single_Layer_And_R_Has_Common_Divisor_With_Elements_Count()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3},
				new[] {4, 5, 6}
			};

			matrixRotator.Rotate(matrix, 3);

			var expected = new[]
			{
				new[] {6, 5, 4},
				new[] {3, 2, 1}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Multiple_Layers_And_N_Greater_M()
		{
			var matrixRotator = CreateMatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0},
				new[] {1, 2, 3, 4, 5},
				new[] {6, 7, 8, 9, 0}
			};

			matrixRotator.Rotate(matrix, 5);

			var expected = new[]
			{
				new[] {0, 5, 0, 9, 8},
				new[] {5, 2, 7, 8, 7},
				new[] {4, 3, 4, 9, 6},
				new[] {3, 2, 1, 6, 1}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}

		[TestMethod]
		public void MatrixRotator_Rotate_Success_When_Matrix_Has_Multiple_Layers_And_M_Greater_N()
		{
			var matrixRotator = new MatrixRotator();

			var matrix = new[]
			{
				new[] {1, 2, 3, 4},
				new[] {5, 6, 7, 8},
				new[] {9, 0, 1, 2},
				new[] {3, 4, 5, 6},
				new[] {7, 8, 9, 0}
			};

			matrixRotator.Rotate(matrix, 9);

			var expected = new[]
			{
				new[] {8, 7, 3, 9},
				new[] {9, 5, 4, 5},
				new[] {0, 1, 0, 1},
				new[] {6, 7, 6, 2},
				new[] {2, 8, 4, 3}
			};

			Assert.IsTrue(AreEqual(matrix, expected));
		}
		#endregion

		private IMatrixRotator CreateMatrixRotator()
		{
			return new MatrixRotator();
		}

		private bool AreEqual(int[][] matrix1, int[][] matrix2)
		{
			for (var i = 0; i < matrix1.Length; ++i)
			{
				for (int j = 0; j < matrix1[i].Length; ++j)
				{
					if (matrix1[i][j] != matrix2[i][j])
						return false;
				}
			}

			return true;
		}
	}
}
