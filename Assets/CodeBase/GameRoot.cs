using System.Collections;
using CodeBase.Enemy;
using CodeBase.Environment;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class GameRoot : MonoBehaviour
    {
        public AltarTrigger AltarTrigger;
        public BossTarget BossTarget;
        public HeroAnimator HeroAnimator;

        public GoodGameOver Good;
        public BadGameOver Bad;
        public WarGameOver War;
        public FireGameOver Fire;

        private void OnEnable()
        {
            AltarTrigger.GoodGameOver += GoodGameOver;
            AltarTrigger.BadFireGameOver += BadFireGameOver;
            BossTarget.WarGameOver += WarGameOver;
            BossTarget.BadGameOver += BadGameOver;
        }

        private void OnDisable()
        {
            AltarTrigger.GoodGameOver -= GoodGameOver;
            AltarTrigger.BadFireGameOver -= BadFireGameOver;
            BossTarget.WarGameOver -= WarGameOver;
            BossTarget.BadGameOver -= BadGameOver;
        }

        private void GoodGameOver() => 
            StartCoroutine(OnGoodGameOver());

        private void BadGameOver() => 
            StartCoroutine(OnBadGameOver());

        private void BadFireGameOver() => 
            StartCoroutine(OnBadFireGameOver());

        private void WarGameOver() => 
            StartCoroutine(OnWarGameOver());

        private IEnumerator OnWarGameOver()
        {
            yield return new WaitForSeconds(3);

            War.Open();
        }

        private IEnumerator OnGoodGameOver()
        {
            HeroAnimator.PlayFinallyDeath();
            
            yield return new WaitForSeconds(3);

            Good.Open();
        }

        private IEnumerator OnBadGameOver()
        {
            HeroAnimator.PlayDeath();
            
            yield return new WaitForSeconds(3);

            Bad.Open();
        }

        private IEnumerator OnBadFireGameOver()
        {
            HeroAnimator.PlayDeath();
            
            yield return new WaitForSeconds(3);

            Fire.Open();
        }
    }
}