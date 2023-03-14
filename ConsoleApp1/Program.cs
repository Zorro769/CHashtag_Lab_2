
class IntSauadMatrix 
{
    int[,] matrix;
    public int ColAndRows { get; set; }
    public  IntSauadMatrix(int count)
    {
        matrix = new int[count, count];
        ColAndRows = matrix.GetLength(0);
    }
    public void FillMatrixRandomly(int min,int max)
    {
        Random rand = new Random();
        for(int i =0;i < ColAndRows;i++)
        {
            for(int j =0;j < ColAndRows;j++)
            {
                matrix[i,j] = rand.Next(min,max + 1);
            }
        }
    }
    public void ShowMatrix()
    {
        for (int i = 0; i < ColAndRows; i++)
        {
            for (int j = 0; j < ColAndRows; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void SortMatrixByChrctrstc()
    {
        int[] characteristics = new int[ColAndRows];
        int[][] columns = new int[ColAndRows][];
        
        for(int j =0;j < ColAndRows;j++)
        {
            int sum = 0;
            int[] column = new int[ColAndRows];
            for (int i=0;i < ColAndRows;i++)
            {
                if ((matrix[i, j] % 2 != 0) && (matrix[i,j] < 0))
                    sum += Math.Abs(matrix[i, j]);
                column[i] = matrix[i,j];
            }
            characteristics[j] = sum;
            columns[j] = column;
            Console.WriteLine("Characteristik for {0} column: {1}",j + 1,sum);
        }
        for (int i = 0; i < ColAndRows - 1; i++)
        {
            for (int j = i + 1; j < ColAndRows; j++)
            {

                if (characteristics[i] > characteristics[j])
                {
                    int tempValue = characteristics[i];
                    characteristics[i] = characteristics[j];
                    characteristics[j] = tempValue;
                    int[] tempCol = columns[i];
                    columns[i] = columns[j];
                    columns[j] = tempCol; 
                }
            }
        }
        for(int i = 0;i < ColAndRows;i++)
        {
            int[] column = columns[i];
            for(int j = 0; j < ColAndRows;j++)
            {
                matrix[j, i] = column[j];
            }
        }
        Console.WriteLine();
        ShowMatrix();

        
    }
    public void SumIfNegInColumns()
    {
        int[] sum = new int[ColAndRows];
        for (int i = 0; i < ColAndRows; i++)
        {
            bool flagNeg = false;
            for (int j = 0; j < ColAndRows; j++)
            {
                if (matrix[j, i] < 0)
                {
                    flagNeg = true;
                    break;
                }
            }
            if (flagNeg)
            {
                for (int j = 0; j < ColAndRows; j++)
                {
                    sum[i] += matrix[j, i];
                }
                Console.WriteLine("The sum of all elements in column {0} is {1}", i, sum[i]);
            }
            
        }
        
    }
    public static void Main()
    {
        IntSauadMatrix obj = new IntSauadMatrix(5);
        obj.FillMatrixRandomly(-20,20);
        obj.ShowMatrix();
        obj.SortMatrixByChrctrstc();
        obj.SumIfNegInColumns();
    }
}

