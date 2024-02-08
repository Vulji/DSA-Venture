using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollectible : BasicCollectible
{
    private Animator _enemyAnimator;
    [SerializeField] MMFeedbacks _shakeFeeback;

    public override void Awake()
    {
        base.Awake();
        _enemyAnimator = GetComponent<Animator>();
        LevelAdded = 2;
    }

    public override void CollectibleBehaviour()
    {
        GameManager.Instance.Level += LevelAdded;
        _enemyAnimator.SetTrigger("Death");
        _shakeFeeback.PlayFeedbacks();
        base.CollectibleBehaviour();
    }
}
