using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenUI : MonoBehaviour
{
    [SerializeField] private RectTransform _textRectTransform; 
    [SerializeField] private float _scaleFactor; 
    [SerializeField] private float _duration;

    void Start()
    {
        PulseText();
    }

    void PulseText()
    {

        LeanTween.scale(_textRectTransform, Vector3.one * _scaleFactor, _duration).setEase(LeanTweenType.easeOutBack);

        //LeanTween.scale(_textRectTransform, Vector3.one * _scaleFactor, _duration).setEase(LeanTweenType.easeInOutSine).setOnComplete(() =>
        //{
        //    LeanTween.scale(_textRectTransform, Vector3.one, _duration).setEase(LeanTweenType.easeInOutSine).setOnComplete(PulseText);
        //});
    }
}
