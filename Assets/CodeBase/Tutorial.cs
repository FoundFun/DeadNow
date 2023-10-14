using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public Text WASD;
    public Text Space;
    public Text LShift;
    public Text LCTRL;

    private IEnumerator Start()
    {
        WASD.gameObject.LeanScale(Vector3.one, 2).setEaseOutBounce();

        yield return new WaitForSeconds(2);
        
        Space.gameObject.LeanScale(Vector3.one, 2).setEaseOutBounce();

        yield return new WaitForSeconds(2);
        
        LShift.gameObject.LeanScale(Vector3.one, 2).setEaseOutBounce();

        yield return new WaitForSeconds(2);
        
        LCTRL.gameObject.LeanScale(Vector3.one, 2).setEaseOutBounce();

        yield return new WaitForSeconds(5);

        while (CanvasGroup.alpha != 0)
        {
            CanvasGroup.alpha -= 0.01f;

            yield return null;
        }
    }
}