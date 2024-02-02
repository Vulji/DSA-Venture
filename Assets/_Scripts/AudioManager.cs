using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio(int clipNumber) 
    {
        AudioClip clip = _audioClips[clipNumber];
        AudioSource _playingSource = gameObject.AddComponent<AudioSource>();
        _playingSource.volume = .5f;
        _playingSource.clip = clip;
        _playingSource.Play();
        
    }
}
