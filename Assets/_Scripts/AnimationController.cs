using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _jvAnimator;

    private void Awake()
    {
        _jvAnimator = GetComponent<Animator>();
    }

    public void SetRunStartTrigger()
    {
        _jvAnimator.SetTrigger("RunStart");
    }
}
