using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioSound
{

    public string ClipName;
    public AudioClip AudioClip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;
    
    public AudioSource Source;

    public AudioMixerGroup Group;

    public bool IsLooping;

}
