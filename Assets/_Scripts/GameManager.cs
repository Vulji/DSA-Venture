using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IResetLevel
{
    public static GameManager Instance;
    [SerializeField] private float _score;
    [SerializeField] private Player _player;

    public delegate void OnDeath();
    public static event OnDeath onDeath;

    public float Score
    {
        get => _score;
        set => _score = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        onDeath += ResetLevel;
    }

    private void OnDisable()
    {
        onDeath -= ResetLevel;
    }

    public void ResetLevel()
    {
        StartCoroutine("ResetLevelCor");
    }

    IEnumerator ResetLevelCor()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void Update()
    {
        if (_player != null) { return; }
        else
        {
            onDeath();
        }
    }
}
