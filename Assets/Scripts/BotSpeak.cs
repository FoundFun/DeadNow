using CodeBase.Enemy;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class BotSpeak : MonoBehaviour
    {
        public EnemySpeaker Speaker;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerAnimator>())
            {
                Speaker.ShowText(Speaker.Tutorial);
            }
        }
    }
}