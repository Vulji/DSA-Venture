using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        Enemy.onBigEnemyDeath += DeathToTheEnemy;
        EnemyCollectible.onSmallEnemyDeath += CollectTheEnemy;
    }

    private void OnDisable()
    {
        Enemy.onBigEnemyDeath -= DeathToTheEnemy;
        EnemyCollectible.onSmallEnemyDeath -= CollectTheEnemy;

    }

    public void DeathToTheEnemy(Enemy enemy)
    {
        _player.gameObject.GetComponent<Animator>().SetTrigger("Punch");
        enemy.GetComponent<Animator>().SetTrigger("Death");

    }    
    
    public void CollectTheEnemy(EnemyCollectible enemy)
    {
        enemy.GetComponent<Animator>().SetTrigger("Death");

    }
}
