using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "PuntajeSO", menuName = "ScriptableObjects/PuntajeSO", order = 2)]
public class PuntajeSO : ScriptableObject
{
    [SerializeField] public int [] maxScore;
    int k = 0;
    public void OnEnable()
    {
        if(maxScore == null)
        {
            maxScore = new int[10];
        }
    }
    public void RegistryNewScore(int newScore)
    {
        if (k < 10)
        {
            maxScore[k]=newScore;
            k++;
        }else
        {
            if(newScore > maxScore[0])
            {
                maxScore[0] = newScore;
            }
        }
        BurbleSortOrden();
    }
    public void BurbleSortOrden()
    {
        int tmp;
        bool isSorted;
        for (int i = 0; i < maxScore.Length - 1; i++)
        {
            isSorted = true;
            for (int j = 0; j < maxScore.Length - i - 1; j++)
            {
                if (maxScore[j] > maxScore[j+1])
                {
                    tmp = maxScore[j];
                    maxScore[j] = maxScore[j + 1];
                    maxScore[j + 1] = tmp;
                    isSorted = false;
                }
            }
            if (isSorted)
            {
                break;
            }
        }
    }
}
