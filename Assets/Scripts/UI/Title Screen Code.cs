using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenCode : MonoBehaviour
{
    string[] TitleScreenSelection = {"Start Game" , "Load Game" , "Options" , "Controls" , "Exit Game"};
    public void ChangeScenes(string SceneName)
    {
        SceneManager.LoadScene(SceneName);   
    }
    public void QuitApp()
    {
        Application.Quit();
        print("The game has been closed");
    }
}
