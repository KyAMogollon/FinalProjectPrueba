using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] Canvas canvasController;
    public void Play()
    {
        StartCoroutine(TimeToPlay());
        Time.timeScale = 1;
    }
    IEnumerator TimeToPlay()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(1);
    }
}
