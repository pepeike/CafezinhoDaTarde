using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public AudioSource backgroundMusic;

    float bgmusicVolume;
    public void MasterVolumeValue(float value)
    {
        backgroundMusic.volume = value;
        // adicionar os efeitos aqui
    }

    public void BackGroundMusic(float value)
    {
        backgroundMusic.volume = value;
        bgmusicVolume = backgroundMusic.volume;
        PlayerPrefs.SetFloat("playervolume", bgmusicVolume);
        PlayerPrefs.Save();
    }

    public void EffectsMusic(float value)
    {
        //adicionar os efeitos aqui
    }
}