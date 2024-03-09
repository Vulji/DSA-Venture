using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlaySound("Secret");

            GameManager.Instance.NextLevel(1);
        }
    }
}
