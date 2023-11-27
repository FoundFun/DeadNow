using CodeBase.Logic;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeakerController))]
public class EnemyDialog : MonoBehaviour, IEventActivation, IEventDeactivation
{
    [SerializeField] private List<SpeakerText> _sayTexts;
    [SerializeField] private SpeakerController _speakerController;

    private void Start()
    {
        _speakerController.ResetTexts(_sayTexts);
    }

    public void Activate()
    {
        if (!enabled)
            return;

        _speakerController.ResetTexts(_sayTexts);

        foreach (var sayText in _sayTexts)
            _speakerController.ShowText(sayText);
    }

    public void Deactivate()
    {
        _speakerController.ResetTexts(_sayTexts);
        this.enabled = false;
    }
}
