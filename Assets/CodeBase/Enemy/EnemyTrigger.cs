using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerTrigger;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if ((_layerTrigger.value & (1 << col.gameObject.layer)) != 0)
            {
                EventController.ActivateEvent<EnemyDialog>(gameObject);
            }
        }
    }
}