using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunStart : MonoBehaviour
{
    private GameGo _gameGo;
    private Animator _jvAnimator;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        _gameGo = FindAnyObjectByType<GameGo>();
        _jvAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_gameGo._started)
        {
            _jvAnimator.SetTrigger("RunStart");
            Run();
        }
    }

    private void Run()
    {
        _player.transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

}
