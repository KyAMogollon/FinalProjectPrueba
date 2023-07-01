using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [SerializeField] Image [] m_Image;
    [SerializeField] PlayerController player;
    [SerializeField] TMP_Text puntaje;
    [SerializeField] Canvas pause;
    [SerializeField] Canvas regresivo;
    [SerializeField] TMP_Text conteoregresivo;
    float contador = 0;
    int score=0;
    bool menupause=true;
    int contadorRegresivo = 4;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player.Oncollision += ActivationPowerUpsOnCanvas;
        contador=contador+1*Time.deltaTime;
        score=(int)contador;
        puntaje.text = "0000"+ score;
        if (score > 9&&score<99)
        {
            puntaje.text = "000" + score;
        }else if(score > 99 &&score<999)
        {
            puntaje.text = "00" + score;
        }else if(score>999 && score < 9999)
        {
            puntaje.text = "0" + score;
        }else if(score>9999)
        {
            puntaje.text = "" + score;
        }
    }
    public void MenuPause(InputAction.CallbackContext value)
    {
        if(value.started && menupause == true)
        {
            pause.gameObject.SetActive(true);
            menupause = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }else if(value.started && menupause == false)
        {
            StartCoroutine(TimeToReady());
        }
    }
    IEnumerator TimeToReady()
    {
        pause.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        regresivo.gameObject.SetActive(true);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = " " + contadorRegresivo;
        yield return new WaitForSecondsRealtime(1f);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = " " + contadorRegresivo;
        yield return new WaitForSecondsRealtime(1f);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = " " + contadorRegresivo;
        yield return new WaitForSecondsRealtime(1f);

        menupause = true;
        regresivo.gameObject.SetActive(false);
        Time.timeScale = 1;
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
