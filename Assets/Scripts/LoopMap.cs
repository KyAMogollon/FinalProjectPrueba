using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMap : MonoBehaviour
{
    [SerializeField] GameObject Playa;
    [SerializeField] GameObject Playa1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playa.transform.position = new Vector3(Playa.transform.position.x-speed*Time.deltaTime, Playa.transform.position.y, Playa.transform.position.z);
        Playa1.transform.position = new Vector3(Playa1.transform.position.x - speed*Time.deltaTime, Playa1.transform.position.y, Playa1.transform.position.z);
        if (Playa.transform.position.x <= -230)
        {
            Playa.transform.position = new Vector3(97f, Playa.transform.position.y, Playa.transform.position.z);
        }
        if (Playa1.transform.position.x <= -230)
        {
            Playa1.transform.position = new Vector3(97f, Playa1.transform.position.y, Playa1.transform.position.z);
        }
    }
}
