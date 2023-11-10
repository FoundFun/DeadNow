using UnityEngine;

namespace CodeBase.Enemy
{
    public class KnightController : MonoBehaviour
    {
        [SerializeField] private EnemyTrigger _knight;
        [SerializeField] private GameObject _deadKnight;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_knight.IsDead)
            {
                _knight.gameObject.SetActive(false);
                _deadKnight.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}