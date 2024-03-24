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

        if (_panel == null)
            _panel = FindObjectOfType<Panel>(true).gameObject;
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
            
            SaveSystem.Save();
           _gameGo.GoalTapStarted=true;
            _panel.SetActive(true);
        }
    }
}
