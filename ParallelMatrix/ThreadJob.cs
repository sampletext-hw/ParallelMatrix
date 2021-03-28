using System.Threading;

namespace ParralelMatrix
{
    // Class for one thread job
    public class ThreadJob
    {
        public Matrix Matrix1 { get; set; }
        public Matrix Matrix2 { get; set; }
        public Matrix MatrixResult { get; set; }
        
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        
        // Mutex for current job
        private Mutex _mutex;

        // Thread for current job
        private Thread _thread;

        public ThreadJob(Matrix matrix1, Matrix matrix2, Matrix matrixResult, int startIndex, int endIndex)
        {
            Matrix1 = matrix1;
            Matrix2 = matrix2;
            MatrixResult = matrixResult;
            StartIndex = startIndex;
            EndIndex = endIndex;
            _mutex = new Mutex();
        }

        // Method which starts current job
        public void Run()
        {
            _thread = new Thread(ThreadRoutine);
            _thread.Start();
        }

        // Actual thread job
        private void ThreadRoutine()
        {
            // wait for resource (not actually necessary)
            _mutex.WaitOne();
            
            // for each cell in given indicies
            for (int index = StartIndex; index < EndIndex; index++)
            {
                // calculate cell location
                int i = index / Matrix1.Size;
                int j = index % Matrix1.Size;
                
                // perform normal multiplication for a single cell
                MatrixResult[i, j] = 0;
                for (int k = 0; k < MatrixResult.Size; k++)
                {
                    MatrixResult[i, j] += Matrix1[i, k] * Matrix2[k, j];
                }
            }
            
            // release the acquired resource
            _mutex.ReleaseMutex();
        }

        // Method to wait for current job to finish
        public void Wait()
        {
            _mutex.WaitOne();
            _thread.Join();
        }
    }
}