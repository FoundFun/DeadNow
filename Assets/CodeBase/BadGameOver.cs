using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class BadGameOver : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public AudioSource Piano1;
        public AudioSource Main;
        public AudioSource War;
        public Text Thanks;
        public Text Title;
        public Text TheEnd;

        private void Start()
        {
            Reset();
        }

        private void Reset()
        {
            Piano1.volume = 0;
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
            Piano1.Play();
            
            while (Main.volume != 0)
            {
                Main.volume -= 0.01f;
                War.volume -= 0.01f;
                Piano1.volume += 0.01f;
                
                yield return null;
            }

            while (War.volume != 0)
            {
                War.volume -= 0.01f;
                
                yield return null;
            }
            
            while (Piano1.volume != 1)
            {
                Piano1.volume += 0.01f;

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