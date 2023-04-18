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
        /// <summary>
        /// Данные матрицы
        /// </summary>
        public char[,] Data { get; private set; }

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        /// <param name="_rows">Количество строк</param>
        /// <param name="_columns">Количество колонок</param>
        public Matrix(int _rows, int _columns)
        {
            Rows = _rows;
            Columns = _columns;
            Data = new char[Rows, Columns];
        }

        /// <summary>
        /// Метод для конвертации в двоичную систему согласно нужно разрядности
        /// </summary>
        /// <param name="_number">Число, которое нужно перевести</param>
        /// <param name="_N">Какой разрядности должно быть конечное число</param>
        /// <returns>Возвращает число в двоичной системе в нужной разрядности</returns>
        public static string ConvertToBinary(int _number, int _N)
        {
            string binaryNumber = Convert.ToString(_number, 2);
            int distance;

            if (binaryNumber.Length == _N) 
                return binaryNumber;

            distance = _N - binaryNumber.Length;
            return binaryNumber.PadLeft(binaryNumber.Length + distance, '0');
        }
        /// <summary>
        /// Проверяет, является ли степенью двойки число
        /// </summary>
        /// <param name="n">Проверяемое число</param>
        /// <returns>Возвращает true или false</returns>
        public static bool IsPowerOfTwo(int n)
        {
            return (int)(Math.Ceiling((Math.Log(n) / Math.Log(2))))
                  == (int)(Math.Floor(((Math.Log(n) / Math.Log(2)))));
        }

        /// <summary>
        /// 
        /// </summary>
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
                if (IsPowerOfTwo(number))
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

    public class MatrixH : Matrix
    {
        public MatrixH(int _rows, int _columns) : base(_rows, _columns) { }

        public void MakeSimpleMatrix()
        {
            int number = 3; // Стартовое число, с которого начинает заполняться матрица, т.к. 1 и 2 являются степенями двойки
            int powerOfTwo = 0; // Степень для двойки; степень 0 => 2^0 => 1

            string binaryNumber; // Переменная для записи числа в бинарном виде

            // Сначала заполняем часть, которая является единичной матрицой
            // Эта часть находится в конце, соответственно заполнение начинается с конца
            // "Columns - 1" - последний столбец, и так структура кода (n,k), то зака
            for (int i = Columns - 1; i >= Rows; i--)
            {
                binaryNumber = ConvertToBinary((int)Math.Pow(2, powerOfTwo), Rows);
                for (int j = 0; j < Rows; j++)
                {
                    Data[j, i] = binaryNumber[j];
                }

                powerOfTwo++;
            }


            for (int i = 0; i < Columns - Rows; i++)
            {
                binaryNumber = ConvertToBinary(number, Rows);

                for (int j = 0; j < Rows; j++)
                {
                    Data[j, i] = binaryNumber[j];
                }

                number++;
                if (IsPowerOfTwo(number))
                {
                    number++;
                }
            }
        }
    }

    public class MatrixG : Matrix
    {
        public MatrixG(int _rows, int _columns) : base(_rows, _columns) { }

    }
}
