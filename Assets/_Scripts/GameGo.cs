using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameGo : MonoBehaviour
{
    [SerializeField] private InputActionAsset _touchScreen;
    private InputAction _pressScreenAction;
    public bool _started;

    private void Awake()
    {
        _pressScreenAction = _touchScreen.FindAction("PressScreen");
    }

    private void OnEnable()
    {
        _pressScreenAction.Enable();
        _pressScreenAction.started += OnPressScreenStarted;
    }

    private void OnDisable()
    {
        _pressScreenAction.Disable();
        _pressScreenAction.started -= OnPressScreenStarted;
    }

    private void OnPressScreenStarted(InputAction.CallbackContext context)
    {
        _started = true;
    }

}
