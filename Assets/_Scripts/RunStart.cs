using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunStart : MonoBehaviour
{
    private IGameGo _gameGo;
    private IRunner _runner;
    private AnimationController _animationController;
    private bool _isRunStartTriggered;
    
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 5f;


    private void Awake()
    {
        _gameGo = FindObjectOfType<GameGo>();
        _animationController = GetComponent<AnimationController>();
        _runner = new Runner(_player, _speed);
    }

    private void Update()
    {
        bool isGameStarted = _gameGo.IsStarted();
        if (isGameStarted)
        {
            if (!_isRunStartTriggered)
            {
                _animationController.SetRunStartTrigger();
                _isRunStartTriggered = true;
            }
            _runner.Run();
        }
    }

}
