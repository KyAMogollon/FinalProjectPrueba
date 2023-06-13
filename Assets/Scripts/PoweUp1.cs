using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUp1 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ability()
    {
        player.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
    }
}