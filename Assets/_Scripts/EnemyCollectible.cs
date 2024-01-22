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
        LevelAdded = 2;
    }

    public override void CollectibleBehaviour()
    {
        GameManager.Instance.Level += LevelAdded;
        _enemyAnimator.SetTrigger("Death");
        base.CollectibleBehaviour();
    }
}
