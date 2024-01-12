using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : BasicCollectible
{

    private ParticleSystem _collectibleParticleSystem;
    private AudioSource _audioSource;

    private void Awake()
    {
        _collectibleParticleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        ScoreAdded = 1000;
    }


    public override void CollectibleBehaviour()
    {
        _collectibleParticleSystem.Play();
        _audioSource.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        base.CollectibleBehaviour();
    }
}
