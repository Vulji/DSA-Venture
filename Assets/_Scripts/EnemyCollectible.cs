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



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageInterface)) 
        { 
            damageInterface.TakeDamage();
        }
    }

    //public void InflictDamage(Collider other)
    //{
    //    if (other.gameObject.tag =="Player")
    //    Destroy(other.gameObject);
    //}
}
