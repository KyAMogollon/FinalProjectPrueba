using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    Canvas canvas;
    [SerializeField] Image [] m_Image;
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player.Oncollision += ActivationPowerUpsOnCanvas;
    }
    public void ActivationPowerUpsOnCanvas(int i)
    {
        if (i == 1)
        {
            m_Image[0].gameObject.SetActive(true);
        }
        else if (i == 2)
        {
            m_Image[1].gameObject.SetActive(true);
        }
        if (i == 3)
        {
            m_Image[2].gameObject.SetActive(true);
        }
    }
}
