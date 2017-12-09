namespace InterviewMatrixRotator.Contracts
{
	public interface IMatrixRotatorContract
	{
		/// <summary>
		/// Specifies a contract such that params must satisfy
		/// </summary>
		/// <param name="matrix">Initial matrix</param>
		/// <param name="r">Number of rotations</param>
		void ContractRequires(int[][] matrix, int r);
	}
}
