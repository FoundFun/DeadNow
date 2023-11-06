using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class ChangeCollum : MonoBehaviour
    {
        public GameObject CollumTarget;
        public GameObject Collum;
        public GameObject Ship;
        public GameObject Enable;
        public HeroSpeaker Speaker;
        public AudioSource Unlock;

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
                    Speaker.ShowText(Speaker.MapsChangeMessage);

                if (Enable != null)
                    Enable.SetActive(true);
                
                Unlock.Play();

                gameObject.SetActive(false);
            }
        }
    }
}