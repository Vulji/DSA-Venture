using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameGo : MonoBehaviour, IGameGo
{
    [SerializeField] private InputActionAsset _touchScreen;
    [SerializeField] private GameObject _player;

    private InputAction _pressScreenAction;
    private InputAction _positionScreenAction;

    private bool _started;
    [SerializeField] private bool _goalTapStarted;

    private int _currentTapGauge = 0;
    private int _maxTapGauge = 10;

    public delegate void OnTapGaugeFull();
    public static event OnTapGaugeFull onTapGaugeFull;

    public bool GoalTapStarted
    {
        get => _goalTapStarted;
        set => _goalTapStarted = value;
    }

    private void Awake()
    {
        _pressScreenAction = _touchScreen.FindAction("PressScreen");
        _positionScreenAction = _touchScreen.FindAction("Move");
    }

    private void OnEnable()
    {
        onTapGaugeFull += ResetLevel;

        _pressScreenAction.Enable();
        _positionScreenAction.Enable();
        _pressScreenAction.started += OnPressScreenStarted;
        _positionScreenAction.performed += OnSlideMove;
    }

    private void OnDisable()
    {
        onTapGaugeFull -= ResetLevel;

        _pressScreenAction.Disable();
        _positionScreenAction.Disable();
        _pressScreenAction.started -= OnPressScreenStarted;
        _positionScreenAction.performed -= OnSlideMove;
    }

    private void OnPressScreenStarted(InputAction.CallbackContext context)
    {
        _started = true;

        if (_goalTapStarted)
        {
            _currentTapGauge++;
            Debug.Log(_currentTapGauge);

            if (_currentTapGauge >= _maxTapGauge)
            {
                onTapGaugeFull();
            }
        }
    }

    private void OnSlideMove(InputAction.CallbackContext context)
    {
        if (_goalTapStarted)
            return;

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

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsStarted()
    {
        return _started;
    }
}
