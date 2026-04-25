using UnityEngine;
using UnityEngine.Audio;

public class VolumeControlScript : MonoBehaviour
{

    public AudioMixer VolumeMixer;

    public void SetVolume(float MusicVolume)
    {
        print(MusicVolume);
        VolumeMixer.SetFloat("Volume", MusicVolume);
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
