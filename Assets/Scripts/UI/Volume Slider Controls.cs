using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderControls : MonoBehaviour
{

    public string VolumeType = "MasterVolume";
    public AudioMixer Mixer;
    public Slider Slider;

    public float Multiplier = 30f;
    [Range(0, 1)] public float DefaultSliderPercentage = 0.75f; 

    private void Awake()
    {
        Slider.onValueChanged.AddListener(SliderValueChanged);
        DontDestroyOnLoad(gameObject); 
    }

    public void SliderValueChanged(float SliderValue)
    {
        Mixer.SetFloat(VolumeType, SliderToDecibel(SliderValue));
    }

    private float SliderToDecibel(float Value)
    {
        return Mathf.Clamp(Mathf.Log10(Value/DefaultSliderPercentage)*Multiplier, -80f, 20f);
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
