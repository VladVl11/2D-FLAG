using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source -------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ SFX Source ---------")]
    public AudioClip Background;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
