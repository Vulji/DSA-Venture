using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollectible : BasicCollectible
{
    [SerializeField] MMFeedbacks _shakeFeeback;

    public delegate void OnDeath(EnemyCollectible enemy);
    public static event OnDeath onSmallEnemyDeath;

    public override void Awake()
    {
        base.Awake();
        LevelAdded = 2;
        SoundName = "Gun";
    }

    public override void CollectibleBehaviour()
    {
        GameManager.Instance.Level += LevelAdded;
        //Look into if the feedback feels right before replacing the dependency
        _shakeFeeback.PlayFeedbacks();
        onSmallEnemyDeath?.Invoke(this);
        base.CollectibleBehaviour();
    }
}
