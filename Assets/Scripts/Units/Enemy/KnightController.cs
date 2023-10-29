using UnityEngine;

namespace CodeBase.Enemy
{
    public class KnightController : MonoBehaviour
    {
        public EnemyTrigger Knight;
        public GameObject DeadKnight;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!Knight.IsDead)
            {
                Knight.gameObject.SetActive(false);
                DeadKnight.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}