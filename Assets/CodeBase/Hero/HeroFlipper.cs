using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroFlipper : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;

        private void Update()
        {
            if (Input.GetAxis("Horizontal") < 0)
                SpriteRenderer.flipX = true;
            else if (Input.GetAxis("Horizontal") > 0)
                SpriteRenderer.flipX = false;
        }
    }
}