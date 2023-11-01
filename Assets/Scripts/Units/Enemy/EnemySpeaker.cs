using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeaker : MonoBehaviour
{
    [SerializeField] private List<TextParameters> _dialog;

    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();
    }

    public void ChangeSizeDialogText()
    {
        _sequence = DOTween.Sequence();
        foreach (var dialog in _dialog)
        {
            dialog.Text.gameObject.SetActive(true);
            AppendTween(dialog.Text.GetComponent<RectTransform>().DOSizeDelta(dialog.TextSize, dialog.TextResizeDuration), dialog.WaitingTime);
        }
    }

    public void ChangeFadeDialogText()
    {
        _sequence = DOTween.Sequence();
        foreach (var dialog in _dialog)
        {
            dialog.Text.gameObject.SetActive(true);
            AppendTween(dialog.Text.DOFade(dialog.TextFade, dialog.TextResizeDuration), dialog.WaitingTime);
        }
    }

    private void AppendTween(Tween tween, float intervalTime)
    {
        _sequence.Append(tween);
        _sequence.AppendInterval(intervalTime);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
