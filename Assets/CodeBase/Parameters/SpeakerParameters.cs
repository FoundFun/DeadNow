using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeakerParameters", menuName = "CustomParameters/SpeakerParameters")]
public class SpeakerParameters : ScriptableObject
{
    [SerializeField] private List<TextMeshProUGUI> _startTexts;
    [SerializeField] private List<TextMeshProUGUI> _dialogTexts;

    public List<TextMeshProUGUI> StartTexts => _startTexts;
    public List<TextMeshProUGUI> DialogTexts => _dialogTexts;
}
