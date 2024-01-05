using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI _scoreTexte;

    // Update is called once per frame
    void Update()
    {
        _scoreTexte.text = "Score:" + GameManager.Instance.Score;
    }
}
