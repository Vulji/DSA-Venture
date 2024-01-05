using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : BasicCollectible
{

    private ParticleSystem _collectibleParticleSystem;


    private void Awake()
    {
        _collectibleParticleSystem = GetComponent<ParticleSystem>();
    }


    public override void CollectibleBehaviour()
    {
        _collectibleParticleSystem.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        base.CollectibleBehaviour();
        GameManager.Instance.Score += 1000;
    }
}
