using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : BasePanel
{
    //private float _jumpForce = 50000f;


    private void Awake()
    {
        SoundName = "Boing";
    }

    public override void PanelBehaviour()
    {
        base.PanelBehaviour();
        //_playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //_playerRb.AddForce(Physics.gravity * 1000, ForceMode.Acceleration);

    }
}
