using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RunManagement : MonoBehaviour
{
    private IGameGo _gameGo;
    private IRunner _runner;
    private IJVAnimationControl _jvAnimationControl;
    public bool _isRunStartTriggered;
    public bool _isTapStartTriggered;

    public float NewAccelerationSpeed;

    public void Initialize(IGameGo gameGo, IRunner runner, IJVAnimationControl animationController)
    {
        _gameGo = gameGo;
        _runner = runner;
        _jvAnimationControl = animationController;
    }

    private void Update()
    {
        bool isGameStarted = _gameGo.IsStarted();
        bool isTapStarted = _gameGo.GoalTapStarted;
        bool isDead = _gameGo.IsDead;
        if (isTapStarted)
        {
            if (!_isTapStartTriggered)
            {
                _jvAnimationControl.SetDanceTrigger();
                _isTapStartTriggered = true;
            }
        }
        else if (isDead)
        {
            _jvAnimationControl.SetDeathTrigger();
        }
        else if (isGameStarted & !isTapStarted & !isDead)
        {
            if (!_isRunStartTriggered)
            {
                _jvAnimationControl.SetRunStartTrigger();
                _isRunStartTriggered = true;
            }
            _runner.Run();

            _runner.SetAccelerationRunnerSpeed(NewAccelerationSpeed);
        }
    }

}
