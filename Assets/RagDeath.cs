using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDeath : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private MMFeedbacks _gunFeedbacks;
    [SerializeField] AudioSource _audioSource;

    [SerializeField] Camera _mainCamera;
    [SerializeField] Camera _cubeCamera;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(AwaitingDeath());
        StartCoroutine(CameraManagement());
    }

    private IEnumerator AwaitingDeath() 
    {
        yield return new WaitForSeconds(5);
        _audioSource.Play();
        yield return new WaitForSeconds(.75f);
        _gunFeedbacks.PlayFeedbacks();
        Debug.Log("bang");   
        _animator.enabled = false;
    }

    private IEnumerator CameraManagement() 
    {
        //_cubeCamera.enabled = false;
        _mainCamera.enabled = true;
        yield return new WaitForSeconds(2);
        _cubeCamera.enabled = true;
        yield return new WaitForSeconds(2.5f);
        //_cubeCamera.enabled = false;
        _mainCamera.enabled = true;
    }

}
