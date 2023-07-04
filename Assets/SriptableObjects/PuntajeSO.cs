using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "PuntajeSO", menuName = "ScriptableObjects/PuntajeSO", order = 2)]
public class PuntajeSO : ScriptableObject
{
    [SerializeField] private int [] maxScore;
    public void OnEnable()
    {
        if(maxScore == null)
        {
            maxScore = new int[10];
        }
    }
    public void RegistryNewScore(int newScore)
    {
        bool isChanged = false;
        int[] newMaxScore = new int[10];
        for (int i = 0; i < 10; i++)
        {
            int savePrevious = maxScore[i];
            if (newScore > maxScore[i] && !isChanged)
            {
                newMaxScore[i] = newScore;
                i++;
                isChanged = true;
            }
            newMaxScore[i] = savePrevious;
        }
        maxScore = newMaxScore;
        BurbleSortOrden(maxScore);
    }
    public void BurbleSortOrden(int [] maxScore)
    {
        int tmp;
        for (int i = 0; i < maxScore.Length; i++)
        {
            for (int j = 0; j < maxScore.Length - i - 1; j++)
            {
                if (maxScore[j] > maxScore[i+1])
                {
                    tmp = maxScore[j];
                    maxScore[j] = maxScore[j + 1];
                    maxScore[j + 1] = tmp;
                }
            }
        }
    }
    public void Print(TMP_Text [] puntajeCanvas)
    {
        for (int i = 0; i < maxScore.Length; i++)
        {
            puntajeCanvas[i].text = "Score: " + maxScore[i];
        }
    }
}
