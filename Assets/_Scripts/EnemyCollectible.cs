using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectible : BasicCollectible
{
    private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
    }

    public override void CollectibleBehaviour()
    {
        Debug.Log("I'm dead");
        _enemyAnimator.SetTrigger("Death");
        base.CollectibleBehaviour();
        GameManager.Instance.Score += 2000;
    }
}
