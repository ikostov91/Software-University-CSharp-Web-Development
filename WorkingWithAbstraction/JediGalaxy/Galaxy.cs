using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Galaxy
{
    private int[,] galaxyMatrix;
    private int score = 0;

    public Galaxy(string input)
    {
        int[] dimensions = input.Split().Select(int.Parse).ToArray();
        galaxyMatrix = new int[dimensions[0],dimensions[1]];
        FillGalaxy();
    }

    public void FillGalaxy()
    {
        int value = 0;
        for (int i = 0; i < galaxyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < galaxyMatrix.GetLength(1); j++)
            {
                galaxyMatrix[i, j] = value++;
            }
        }
    }

    public int SumScore(string ivoPosition)
    {
        int[] coordinates = ivoPosition.Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse).ToArray();
        int xI = coordinates[0];
        int yI = coordinates[1];

        while (xI >= 0 && yI < GetLengthY())
        {
            if (xI >= 0 && xI < GetLengthX() && yI >= 0 && yI < GetLengthY())
            {
                score += galaxyMatrix[xI, yI];
            }
            yI++;
            xI--;
        }

        return score;
    }

    public void DestroyStars(string evilPosition)
    {
        int[] coordinates = evilPosition.Split().Select(int.Parse).ToArray();
        int evilX = coordinates[0];
        int evilY = coordinates[1];

        while (evilX >= 0 && evilY >= 0)
        {
            if (evilX >= 0 && evilX < GetLengthX() && evilY >= 0 && evilY < GetLengthY())
            {
                galaxyMatrix[evilX, evilY] = 0;
            }
            evilX--;
            evilY--;
        }
    }

    public int GetLengthX()
    {
        return galaxyMatrix.GetLength(0);
    }

    public int GetLengthY()
    {
        return galaxyMatrix.GetLength(1);
    }
}

