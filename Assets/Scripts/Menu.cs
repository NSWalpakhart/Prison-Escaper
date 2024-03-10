using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OnPlayHandler()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }

    public void OnExitHandler()
    {
        Application.Quit();
    }
}
