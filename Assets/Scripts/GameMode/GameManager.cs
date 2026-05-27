using System.Collections;
using UnityEngine.UI;
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
    private bool isPaused = false;
    private float tempTime;
    [SerializeField] private Image fadeImage;
    private float fadeDuration = 1f;

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
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if(Options.activeSelf)
            {
                Options.SetActive(false);
                if(isPaused)
                {
                    ResumeGame();
                }
            }
            else
            {
                Options.SetActive(true);
                if(!isPaused)
                {
                    PauseGame();
                }
            }
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
        GameObject spawnObj = GameObject.FindGameObjectWithTag("Spawn");
        Transform spawnPoint = spawnObj != null ? spawnObj.transform : null;
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

    public void PauseGame()
    {
        isPaused = true;

        tempTime = Time.timeScale;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
    public void ResumeGame()
    {
        if(!isPaused) return;
        isPaused = false;
        Time.timeScale = tempTime;
        AudioListener.pause = false;
    }


    public void SceneLoad()
    {
        fadeImage.gameObject.SetActive(true);
        Scene scene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(FadeInOut(scene.name));
    }
    public void SceneLoad(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeInOut(sceneName));
    }

    IEnumerator FadeInOut(string sceneName)
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            Color c = fadeImage.color;
            c.a = t / fadeDuration;
            c.a = Mathf.Clamp01(c.a);
            fadeImage.color = c;
        }
        SceneManager.LoadScene(sceneName);
        float t2 = fadeDuration;
        while (t2 > 0)
        {
            t2 -= Time.deltaTime;

            Color c = fadeImage.color;
            c.a = t2 / fadeDuration;
            c.a = Mathf.Clamp01(c.a);
            fadeImage.color = c;
            yield return null;
        }

    }

}
