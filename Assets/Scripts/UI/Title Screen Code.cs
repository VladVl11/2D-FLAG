using System;
using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class TitleScreenCode : MonoBehaviour
{

    public void QuitApp()
    {
        Application.Quit();
        print("The game has been closed");
    }

    public void Start()
    {
        
    }
}
