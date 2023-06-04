using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : IRunner
{
    private GameObject _runnerPlayer;
    private float _runnerSpeed;

    public Runner(GameObject player, float speed)
    {
        _runnerPlayer = player;
        _runnerSpeed = speed;
    }

    public void Run()
    {
        _runnerPlayer.transform.position += Vector3.forward * _runnerSpeed * Time.deltaTime;
    }
}
