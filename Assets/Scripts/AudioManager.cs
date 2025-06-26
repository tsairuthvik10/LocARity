using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    public Slider volumeSlider;
    public Toggle muteToggle;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    void Start()
    {
        float vol = PlayerPrefs.GetFloat("Volume", 1f);
        bool muted = PlayerPrefs.GetInt("Muted", 0) == 1;
        audioSource.volume = muted ? 0 : vol;
        if (volumeSlider) volumeSlider.value = vol;
        if (muteToggle) muteToggle.isOn = muted;
    }

    public void SetVolume(float vol)
    {
        audioSource.volume = muteToggle.isOn ? 0 : vol;
        PlayerPrefs.SetFloat("Volume", vol);
    }

    public void SetMute(bool mute)
    {
        audioSource.volume = mute ? 0 : volumeSlider.value;
        PlayerPrefs.SetInt("Muted", mute ? 1 : 0);
    }
}