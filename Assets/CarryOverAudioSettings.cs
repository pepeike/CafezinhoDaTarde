using UnityEngine;

public class CarryOverAudioSettings : MonoBehaviour
{
    
    public AudioSource levelAudio;

    public void Start()
    {
        levelAudio.volume = PlayerPrefs.GetFloat("playervolume");
    }

}
