using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 vectorToMove;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, vectorToMove, speed*Time.deltaTime);
    }
    public void ChangeMovePosition(Vector3 destiny)
    {
        vectorToMove = destiny;
    }
}
