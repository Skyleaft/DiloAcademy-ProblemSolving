using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void changeScenebyName(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void changeScenebyID(int _sceneID)
    {
        SceneManager.LoadScene(_sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
