using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ChangeCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            cinemachine.Priority = 15;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            cinemachine.Priority = 5;
        }
    }
}
