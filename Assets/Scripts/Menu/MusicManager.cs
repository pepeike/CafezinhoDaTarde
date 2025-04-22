using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;

 

    public void MusicValue(float value)
    {
        backgroundMusic.volume = value;
        // adicionar os efeitos aqui
    }

    public void BackGroundMusic(float value)
    {
        backgroundMusic.volume = value;
    }

    public void EffectsMusic(float value)
    {
        //adicionar os efeitos aqui
    }
}