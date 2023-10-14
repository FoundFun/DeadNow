using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class BotSpeak : MonoBehaviour
    {
        public EnemySpeaker Speaker;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<HeroAnimator>())
            {
                Speaker.ShowText(Speaker.Tutorial);
            }
        }
    }
}