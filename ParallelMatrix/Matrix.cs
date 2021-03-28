using System.Runtime.CompilerServices;
using System.Text;

namespace ParralelMatrix
{
    public class Matrix
    {
        private int[,] _data;

        public int Size { get; set; }

        public Matrix(int size)
        {
            Size = size;
            _data = new int[size, size];
        }

        public int this[int x, int y]
        {
            get => _data[x, y];
            set => _data[x, y] = value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                builder.Append("[ ");
                for (int j = 0; j < Size; j++)
                {
                    builder.Append(_data[i, j]);

                    builder.Append(j == Size - 1 ? " " : ", ");
                }

                builder.AppendLine("]");
            }

            return builder.ToString();
        }
    }
}