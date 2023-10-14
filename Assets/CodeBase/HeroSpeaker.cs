using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroSpeaker : MonoBehaviour
{
    public Text MapsChange;

    private Coroutine _coroutine;

    public void ShowText(Text text)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnShowText(text));
    }

    private IEnumerator OnShowText(Text text)
    {
        text.gameObject.LeanScale(Vector3.one, 1).setEaseOutBounce();

        yield return new WaitForSeconds(4);
        
        text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
    }
}