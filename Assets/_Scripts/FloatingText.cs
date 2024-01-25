using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    private Transform _cameraTransform;
    private Transform _unitTransform;
    private Transform _canvasTransform;

    [SerializeField] private TextMeshPro _enemyLevelText;
    [SerializeField] private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _unitTransform = transform.parent;
        _canvasTransform = FindAnyObjectByType<Canvas>().transform;

        _enemyLevelText = GetComponent<TextMeshPro>();
        int _importedLevel = _unitTransform.GetComponentInParent<Enemy>().Level;
        _enemyLevelText.text = "LVL:" + _importedLevel;

        transform.SetParent(_canvasTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (_unitTransform == null)
            return;
        transform.position = _unitTransform.position + _offset;
    }
}
