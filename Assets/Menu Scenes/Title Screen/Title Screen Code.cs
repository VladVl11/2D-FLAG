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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("The Script has been run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
