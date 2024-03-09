using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _level;
    private Animator _bigEnemyAnimator;

    public delegate void OnDeath(Enemy enemy);
    public static event OnDeath onBigEnemyDeath;


    public int Level
    {
        get => _level;
        set => _level = value;
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
            AudioManager.Instance.PlaySound("Big Gun");
            onBigEnemyDeath?.Invoke(this);
            Destroy(gameObject, 1.5f);
        }
    }
}
