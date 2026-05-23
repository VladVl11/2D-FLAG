using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject Options;
    public TMP_Dropdown dropdown;
    [SerializeField] private GameObject player;
    private Transform spawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnOptions()
    {
        if(Options.activeSelf)
        {
            Options.SetActive(false);
        }
        else
        {
            Options.SetActive(true);
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
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform;
        if(spawnPoint != null)
        {
            Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void OnLanguageChanged()
    {
        string selected = dropdown.options[dropdown.value].text;

        switch (selected)
        {
            case "English":
                GameManager.Instance.SetLanguage("en");
                break;

            case "Română":
                GameManager.Instance.SetLanguage("ro");
                break;
        }
    }

    public void SetLanguage(string languageCode)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(languageCode);

        if (locale != null)
        {
            LocalizationSettings.SelectedLocale = locale;
        }
        else
        {
            Debug.Log("Locale not found: " + languageCode);
        }
    }


    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
