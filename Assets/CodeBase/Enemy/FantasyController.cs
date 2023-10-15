using UnityEngine;

namespace CodeBase.Enemy
{
    public class FantasyController : MonoBehaviour
    {
        public EnemyTrigger FantasyWarrior;
        public GameObject IdleFantasyWarrior;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!FantasyWarrior.IsDead)
            {
                FantasyWarrior.gameObject.SetActive(false);
                IdleFantasyWarrior.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}