using System;
using TMPro;
using UnityEngine;

[Serializable]
public class SpeakerText
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Vector3 _targetTextSize;
    [SerializeField] private int _timeTextShow;
    [SerializeField] private int _durationTextShow;

    public TextMeshProUGUI Text => _text;
    public Vector3 TargetTextSize => _targetTextSize;
    public int TimeTextShow => _timeTextShow;
    public int DurationTextShow => _durationTextShow;
}
