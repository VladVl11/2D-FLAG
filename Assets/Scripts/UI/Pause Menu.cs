using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuPanel;
    public bool IsPaused = false;
    public void TogglePause()
    {
        if (IsPaused == true)
        {
            print("The game has been paused");
            PauseGame();
        }
        else
        {
            print("The game has been resumed");
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        IsPaused = true;

        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        PauseMenuPanel.SetActive(false);
    }

    public void ChangeScenes(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }
}
