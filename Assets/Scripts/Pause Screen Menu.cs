using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;
using UnityEditor;

public class PauseScreenMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject Panel;
    public InputAction UIPauseMenu;

    [SerializeField] private GameObject PauseUI;
    [SerializeField] private bool IsPaused;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    public void ChangeScenes(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            Panel.SetActive(false);
        }
    }
    // public void OnEnable()
    // {
    //    Menu.OpenPauseMenu;
    //    UIPauseMenu.Enable();
    // }

    public void OnDisable()
    {
        
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
            OpenPanel();
            PauseGame();
        }
    }
}
