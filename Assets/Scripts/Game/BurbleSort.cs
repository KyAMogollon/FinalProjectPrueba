using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbleSort : MonoBehaviour
{
    public void BurbleSortOrden(int [] arrayNumbers)
    {
        int tmp;
        for(int i = 0; i < arrayNumbers.Length; i++)
        {
            for(int j=0; j<arrayNumbers.Length-i-1; j++)
            {
                if (arrayNumbers[j] > arrayNumbers[i] + 1)
                {
                    tmp = arrayNumbers[j];
                    arrayNumbers[j] = arrayNumbers[j+1];
                    arrayNumbers[j+1] = tmp;
                }
            }
            PrintArray(arrayNumbers);
        }
    }
    public void PrintArray(int [] arrayNumber)
    {
        for (int i = 0; i < arrayNumber.Length; i++)
        {
            Debug.Log(arrayNumber[i] + " ");
        }
    }
}
