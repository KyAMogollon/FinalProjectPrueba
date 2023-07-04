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
    public void RegisterNewScore(int newScore, TMP_Text puntaje)
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
        puntaje.text= "Score: " + maxScore[0];
    }
}
