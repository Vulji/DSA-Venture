using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollectible : MonoBehaviour
{
    public int LevelAdded;
    public int ScoreAdded;
    public AudioSource _audioSource;

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

        _audioSource.Play();
        Handheld.Vibrate();
        Destroy(gameObject, 1.5f);
    }

}
