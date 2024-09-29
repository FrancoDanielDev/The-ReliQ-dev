using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Bortol�
public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void TestRoom()
    {
        SceneManager.LoadScene("GameRoom");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
