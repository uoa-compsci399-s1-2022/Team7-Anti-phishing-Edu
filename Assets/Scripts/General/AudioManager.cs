using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager audioManagerInstance;

    public int currentState = 0;

    private void Awake()
    {
        //Singlton Pattern
        if (audioManagerInstance == null)
        {
            audioManagerInstance = this;
        }
        else
        {
            if (audioManagerInstance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        PlayByName("Background Music");

    }

    public void PlayByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentState == 0)
            {
                PlayByName("Click01");
            }else if (currentState == 0)
            {
                PlayByName("Click02");
            }
        }
    }

    public void StopPlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
}

[Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}