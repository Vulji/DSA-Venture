using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Feedbacks")]
    public MMFeedbacks ParticlesInstantiation;

    private void Awake()
    {
        //if (ParticlesInstantiation == null)
        //{
        //    ParticlesInstantiation = gameObject.GetComponent<MMFeedbacks>();
        //}
    }

    public void TakeDamage()
    {
        Destroy(gameObject);

    }

}
