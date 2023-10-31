using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpeaker : MonoBehaviour
{
    public TextMeshProUGUI Dead;
    public TextMeshProUGUI Tutorial;

    private Coroutine _coroutine;

    public void ShowText(TextMeshProUGUI text)
    {
        if (_coroutine != null)
            StartCoroutine(OnShowTwoText(text));
        else
            _coroutine = StartCoroutine(OnShowText(text));
    }

    private IEnumerator OnShowText(TextMeshProUGUI text)
    {
        //text.gameObject.LeanScale(new Vector3(0.009259259f, 0.009259259f, 0.009259259f), 1).setEaseOutBounce();

        yield return new WaitForSeconds(4);

        //text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
    }

    private IEnumerator OnShowTwoText(TextMeshProUGUI text)
    {
        //text.gameObject.LeanScale(new Vector3(0.009259259f, 0.009259259f, 0.009259259f), 1).setEaseOutBounce();

        yield return new WaitForSeconds(4);

        //text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
    }
}
