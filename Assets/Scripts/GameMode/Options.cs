using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public static Options Instance { get; private set; }
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button exit;
    private GameObject mainMenu;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Button opButton = GameObject.Find("Options Button")?.GetComponent<Button>();
        mainMenu = GameObject.Find("Main");

        if(mainMenu != null)
        {
            exit.onClick.AddListener(() => mainMenu.SetActive(true));
        }

        if(opButton != null)
        {
            opButton.onClick.AddListener(() => optionsMenu.SetActive(true));
        }
    }
}
