using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text recordText;
    public void ToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        Time.timeScale = 1;
        recordText.text = $"Ваш рекорд : {PlayerPrefs.GetInt("record")}";
    }
}
