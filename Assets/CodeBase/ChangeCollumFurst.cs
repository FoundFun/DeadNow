using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class ChangeCollumFurst : MonoBehaviour
    {
        public GameObject CollumTarget;
        public GameObject Collum;
        public GameObject Ship;
        public HeroSpeaker Speaker;

        private AudioSource _explosionAudio;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<HeroAnimator>())
            {
                if (CollumTarget != null)
                    CollumTarget.SetActive(false);
                if (Collum != null)
                    Collum.SetActive(false);

                if (Ship != null)
                    Ship.SetActive(true);
                if (Speaker != null)
                    Speaker.ShowText(Speaker.MapsChange);

                gameObject.SetActive(false);
            }
        }
    }
}