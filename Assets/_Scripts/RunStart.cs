using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunStart : MonoBehaviour
{
    private IGameGo _gameGo;
    private IRunner _runner;
    private IJVAnimationControl _jvAnimationControl;
    public bool _isRunStartTriggered;

    [SerializeField] private float _speed = 5f;

    public void Initialize(IGameGo gameGo, IRunner runner, IJVAnimationControl animationController)
    {
        _gameGo = gameGo;
        _runner = runner;
        _jvAnimationControl = animationController;
    }

    private void Update()
    {
        bool isGameStarted = _gameGo.IsStarted();
        if (isGameStarted)
        {
            if (!_isRunStartTriggered)
            {
                _jvAnimationControl.SetRunStartTrigger();
                _isRunStartTriggered = true;
            }
            _runner.Run();
        }
    }

}
