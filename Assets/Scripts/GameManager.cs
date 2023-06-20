using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
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
            m_Image[0].color = new Color32(255, 255, 255, 255);
            m_Image[1].color = new Color32(255, 255, 255, 100);
            m_Image[2].color = new Color32(255, 255, 255, 100);
        }
        else if (i == 2)
        {
            m_Image[0].color = new Color32(255, 255, 255, 100);
            m_Image[1].color = new Color32(255, 255, 255, 255);
            m_Image[2].color = new Color32(255, 255, 255, 100);
        }
        else if (i == 3)
        {
            m_Image[0].color = new Color32(255, 255, 255, 100);
            m_Image[1].color = new Color32(255, 255, 255, 100);
            m_Image[2].color = new Color32(255, 255, 255, 255);
        }
        else if (i == 0)
        {
            m_Image[0].color = new Color32(255, 255, 255, 100);
            m_Image[1].color = new Color32(255, 255, 255, 100);
            m_Image[2].color = new Color32(255, 255, 255, 100);
        }
    }
}
