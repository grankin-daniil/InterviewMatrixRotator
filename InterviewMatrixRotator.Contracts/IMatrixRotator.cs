namespace InterviewMatrixRotator.Contracts
{
    public interface IMatrixRotator
    {
        /// <summary>
        /// Rotates a matrix r times.
        /// </summary>
        /// <param name="matrix">Initial matrix</param>
        /// <param name="r">Number of rotations</param>
        /// <returns>Rotated matrix</returns>
        int[][] Rotate(int[][] matrix, int r);
    }
}
