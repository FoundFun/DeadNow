using UnityEngine;

namespace CodeBase.Hero
{
    public class AltarTrigger : MonoBehaviour
    {
        public bool AltarComplete { get; private set; }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<HeroAttack>().IsAttack)
                AltarComplete = true;
        }
    }
}