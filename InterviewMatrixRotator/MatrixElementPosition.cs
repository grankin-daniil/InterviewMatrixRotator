namespace InterviewMatrixRotator
{
	/// <summary>
	/// Represent position of element in a matrix
	/// </summary>
	class MatrixElementPosition
	{
		/// <summary>
		/// Create position of element in a matrix
		/// </summary>
		/// <param name="i">Index of row</param>
		/// <param name="j">Index of column</param>
		public MatrixElementPosition(int i, int j)
		{
			I = i;
			J = j;
		}

		/// <summary>
		/// Index of row
		/// </summary>
		public int I { get; private set; }

		/// <summary>
		/// Index of column
		/// </summary>
		public int J { get; private set; }

		public static bool operator ==(MatrixElementPosition p1, MatrixElementPosition p2)
		{
			return (object)p1 != null && p1.Equals(p2);
		}

		public static bool operator !=(MatrixElementPosition p1, MatrixElementPosition p2)
		{
			return !(p1 == p2);
		}

		protected bool Equals(MatrixElementPosition other)
		{
			return I == other.I && J == other.J;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((MatrixElementPosition)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (I*397) ^ J;
			}
		}
	}
}
