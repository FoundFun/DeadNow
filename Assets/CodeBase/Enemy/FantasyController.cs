using UnityEngine;

namespace CodeBase.Enemy
{
    public class FantasyController : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _fantasyWarrior;
        [SerializeField] private GameObject _idleFantasyWarrior;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_fantasyWarrior.IsDead)
            {
                _fantasyWarrior.gameObject.SetActive(false);
                _idleFantasyWarrior.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}