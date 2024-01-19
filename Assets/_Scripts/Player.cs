using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Feedbacks")]
    public MMFeedbacks PlayerFeedbacks;

    private void Awake()
    {
    }

    public void TakeDamage()
    {
        
        PlayerFeedbacks.PlayFeedbacks();
        GameManager.Instance.Score -= 2000;
        //Destroy(gameObject);

    }

}
