using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameGo : MonoBehaviour, IGameGo
{
    [SerializeField] private InputActionAsset _touchScreen;
    [SerializeField] private GameObject _player;
    private InputAction _pressScreenAction;
    private InputAction _positionScreenAction;
    private bool _started;

    private void Awake()
    {
        _pressScreenAction = _touchScreen.FindAction("PressScreen");
        _positionScreenAction = _touchScreen.FindAction("Move");

    }

    private void OnEnable()
    {
        _pressScreenAction.Enable();
        _positionScreenAction.Enable();
        _pressScreenAction.started += OnPressScreenStarted;
    }

    private void OnDisable()
    {
        _pressScreenAction.Disable();
        _positionScreenAction.Enable();
        _pressScreenAction.started -= OnPressScreenStarted;
    }

    private void OnPressScreenStarted(InputAction.CallbackContext context)
    {
        _started = true;
        if (_started)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(_positionScreenAction.ReadValue<Vector2>());
            position.z = _player.transform.position.z;
            position.y = _player.transform.position.y;

            Debug.Log(_positionScreenAction.ReadValue<Vector2>());
            _player.transform.position = new Vector3(position.x, position.y, position.z);


        }
    }

    //private void Update()
    //{
    //    PreCull();
    //}

    //private void PreCull()
    //{
    //    if( Input.touchCount>0)
    //    {
    //        _started = true;     
    //    }
    //}



    public bool IsStarted()
    {
        return _started;
    }

}
