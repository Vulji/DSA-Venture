using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : BasicCollectible, IScoreAddition
{

    private ParticleSystem _collectibleParticleSystem;
    

    public override void Awake()
    {
        base.Awake();
        _collectibleParticleSystem = GetComponent<ParticleSystem>();
        ScoreAdded = 1000;
        SoundName = "Diamond";
    }

    public void ScoreAddition()
    {
        GameManager.Instance.Score += ScoreAdded;
    }


    public override void CollectibleBehaviour()
    {
        
        ScoreAddition();
        _collectibleParticleSystem.Play();
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        base.CollectibleBehaviour();
    }
}
