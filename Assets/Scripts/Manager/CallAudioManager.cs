using UnityEngine;
using UnityEngine.Audio;

public class CallAudioManager : MonoBehaviour
{
    //Call active audio manager
    public void CallPlaySFX(AudioClip audioClip)
    {
        AudioManager.Instance.PlaySFX(audioClip);
    }

    //Call active audio manager
    public void CallPlayMusic(AudioClip audioClip)
    {
        AudioManager.Instance.PlayMusic(audioClip);
    }

    //Call active audio manager
    public void CallMasterVolume(float sliderMaster)
    {
        AudioManager.Instance.MasterVolume(sliderMaster);
    }

    //Call active audio manager
    public void CallMusicVolume(float sliderMusic)
    {
        AudioManager.Instance.MusicVolume(sliderMusic);
    }

    //Call active audio manager
    public void CallSFXVolume(float sliderSFX)
    {
        AudioManager.Instance.SFXVolume(sliderSFX);
    }
}
