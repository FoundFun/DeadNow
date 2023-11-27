using System;
using TMPro;
using UnityEngine;

[Serializable]
public class SpeakerText
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Vector3 _targetTextSize;
    [SerializeField] private float _timeTextShow;
    [SerializeField] private float _durationTextShow;

    public TextMeshProUGUI Text => _text;
    public Vector3 TargetTextSize => _targetTextSize;
    public float TimeTextShow => _timeTextShow;
    public float DurationTextShow => _durationTextShow;
}
