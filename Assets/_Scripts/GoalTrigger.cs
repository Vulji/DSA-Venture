using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private GameGo _gameGo;
    [SerializeField] private ParticleSystem[] _particleSystem;

    private void Awake()
    {
        _gameGo = FindObjectOfType<GameGo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SaveSystem.Save();
            foreach (var item in _particleSystem)
            {
                item.Play();
            };
            AudioManager.Instance.PlayAudio(1);
            _gameGo.GoalTapStarted=true;    
        }
    }
}
