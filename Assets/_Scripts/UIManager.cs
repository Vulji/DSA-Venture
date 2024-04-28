using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI _scoreText;
     [SerializeField] private TextMeshProUGUI _levelText;

    void Update()
    {
        _scoreText.text = "Score:" + GameManager.Instance.Score;
        _levelText.text = "Level:" + GameManager.Instance.Level;
    }
}
