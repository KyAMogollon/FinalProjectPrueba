using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Image [] m_Image;
    [SerializeField] PlayerController player;
    [SerializeField] TMP_Text puntaje;
    [SerializeField] Canvas pause;
    [SerializeField] GameObject regresivo;
    [SerializeField] TMP_Text conteoregresivo;
    [SerializeField] Canvas menuOptions;
    [SerializeField] Canvas GameOver;
    float contador = 0;
    int score=0;
    bool menupause=true;
    int contadorRegresivo = 4;
    [SerializeField] SoundSelecion selectionSound;
    [SerializeField] PuntajeSO SOscore;
    [SerializeField] TMP_Text [] puntajeCanvas;
    int[] arrayNumbers;
    // Start is called before the first frame update
    void Start()
    {
        arrayNumbers = new int[10];
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
    public void GameOverMethod()
    {
        GameOver.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        SOscore.RegistryNewScore(score);
        for (int i = 0; i < arrayNumbers.Length; i++)
        {
            if (arrayNumbers[i] == 0)
            {
                arrayNumbers[i] =0;
            }
        }
        //SOscore.BurbleSortOrden(score);
        SOscore.Print(puntajeCanvas);
    }
    public void ButtonLeave(){
        Application.Quit();
    }
    public void ButtonReturn()
    {
        StartCoroutine(TimeToReturn());
    }
    IEnumerator TimeToReturn()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }
    public void ButtomResume()
    {
        if (menupause == false)
        {
            StartCoroutine(TimeToReady());
        }
    }
    public void ResetScene()
    {
        StartCoroutine(TimeToReset());
    }
    public void MenuPause(InputAction.CallbackContext value)
    {
        if(value.started && menupause == true)
        {
            selectionSound.StartSoundSelection();
            pause.gameObject.SetActive(true);
            menupause = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }/*else if(value.started && menupause == false)
        {
            StartCoroutine(TimeToReady());
        }*/
    }
    IEnumerator TimeToReset()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator TimeToReady()
    {
        contadorRegresivo = 4;
        pause.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        regresivo.gameObject.SetActive(true);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = contadorRegresivo.ToString();
        yield return new WaitForSecondsRealtime(1f);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = contadorRegresivo.ToString();
        yield return new WaitForSecondsRealtime(1f);

        contadorRegresivo = contadorRegresivo - 1;
        conteoregresivo.text = contadorRegresivo.ToString();
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
