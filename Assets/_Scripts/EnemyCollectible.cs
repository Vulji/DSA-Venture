using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollectible : BasicCollectible
{
    private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        ScoreAdded = 2000;
    }

    public override void CollectibleBehaviour()
    {
        _enemyAnimator.SetTrigger("Death");
        base.CollectibleBehaviour();
    }
}
