using UnityEngine;

public class InvolkSound : MonoBehaviour
{
    public AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
