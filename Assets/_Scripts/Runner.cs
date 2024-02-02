using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : IRunner
{
    private GameObject _runnerPlayer;
    private float _runnerSpeed;
    private float _cacheSpeed;

    public Runner(GameObject player, float speed)
    {
        _runnerPlayer = player;
        _runnerSpeed = speed;
        _cacheSpeed = speed;
    }

    public void Run()
    {
        if (_runnerPlayer == null) { return; }

        _runnerPlayer.transform.position += Vector3.forward * _runnerSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(_runnerPlayer.transform.position.x, -1f, 2.2f);
        _runnerPlayer.transform.position = new Vector3(clampedX, _runnerPlayer.transform.position.y, _runnerPlayer.transform.position.z);



        //Remove key controls after testing
        if (Input.GetAxis("Horizontal") > 0)
        {
            _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.right, 2f * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            _runnerPlayer.transform.position = Vector3.Lerp(_runnerPlayer.transform.position, _runnerPlayer.transform.position + Vector3.left, 2f * Time.deltaTime);
        }
    }

    public void SetAccelerationRunnerSpeed(float accelerationSpeed)
    {
        if (accelerationSpeed != 0 & accelerationSpeed > _cacheSpeed)
        {
            _runnerSpeed = accelerationSpeed;
        }
        else
        {  
            _runnerSpeed = _cacheSpeed;
        }
    }
}
