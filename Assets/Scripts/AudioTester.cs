using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class AudioTester : MonoBehaviour
{

    public AudioClip soundToPlay;
    AudioSource audioSourceToUse;
    void Start()
    {
        audioSourceToUse = GetComponent<AudioSource>();
        InvokeRepeating("FireShot", 1f, 3f);
    }


    void FireShot()
    {
        audioSourceToUse.PlayOneShot(soundToPlay);
    }
}
