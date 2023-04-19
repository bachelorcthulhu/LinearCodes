using LinearCodes;


Code testCode = new Code(14);
testCode.GetCodeInfo();

int rows = testCode.SimpleHMatrixRows; //3
int columns = testCode.SimpleHMatrixColumns; //7

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


rows = testCode.SimpleGMatrixRows; //4
columns = testCode.SimpleGMatrixColumns; //7

Matrix matrixG = new Matrix(rows, columns);
matrixG.MakeSimpleGMatrix(matrixH);

MatrixG testMatrixG = new MatrixG(rows, columns);
testMatrixG.MakeSimpleMatrix(matrixH);



for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write("{0} ", matrixG.Data[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine();


for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write("{0} ", matrixG.Data[i, j]);
    }
    Console.WriteLine();
}