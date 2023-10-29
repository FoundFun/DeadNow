using System.Collections;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class BossMusicTarget : MonoBehaviour
    {
        public AudioSource Main;
        public AudioSource Boss;

        private bool _isBossMusic;

        private void Start()
        {
            Reset();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<PlayerAnimator>() && !_isBossMusic)
            {
                _isBossMusic = true;
                StartCoroutine(PlayBossMusic());
            }
        }

        private IEnumerator PlayBossMusic()
        {
            Boss.Play();
            
            while (Main.volume != 0)
            {
                Boss.volume += 0.01f;
                Main.volume -= 0.01f;
                
                yield return null;
            }
        
            while (Boss.volume != 1)
            {
                Boss.volume += 0.01f;

                yield return null;
            }
        }

        private void Reset()
        {
            Boss.volume = 0;
            _isBossMusic = false;
        }
    }
}
