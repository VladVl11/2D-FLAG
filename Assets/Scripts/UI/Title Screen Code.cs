using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenCode : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
        print("The game has been closed");
    }
}
