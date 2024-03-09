using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollectible : MonoBehaviour
{
    public int LevelAdded;
    public int ScoreAdded;
    public AudioSource _audioSource;
    public string SoundName;

    virtual public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        CollectibleBehaviour();
    }

    virtual public void CollectibleBehaviour()
    {
        AudioManager.Instance.PlaySound(SoundName);
        //_audioSource.Play();
        Handheld.Vibrate();
        Destroy(gameObject, 1.5f);
    }

}
