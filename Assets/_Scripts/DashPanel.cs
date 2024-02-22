using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanel : MonoBehaviour
{
    private RunManagement _runManagement;
    [SerializeField] private ParticleSystem _speedLines;

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
        GameManager.Instance.Level += 10;
        _speedLines.Play();
        AudioManager.Instance.PlayAudio(2);

       yield return new WaitForSeconds(1f);
        _runManagement.NewAccelerationSpeed = 0;
        GameManager.Instance.Level -= 10;
    }

}
