using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance {get; private set;}
    
    // Start is called before the first frame update
    void Awake()
    {
        
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
        
        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }

    void Start() {
        play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

}
