using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: GameManager not Found");
                }
            }
            return _instance;
        }
    }
    #endregion
    [SerializeField] private TextMeshProUGUI scoreText;
    public int Score { get; private set; }


    void Update()
    {
        scoreText.text = Score.ToString();
    }

    public void setScore()
    {
        Score++;
    }
}
