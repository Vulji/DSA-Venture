using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : IRunner
{
    private GameObject _runnerPlayer;
    private float _runnerSpeed;
    private Touch _touch;

    public Runner(GameObject player, float speed)
    {
        _runnerPlayer = player;
        _runnerSpeed = speed;
    }

    public void Run()
    {
        _runnerPlayer.transform.position += Vector3.forward * _runnerSpeed * Time.deltaTime;
        //if (Input.touchCount > 0)
        //{
        //    if (_touch.phase == TouchPhase.Moved)
        //    {
        //        // Convert touch position to world space if needed
        //        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);

        //        // Set the player's position directly to the touch position
        //        _runnerPlayer.transform.position = touchPosition;
        //    }
        //}
    }
    
}
