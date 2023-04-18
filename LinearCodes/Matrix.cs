using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodes

{
    public class Matrix
    {
        /// <summary>
        /// N - количество строк в матрице
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// K - количество столбцов в матрице
        /// </summary>
        public int Columns { get; private set; }

        public char[,] Data { get; set; }



        public Matrix(int _rows, int _columns)
        {
            Rows= _rows;
            Columns= _columns;
            Data = new char[Rows, Columns];
        }

        public string ConvertToBinary(int _number, int _N)
        {
            string binaryNumber = Convert.ToString(_number, 2);
            int distance;

            if (binaryNumber.Length == _N) 
                return binaryNumber;

            distance = _N - binaryNumber.Length;
            return binaryNumber.PadLeft(binaryNumber.Length + distance, '0');
        }

        public bool isPowerOfTwo(int n)
        {
            return (int)(Math.Ceiling((Math.Log(n) / Math.Log(2))))
                  == (int)(Math.Floor(((Math.Log(n) / Math.Log(2)))));
        }

        public void MakeSimpleHMatrix()
        {
            int number = 3;
            int powerOfTwo = 0;

            string binaryNumber;

            for (int i = Columns - 1; i >= Rows; i--)
            {
                binaryNumber = ConvertToBinary((int)Math.Pow(2, powerOfTwo), Rows);
                for (int j = 0; j < Rows; j++)
                {
                    Data[j, i] = binaryNumber[j];
                }

                powerOfTwo++;
            }


            for(int i = 0; i < Columns - Rows; i++)
            {
                binaryNumber = ConvertToBinary(number, Rows);

                for (int j = 0; j < Rows; j++)
                {
                    Data[j, i] = binaryNumber[j];
                }

                number++;
                if (isPowerOfTwo(number))
                {
                    number++;
                }
            }
        }

        public void MakeSimpleGMatrix(Matrix _hMatrix) 
        {
            int powerOfTwo = 0;

            string binaryNumber;

            int hMatrixRow = 0;

            int columnToStart = Columns - _hMatrix.Rows - 1;

            for (int i = 0; i <= columnToStart; i++)
            {
                binaryNumber = ConvertToBinary((int)Math.Pow(2, powerOfTwo), Rows);
                for (int j = 0; j < Rows; j++) //_hMatrix.Columns - _hMatrix.Rows
                {
                    Data[j, i] = binaryNumber[Rows-1-j];
                    //Console.Write("{0} ", Data[j, i]);
                }
                //Console.WriteLine();

                powerOfTwo++;
            }

            for (int i = columnToStart+1; i < Columns; i++) // for (int i = (_hMatrix.Rows + 1); i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Data[j,i] = _hMatrix.Data[hMatrixRow, j];
                    //Console.Write("{0} ", Data[j, i]);
                }
                hMatrixRow++;
               // Console.WriteLine();
            }            
        }
    }

    public class MatrixG : Matrix
    {
        
    }
}
