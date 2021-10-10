using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Animator Overlay;
    [SerializeField] private AudioSource escSound;
    [SerializeField] private AudioSource resumeSound;
    public static bool gameIsPaused;

    void Update()
    {
        if (!gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                PauseGame();
                escSound.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                Resume();
                resumeSound.Play();
            }
        }

    }


    public void PauseGame()
    {
        Overlay.SetTrigger("Pause");
        gameIsPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Overlay.SetTrigger("Unpause");
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
