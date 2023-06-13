using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public void Ability(int selection)
    {
        if (selection == 0)
        {
            Debug.Log(selection);
            player.jumpForce = 7;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (selection == 1)
        {
            Debug.Log(selection);
            player.jumpForce = 7;
            player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (selection == 2)
        {
            Debug.Log(selection);
            player.jumpForce = 7;
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (selection == 3)
        {
            Debug.Log(selection);
            player.jumpForce = 15;
        }
    }
}
