using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Feedbacks")]
    public MMFeedbacks PlayerFeedbacks;
    private bool _isGrounded;
    private float _gravity = 9.81f;
    private float _verticalVelocity = 0f;


    /*Besoin de retravailler cela sans uttilisation de rigidbody*/

    //private void FixedUpdate()
    //{
    //    _isGrounded = IsGrounded();

    //    if (!_isGrounded)
    //    {
    //        _verticalVelocity -= _gravity * Time.fixedDeltaTime;
    //        Vector3 displacement = Vector3.up * _verticalVelocity * Time.fixedDeltaTime;
    //        transform.position += displacement;
    //    }
    //    else
    //    {
    //        _verticalVelocity = 0f;
    //    }
    //}

    //private bool IsGrounded()
    //{
    //    RaycastHit hit;
    //    float distanceToGround = 0.2f;
    //    Vector3 rayOrigin = transform.position;

    //    if (Physics.Raycast(rayOrigin, Vector3.down, out hit, distanceToGround))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}


    public void TakeDamage()
    {

        PlayerFeedbacks.PlayFeedbacks();
        AudioManager.Instance.PlaySound("Grunt");
        GameManager.Instance.Score -= 2000;
    }

}
