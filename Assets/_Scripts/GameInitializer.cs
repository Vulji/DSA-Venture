using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private RunManagement _runStart;
    [SerializeField] private GameGo _gameGo;
    [SerializeField] private JVAnimationControl _jvAnimationControl;
    [SerializeField] private float _startSpeed;

    [SerializeField] private IRunner runner;


    private void Awake()
    {
        runner = new Runner(_player, _startSpeed);
        _runStart.Initialize(_gameGo, runner, _jvAnimationControl);
    }
}
