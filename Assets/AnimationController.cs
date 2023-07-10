using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animationPlayer;
    // Start is called before the first frame update
    void Start()
    {
        animationPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
