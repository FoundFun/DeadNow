using CodeBase.Hero;
using CodeBase.Logic.EnemySpawner;
using UnityEngine;

namespace CodeBase.Environment
{
    public class AltarTrigger : MonoBehaviour
    {
        [SerializeField] private SpawnerPoint Wizard1;
        [SerializeField] private SpawnerPoint Wizard2;
        [SerializeField] private SpawnerPoint Monah;
        [SerializeField] private GameObject Fire;
        [SerializeField] private GameObject Fire1;
        [SerializeField] private GameObject Fire2;
        [SerializeField] private AudioSource FireDeath;
        [SerializeField] private AudioSource DeathExplosion;
        
        public bool AltarComplete { get; private set; }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (Wizard1.Enemy.IsDead && !AltarComplete)
            {
                Fire1.SetActive(false);
            }

            if (Wizard2.Enemy.IsDead && !AltarComplete)
            {
                Fire2.SetActive(false);
            }

            if (other.GetComponent<HeroSquat>().IsSquat && !AltarComplete)
            {
                AltarComplete = true;
                
                other.GetComponent<HeroMove>().enabled = false;
                other.GetComponent<HeroJump>().enabled = false;
                other.GetComponent<HeroSquat>().enabled = false;
                other.GetComponent<HeroFlipper>().enabled = false;
                other.GetComponent<HeroAttack>().enabled = false;

                if (!Monah.Enemy.IsDead && Wizard1.Enemy.IsDead && Wizard2.Enemy.IsDead)
                {
                    other.GetComponent<HeroAnimator>().PlayFinallyDeath();
                    Fire.SetActive(false);
                    FireDeath.Play();
                    EventBus.Instance.GoodGameOver?.Invoke();
                }
                else
                {
                    other.GetComponent<HeroAnimator>().PlayDeath();
                    DeathExplosion.Play();
                    EventBus.Instance.BadFireGameOver?.Invoke();
                }
            }
        }

        public void Reset()
        {
            AltarComplete = false;
            Fire.SetActive(false);
        }
    }
}