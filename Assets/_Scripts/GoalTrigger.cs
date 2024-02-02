using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private GameGo _gameGo;
    
    private void Awake()
    {
        _gameGo = FindObjectOfType<GameGo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SaveSystem.Save();
            _gameGo.GoalTapStarted=true;    
        }
    }
}
