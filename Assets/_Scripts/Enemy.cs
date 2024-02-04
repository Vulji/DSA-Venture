using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] MMFeedbacks _shakeFeeback;
    private Animator _bigEnemyAnimator;
    private AudioSource _audioSource;


    public int Level
    {
        get => _level;
        set => _level = value;
    }

    private void Awake()
    {
        _bigEnemyAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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
            _shakeFeeback.PlayFeedbacks();
            other.gameObject.GetComponent<Animator>().SetTrigger("Punch");
            _bigEnemyAnimator.SetTrigger("Death");
            _audioSource.Play();
            Destroy(gameObject, 1.5f);
        }
    }
}
