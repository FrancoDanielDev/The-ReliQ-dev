using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Franco & Bortoló
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public static bool gamePaused = false;

    public GameObject pauseMenuUI, InstructionsUI, defeatMenuUI;

    [SerializeField] private Player _player;
    public CheckpointBehavior check;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Instructions()
    {
        pauseMenuUI.SetActive(false);
        InstructionsUI.SetActive(true);
    }

    public void BackToMainPause()
    {
        InstructionsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void BacktoMenu()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Defeat()
    {
        defeatMenuUI.SetActive(true);
        AudioManager.instance.Play("Died");
        Time.timeScale = 0f;
    }

    public void ReturntoCheckpoint()
    {
        defeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _player.Revive();
        check._cpSub.BackToCheckpoint();
    }
}
