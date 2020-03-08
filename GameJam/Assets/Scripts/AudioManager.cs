using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SourceofAudio;
    public AudioClip Clip;
    public AudioSource MusicSource;
    public static AudioManager thisInstance = null;
    public float Low = .95f;
    public float high = 1.05f;
    public float AudioVolume;
    // Start is called before the first frame update
    void Awake()
    {
        if(thisInstance == null)
        {
            thisInstance = this;
        }
        else if(thisInstance != this)
        {
            Object.Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }


    public void PlayDat(AudioClip audioClip)
    {
        SourceofAudio.clip = audioClip;

        SourceofAudio.volume = AudioVolume;

        SourceofAudio.PlayOneShot(Clip);
    }


}
