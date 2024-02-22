using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GoalTrigger : MonoBehaviour
{
    private GameGo _gameGo;
    private bool _isEndingCelebrationPlaying;
    [SerializeField] private ParticleSystem[] _particleSystem;
    [SerializeField] private GameObject _panel;


    private void Awake()
    {
        _gameGo = FindObjectOfType<GameGo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!_isEndingCelebrationPlaying)
            {
                foreach (ParticleSystem item in _particleSystem)
                {
                    item.Play();
                };
                AudioManager.Instance.PlayAudio(1);
                _isEndingCelebrationPlaying = true;
            }
            
            SaveSystem.Save();
           _gameGo.GoalTapStarted=true;
            _panel.SetActive(true);
        }
    }
}
