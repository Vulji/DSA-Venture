using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Feedbacks")]
    public MMFeedbacks PlayerFeedbacks;

    [SerializeField] private AudioSource _playerAudioSource;

    public void TakeDamage()
    {

        PlayerFeedbacks.PlayFeedbacks();
        _playerAudioSource.Play();
        GameManager.Instance.Score -= 2000;
        //Destroy(gameObject);

    }

}
