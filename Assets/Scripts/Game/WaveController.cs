using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private float timeToReset = 0;
    private float timeToReturnPosition = 10;
    private float savePosition;
    // Start is called before the first frame update
    void Start()
    {
        savePosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        timeToReset += Time.deltaTime;
        if (timeToReset >= timeToReturnPosition)
        {
            timeToReset = 0;
            if (transform.position.x > savePosition)
            {
                transform.position=new Vector3(transform.position.x-1,transform.position.y,transform.position.z);
            }
        }
    }
}
