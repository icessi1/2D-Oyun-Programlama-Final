using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void MainMenuGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SettingsGame()
    {
        SceneManager.LoadScene("Ayarlar Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
