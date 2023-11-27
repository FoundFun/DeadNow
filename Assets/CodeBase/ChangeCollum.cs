using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase
{
    public class ChangeCollum : MonoBehaviour
    {
        [SerializeField] private GameObject CollumTarget;
        [SerializeField] private GameObject Collum;
        [SerializeField] private GameObject Ship;
        [SerializeField] private GameObject Enable;
        [SerializeField] private GameObject _hero;
        [SerializeField] private AudioSource Unlock;

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

                // if (_hero != null)
                    //EventController.ActivateEvent<SpeakerController>(_hero.gameObject);

                if (Enable != null)
                    Enable.SetActive(true);
                
                Unlock.Play();

                gameObject.SetActive(false);
            }
        }
    }
}