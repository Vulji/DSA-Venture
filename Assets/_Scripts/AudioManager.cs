using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSound[] _audioSounds;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (AudioSound sound in _audioSounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();

            sound.Source.clip = sound.AudioClip;

            sound.Source.volume = sound.Volume;

            sound.Source.pitch = sound.Pitch;
            
            sound.Source.loop = sound.IsLooping;

            sound.Source.outputAudioMixerGroup = sound.Group;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaySound("Main Music");
    }
    
    public void PlaySound(string soundName)
    {
       AudioSound sound = Array.Find(_audioSounds, _audioSound => _audioSound.ClipName == soundName);
       sound.Source.Play();
    }
}
