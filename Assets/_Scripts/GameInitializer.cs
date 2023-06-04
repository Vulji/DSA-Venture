using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private RunStart _runStart;
    [SerializeField] private GameGo _gameGo;
    [SerializeField] private JVAnimationControl _jvAnimationControl;

    private void Awake()
    {
        IRunner runner = new Runner(_player, 5f);
        _runStart.Initialize(_gameGo, runner, _jvAnimationControl);
    }
}
