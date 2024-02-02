using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    //private Transform _cameraTransform;
    //private Transform _canvasTransform;
    private Transform _unitTransform;

    [SerializeField] private TextMeshPro _enemyLevelText;
    [SerializeField] private Vector3 _offset;

    //if commented aspects aren't needed remove them

    void Start()
    {
        //_cameraTransform = Camera.main.transform;
        //_canvasTransform = FindAnyObjectByType<Canvas>().transform;
        _unitTransform = transform.parent;

        _enemyLevelText = GetComponent<TextMeshPro>();
        int _importedLevel = _unitTransform.GetComponentInParent<Enemy>().Level;
        _enemyLevelText.text = "LVL:" + _importedLevel;

        //transform.SetParent(_canvasTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (_unitTransform == null)
            return;
        transform.position = _unitTransform.position + _offset;
    }
}
