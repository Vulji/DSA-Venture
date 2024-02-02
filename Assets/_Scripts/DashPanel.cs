using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanel : MonoBehaviour
{
    private RunManagement _runManagement;


    private void Awake()
    {
        _runManagement = FindObjectOfType<RunManagement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Acceleration");
        }
    }

    IEnumerator Acceleration()
    {
        _runManagement.NewAccelerationSpeed += 30;
       yield return new WaitForSeconds(1f);
        _runManagement.NewAccelerationSpeed = 0;
    }

}
