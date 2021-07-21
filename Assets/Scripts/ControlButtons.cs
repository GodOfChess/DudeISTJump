using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlButtons : MonoBehaviour
{
    private bool paused = false;
    public Text pauseText;
    private int record;
    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            pauseText.gameObject.SetActive(true);
        }
        else
        {
            paused = false;
            pauseText.gameObject.SetActive(false);
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        GeneratePlatform.count = 0;
        GeneratePlatform.brokencount = 0;
        if (ControlScore.score > record)
        {
            record = ControlScore.score;
            PlayerPrefs.SetInt("record", record);
        }
         ControlScore.score = 0;
    }

    private void Start()
    {
        record = PlayerPrefs.GetInt("record");
    }
    private void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
