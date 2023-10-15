using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class WarGameOver : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public AudioSource War;
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
            War.volume = 0;
            CanvasGroup.alpha = 0;
            Title.gameObject.transform.localScale = Vector3.zero;
            TheEnd.gameObject.transform.localScale = Vector3.zero;
        }

        public void Open()
        {
            StartCoroutine(OnOpen());
        }

        public void Close()
        {
            CanvasGroup.alpha = 0;
        }

        private IEnumerator OnOpen()
        {
            while (Main.volume != 0)
            {
                Main.volume -= 0.01f;

                War.volume += 0.01f;

                yield return null;
            }

            while (War.volume != 1)
            {
                War.volume += 0.01f;

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