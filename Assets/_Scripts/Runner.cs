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

        // Clamp the x position between -0.8 and 0.8
        float clampedX = Mathf.Clamp(_runnerPlayer.transform.position.x, -1f, 2.2f);
        _runnerPlayer.transform.position = new Vector3(clampedX, _runnerPlayer.transform.position.y, _runnerPlayer.transform.position.z);

        if (Input.GetAxis("Horizontal") > 0)
        {
            // Smoothly move towards the right using Lerp
            _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.right, 2f * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            // Smoothly move towards the left using Lerp
            _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.left, 2f * Time.deltaTime);
        }


        // Check for touch input
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0); // Assuming only one touch for simplicity

        //    // Calculate the desired movement direction based on touch position
        //    Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
        //    float touchX = touchWorldPos.x - _runnerPlayer.transform.position.x;

        //    if (touchX > 0)
        //    {
        //        // Smoothly move towards the right using Lerp
        //        _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.right, 2f * Time.deltaTime);
        //    }
        //    else if (touchX < 0)
        //    {
        //        // Smoothly move towards the left using Lerp
        //        _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.left, 2f * Time.deltaTime);
        //    }
        //}

    }

}
