using System;
using TMPro;
using UnityEngine;

[Serializable]
public class TextParameters
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Vector3 _textSize;
    [SerializeField] private float _textFade;
    [SerializeField] private float _textResizeDuration;
    [SerializeField] private float _waitingTime;

    public TextMeshProUGUI Text => _text;
    public Vector3 TextSize => _textSize;
    public float TextFade => _textFade;
    public float TextResizeDuration => _textResizeDuration;
    public float WaitingTime => _waitingTime;
}
