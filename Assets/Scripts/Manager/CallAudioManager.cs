using UnityEngine;

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
}
