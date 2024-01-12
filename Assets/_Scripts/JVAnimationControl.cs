using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JVAnimationControl : MonoBehaviour, IJVAnimationControl
{
    [SerializeField] private GameObject _player;
    private Animator _jvAnimator;

    private void Awake()
    {

        _jvAnimator = _player.GetComponent<Animator>();
    }

    public void SetRunStartTrigger()
    {
        _jvAnimator.SetTrigger("RunStart");
    }

    public void SetDanceTrigger() 
    {
        _jvAnimator.SetTrigger("DanceStart");
    }
}
