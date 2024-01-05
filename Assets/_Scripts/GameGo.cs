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
        _positionScreenAction.performed += OnSlideMove;
        _positionScreenAction.canceled += OnSlideMoveCanceled;
    }

    private void OnDisable()
    {
        _pressScreenAction.Disable();
        _positionScreenAction.Disable();
        _pressScreenAction.started -= OnPressScreenStarted;
        _positionScreenAction.performed -= OnSlideMove;
        _positionScreenAction.canceled -= OnSlideMoveCanceled;
    }

    private void OnPressScreenStarted(InputAction.CallbackContext context)
    {
        _started = true;
    }

    private void OnSlideMove(InputAction.CallbackContext context)
    {
        Vector2 inputPosition = _positionScreenAction.ReadValue<Vector2>();

        Vector2 normalizedInput = new Vector2(
            Mathf.Clamp(inputPosition.x / Screen.width, -1f, 1f),
            Mathf.Clamp(inputPosition.y / Screen.height, -1f, 1f)
        );

        float maxDistance = 5.2f;

        Vector3 targetPosition = new Vector3(
            normalizedInput.x * maxDistance,
            _player.transform.position.y,
            _player.transform.position.z
        );

        float lerpSpeed = 5f;
        _player.transform.position = Vector3.Lerp(_player.transform.position, targetPosition, lerpSpeed * Time.deltaTime);

        _player.transform.position = new Vector3(
            Mathf.Clamp(_player.transform.position.x, -maxDistance, maxDistance),
            _player.transform.position.y,
            _player.transform.position.z
        );
    }




    private void OnSlideMoveCanceled(InputAction.CallbackContext context)
    {
        // Additional logic for slide move canceled
    }

    public bool IsStarted()
    {
        return _started;
    }
}
