using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashPanel : BasePanel
{
    private RunManagement _runManagement;
    [SerializeField] private ParticleSystem _speedLines;
    bool _isSpeeding;

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
        _isSpeeding = true;


        yield return new WaitForSeconds(1.1f);
        _runManagement.NewAccelerationSpeed -= 30;
        GameManager.Instance.Level -= 10;

    }

}
