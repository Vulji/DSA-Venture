using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JVAnimationControl : MonoBehaviour, IJVAnimationControl
{
    private Animator _jvAnimator;

    private void Awake()
    {
        _jvAnimator = FindObjectOfType<Animator>();
    }

    public void SetRunStartTrigger()
    {
        _jvAnimator.SetTrigger("RunStart");
    }
}
