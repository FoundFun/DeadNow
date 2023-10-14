using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class AltarTrigger : MonoBehaviour
    {
        public EnemyTrigger Wizard1;
        public EnemyTrigger Wizard2;
        public GameObject Fire;

        public event Action BadGameOver;
        public event Action GoodGameOver;

        public bool AltarComplete { get; private set; }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.GetComponent<HeroTransfer>().IsTransfer && !AltarComplete)
            {
                Debug.Log("GameOver");
                AltarComplete = true;
                Fire.SetActive(true);

                if (Wizard1.IsDead && Wizard2.IsDead)
                    GoodGameOver?.Invoke();
                else
                    BadGameOver?.Invoke();
            }
        }

        public void Reset()
        {
            AltarComplete = false;
            Fire.SetActive(false);
        }
    }
}