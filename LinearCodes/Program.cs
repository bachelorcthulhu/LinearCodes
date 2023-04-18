using LinearCodes;

int rows = 3; //3
int columns = 7; //7

Matrix matrixH = new Matrix(rows, columns);
matrixH.MakeSimpleHMatrix();

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write("{0} ", matrixH.Data[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine();

rows = 4; //4
columns = 7; //7

Matrix matrixG = new Matrix(rows, columns);
matrixG.MakeSimpleGMatrix(matrixH);



for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write("{0} ", matrixG.Data[i, j]);
    }
    Console.WriteLine();
}
