using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _level;
    private Animator _bigEnemyAnimator;

    private void Awake()
    {
        _bigEnemyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameManager.Instance.Level < _level)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageInterface))
            {
                damageInterface.TakeDamage();
                GameManager.Instance.Score -= 10000;
            }
        }
        else if (other.gameObject.tag == "Player" && GameManager.Instance.Level > _level)
        {
            _bigEnemyAnimator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
    }
}
