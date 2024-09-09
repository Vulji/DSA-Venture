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
    [SerializeField] private GameObject _goalPanel;
    [SerializeField] private GameObject _failedPanel;
    [SerializeField] private ParticleSystem _speedParticles;


    private void Awake()
    {
        _gameGo = FindObjectOfType<GameGo>();

        if (_goalPanel == null)
            _goalPanel = FindObjectOfType<Panel>(true).gameObject;
    }

    private void Update()
    {
        if(_gameGo.IsDead == true)
        {
            _failedPanel.SetActive(true);
        }
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
                AudioManager.Instance.PlaySound("Applause");
                _isEndingCelebrationPlaying = true;

            }
            if (_speedParticles.isPlaying)
            {
                _speedParticles.Stop();
            }    
            
            SaveSystem.Save();
           _gameGo.GoalTapStarted=true;
            _goalPanel.SetActive(true);
        }
    }
}
