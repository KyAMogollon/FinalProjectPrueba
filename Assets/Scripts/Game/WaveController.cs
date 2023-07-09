using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private float timeToReset = 0;
    private float timeToReturnPosition = 10;
    private float savePosition;
    private float suavizado=0;
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
                while (suavizado <= 1)
                {
                    suavizado+=Time.deltaTime;
                    transform.position = new Vector3(transform.position.x - suavizado, transform.position.y, transform.position.z);
                }
                suavizado = 0;
            }
        }
    }
}
