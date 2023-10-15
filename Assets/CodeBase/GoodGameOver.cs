using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class GoodGameOver : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public AudioSource Piano4;
        public AudioSource Main;
        public Text Thanks;
        public Text Title;
        public Text TheEnd;

        private void Start()
        {
            Reset();
        }

        private void Reset()
        {
            Piano4.volume = 0;
            CanvasGroup.alpha = 0;
            Title.gameObject.transform.localScale = Vector3.zero;
            TheEnd.gameObject.transform.localScale = Vector3.zero;
        }

        public void Open()
        {
            StartCoroutine(OnOpen());
        }

        private IEnumerator OnOpen()
        {
            Piano4.Play();
            
            while (Main.volume != 0)
            {
                Main.volume -= 0.01f;
                
                Piano4.volume += 0.01f;
                
                yield return null;
            }
            
            while (Piano4.volume != 1)
            {
                Piano4.volume += 0.01f;

                yield return null;
            }

            while (CanvasGroup.alpha != 1)
            {
                CanvasGroup.alpha += 0.002f;
                
                yield return null;
            }

            TheEnd.gameObject.LeanScale(Vector3.one, 2f).setEaseOutBounce();

            yield return new WaitForSeconds(2f);

            Title.gameObject.LeanScale(Vector3.one, 2f).setEaseOutBounce();

            yield return new WaitForSeconds(3f);

            Thanks.gameObject.LeanMoveLocalY(2580, 50);
        }
    }
}