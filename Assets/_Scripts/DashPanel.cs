using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanel : BasePanel
{
    private RunManagement _runManagement;
    [SerializeField] private ParticleSystem _speedLines;

    private void Awake()
    {
        _runManagement = FindObjectOfType<RunManagement>();
        SoundName = "Boost";
    }

    public override void PanelBehaviour()
    {
        base.PanelBehaviour();
        StartCoroutine("Acceleration");
    }

    IEnumerator Acceleration()
    {
        _runManagement.NewAccelerationSpeed += 30;
        GameManager.Instance.Level += 10;
        _speedLines.Play();


       yield return new WaitForSeconds(1f);
        _runManagement.NewAccelerationSpeed = 0;
        GameManager.Instance.Level -= 10;
    }

}
