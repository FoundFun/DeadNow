using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public TextMeshProUGUI ADTutorial;
    public TextMeshProUGUI SpaceTutorial;
    public TextMeshProUGUI LShiftTutorial;

    private IEnumerator Start()
    {
        ADTutorial.transform.DOScale(Vector3.one, 2).Elapsed();

        yield return new WaitForSeconds(2);
        
        SpaceTutorial.transform.DOScale(Vector3.one, 2).Elapsed();

        yield return new WaitForSeconds(2);
        
        LShiftTutorial.transform.DOScale(Vector3.one, 2).Elapsed();

        yield return new WaitForSeconds(5);

        while (CanvasGroup.alpha != 0)
        {
            CanvasGroup.alpha -= 0.01f;

            yield return null;
        }
    }
}