using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerG : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    // Update is called once per frame
    public void Play2 (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.Name == name);
        s.source.Play();
    }



     
}
