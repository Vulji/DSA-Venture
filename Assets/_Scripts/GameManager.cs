using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IResetLevel
{
    public static GameManager Instance;

    [Header("UI Int")]
    [SerializeField] private int _score;
    [SerializeField] private int _level;

    [Header("Characters")]
    [SerializeField] private Player _player;

    [Header("Feedbacks")]
    public MMFeedbacks DeathFeedbacks;
    [SerializeField] private MMFeedbacks _bigEnemyDeathFeedbacks;
    [SerializeField] private MMFeedbacks _smallEnemyDeathFeedbacks;

    public delegate void OnDeath();
    public static event OnDeath onDeath;


    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
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

        LoadSave();
    }


    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnLevelLoadded;
        onDeath += ResetLevel;
        onDeath += PLayerDeathEffect;
        Enemy.onBigEnemyDeath += BigEnemyDeathEffect;
        //EnemyCollectible.onSmallEnemyDeath += SmallEnemyDeathEffect;

    }

    private void OnDisable()
    {
        //SceneManager.sceneLoaded -= OnLevelLoadded;
        onDeath -= ResetLevel;
        onDeath -= PLayerDeathEffect;
        Enemy.onBigEnemyDeath -= BigEnemyDeathEffect;
        //EnemyCollectible.onSmallEnemyDeath -= SmallEnemyDeathEffect;

    }

    private void BigEnemyDeathEffect(Enemy enemy)
    {
        _bigEnemyDeathFeedbacks.PlayFeedbacks();
    }
    
    private void SmallEnemyDeathEffect(EnemyCollectible enemy)
    {
        _smallEnemyDeathFeedbacks.PlayFeedbacks();
    }
    private void PLayerDeathEffect()
    {
        DeathFeedbacks?.PlayFeedbacks();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        //public void OnLevelLoadded(Scene scene, LoadSceneMode mode)
        //{
        //     Try to work solution to make the load save work with the sceneLoaded event
        //    LoadSave();
        //}

        public void LoadSave()
    {
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(saveString);

            Score = playerData.SavedScore;
        }
        else
        {
            Debug.LogWarning("No save found");
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    void Update()
    {

        if (_player != null)
        {
            return;
        }
        else
        {
            onDeath();
        }
    }
}
