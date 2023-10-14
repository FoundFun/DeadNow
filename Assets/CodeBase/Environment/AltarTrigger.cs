using System;
using CodeBase.Enemy;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Environment
{
    public class AltarTrigger : MonoBehaviour
    {
        public EnemyTrigger Wizard1;
        public EnemyTrigger Wizard2;
        public EnemyTrigger Monah;
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

                if (!Monah.IsDead && Wizard1.IsDead && Wizard2.IsDead)
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