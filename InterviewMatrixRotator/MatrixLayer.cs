namespace InterviewMatrixRotator
{
	class MatrixLayer
	{
		/// <summary>
		/// Creates layer of a matrix
		/// </summary>
		/// <param name="matrix">Matrix that contains layer</param>
		/// <param name="layer">Index of layer in a matrix</param>
		public MatrixLayer(int[][] matrix, int layer)
		{
			Matrix = matrix;

			var rowsCountLayerContains = matrix.Length - layer * 2;
			var columnsCountLayerContains = matrix[0].Length - layer * 2;

			TopLeftCorner = new MatrixElementPosition(layer, layer);
			BottomLeftCorner = new MatrixElementPosition(rowsCountLayerContains - 1 + layer, layer);
			BottomRightCorner = new MatrixElementPosition(rowsCountLayerContains - 1 + layer,
				columnsCountLayerContains - 1 + layer);
			TopRightCorner = new MatrixElementPosition(layer, columnsCountLayerContains - 1 + layer);

			ElementsCount = (rowsCountLayerContains + columnsCountLayerContains - 2) * 2;
		}

		public int[][] Matrix { get; private set; }

		/// <summary>
		/// Top left corner position of layer
		/// </summary>
		public MatrixElementPosition TopLeftCorner { get; private set; }

		/// <summary>
		/// Bottom left corner position of layer
		/// </summary>
		public MatrixElementPosition BottomLeftCorner { get; private set; }

		/// <summary>
		/// Bottom right corner position of layer
		/// </summary>
		public MatrixElementPosition BottomRightCorner { get; private set; }

		/// <summary>
		/// Top right corner position of layer
		/// </summary>
		public MatrixElementPosition TopRightCorner { get; private set; }

		/// <summary>
		/// Count of elements in a layer
		/// </summary>
		public int ElementsCount { get; private set; }
	}
}
