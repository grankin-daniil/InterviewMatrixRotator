using System.Linq;
using System.Threading.Tasks;
using InterviewMatrixRotator.Contracts;
using System;
using System.Diagnostics.Contracts;

namespace InterviewMatrixRotator
{
	public class MatrixRotator : IMatrixRotator
	{
		private const int MatrixMinRowsCount = 2;
		private const int RMinValue = 1;

		//User message to contract call can only be string literal, or a static field, or static property that is at least internally visible
		private static readonly string InvalidRowsCountMessage = string.Format("Matrix must have rows count >= {0}",
			MatrixMinRowsCount);

		private static readonly string InvalidRMessage = string.Format("R must be >= {0}", RMinValue);

		private readonly IMatrixRotatorContract _matrixRotatorContract;

		public MatrixRotator()
		{
			
		}

		/// <summary>
		/// Creates new MatrixRotator with contracts for matrix rotation params
		/// </summary>
		/// <param name="matrixRotatorContract">Contracts for matrix rotation params</param>
		public MatrixRotator(IMatrixRotatorContract matrixRotatorContract)
		{
			_matrixRotatorContract = matrixRotatorContract;
		}

		/// <summary>
		/// Rotates a matrix r times in place.
		/// </summary>
		/// <param name="matrix">Initial matrix</param>
		/// <param name="r">Number of rotations</param>
		/// <returns>Rotated matrix</returns>
		public int[][] Rotate(int[][] matrix, int r)
		{
			ContractRequires(matrix, r);
			if (_matrixRotatorContract != null)
				_matrixRotatorContract.ContractRequires(matrix, r);

			var layersCount = Math.Min(matrix.Length, matrix[0].Length)/2;
			Parallel.ForEach(Enumerable.Range(0, layersCount),
				layerIndex => RotateLayer(matrix, layerIndex, r));

			return matrix;
		}

		private void ContractRequires(int[][] matrix, int r)
		{
			Contract.Requires<NullReferenceException>(matrix != null,
				"Matrix can not be null");

			Contract.Requires<ArgumentOutOfRangeException>(matrix.Length >= MatrixMinRowsCount,
				InvalidRowsCountMessage);

			Contract.Requires<ArgumentOutOfRangeException>(matrix.Select(x => x.Length).Distinct().Count() == 1, 
				"Matrix can not be jagged array");

			Contract.Requires<ArgumentOutOfRangeException>(r >= RMinValue, InvalidRMessage);

			Contract.Requires<ArgumentOutOfRangeException>(Math.Min(matrix.Length, matrix[0].Length) % 2 == 0,
				"The smaller of rows count, columns count must be even or 0");
		}

		/// <summary>
		/// Rotates a layer r times clockwise in place
		/// </summary>
		/// <param name="matrix">Matrix with rotating layer</param>
		/// <param name="layerIndex">Index of rotating layer</param>
		/// <param name="r">Number of rotations</param>
		internal void RotateLayer(int[][] matrix, int layerIndex, int r)
		{
			var layer = new MatrixLayer(matrix, layerIndex);
			r = r%layer.ElementsCount;

			if (r == 0)
			{
				return;
			}

			var movingElement = layer.TopLeftCorner;
			var movingElementValue = layer.Matrix[movingElement.I][movingElement.J];

			var moveFrom = movingElement;

			for (var i = 0; i < layer.ElementsCount; ++i)
			{
				var shiftedElement = GetPositionOfLayerElementShiftedCounterclockwise(layer, r, movingElement);
				if (moveFrom == shiftedElement)
				{
					movingElement = GetPositionOfLayerElementShiftedCounterclockwise(layer, 1, shiftedElement);
					moveFrom = movingElement;
				}
				else
				{
					movingElement = shiftedElement;
				}

				var nextMovingElementValue = layer.Matrix[movingElement.I][movingElement.J];
				layer.Matrix[shiftedElement.I][shiftedElement.J] = movingElementValue;
				movingElementValue = nextMovingElementValue;
			}
		}

		/// <summary>
		/// Get position of matrix element shifted in layer in counterclockwise direction
		/// </summary>
		/// <param name="matrixLayer">Layer of matrix that contains moving element</param>
		/// <param name="shifts">Number of shifts</param>
		/// <param name="shiftedFrom">Position of moving element</param>
		/// <returns>Position of shifted element</returns>
		private MatrixElementPosition GetPositionOfLayerElementShiftedCounterclockwise(MatrixLayer matrixLayer, int shifts,
			MatrixElementPosition shiftedFrom)
		{
			int substitutedElementPositionI;
			int substitutedElementPositionJ;

			while (true)
			{
				if (shiftedFrom.J == matrixLayer.TopLeftCorner.J && shiftedFrom.I != matrixLayer.BottomLeftCorner.I)
				{
					if (shiftedFrom.I + shifts <= matrixLayer.BottomLeftCorner.I)
					{
						substitutedElementPositionI = shiftedFrom.I + shifts;
						substitutedElementPositionJ = shiftedFrom.J;
						break;
					}

					shifts -= matrixLayer.BottomLeftCorner.I - shiftedFrom.I;
					shiftedFrom = matrixLayer.BottomLeftCorner;
					continue;
				}

				if (shiftedFrom.I == matrixLayer.BottomLeftCorner.I && shiftedFrom.J != matrixLayer.BottomRightCorner.J)
				{
					if (shiftedFrom.J + shifts <= matrixLayer.BottomRightCorner.J)
					{
						substitutedElementPositionI = shiftedFrom.I;
						substitutedElementPositionJ = shiftedFrom.J + shifts;
						break;
					}

					shifts -= matrixLayer.BottomRightCorner.J - shiftedFrom.J;
					shiftedFrom = matrixLayer.BottomRightCorner;
					continue;
				}

				if (shiftedFrom.J == matrixLayer.BottomRightCorner.J && shiftedFrom.I != matrixLayer.TopRightCorner.I)
				{
					if (shiftedFrom.I - shifts >= matrixLayer.TopRightCorner.I)
					{
						substitutedElementPositionI = shiftedFrom.I - shifts;
						substitutedElementPositionJ = shiftedFrom.J;
						break;
					}

					shifts -= shiftedFrom.I - matrixLayer.TopRightCorner.I;
					shiftedFrom = matrixLayer.TopRightCorner;
					continue;
				}

				if (shiftedFrom.J - shifts >= matrixLayer.TopLeftCorner.J)
				{
					substitutedElementPositionI = shiftedFrom.I;
					substitutedElementPositionJ = shiftedFrom.J - shifts;
					break;
				}

				shifts -= shiftedFrom.J - matrixLayer.TopLeftCorner.J;
				shiftedFrom = matrixLayer.TopLeftCorner;
			}

			return
				new MatrixElementPosition(substitutedElementPositionI, substitutedElementPositionJ);
		}
	}
}
