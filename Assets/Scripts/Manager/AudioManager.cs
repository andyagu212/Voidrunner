using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Declarations

    //Audio outputs
    [SerializeField] AudioSource musicSource, effectsSource;
    [SerializeField] AudioMixer audioMixer;

    //Create instance
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Play sound effect
    public void PlaySFX(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    //Play background music
    public void PlayMusic(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
        musicSource.loop = true;
    }

    //Stop music
    public void GameOver()
    {
        musicSource.Stop();
    }

    //Change master volume
    public void MasterVolume(float sliderMusica)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderMusica) * 20);
    }

    //Change music volume
    public void MusicVolume(float sliderMusica)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderMusica) * 20);
    }

    //Change SFX volume
    public void SFXVolume(float sliderMusica)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderMusica) * 20);
    }
}
