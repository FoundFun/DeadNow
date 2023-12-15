using System.Collections;
using Lean.Localization;
using UnityEngine;

namespace CodeBase.Localization
{
    public class Localization : MonoBehaviour
    {
        [SerializeField] private LeanLocalization _leanLocalization;

        private IEnumerator Start()
        {
#if YANDEX_GAMES
            yield return new WaitUntil(() => YandexGamesSdk.IsInitialized);

            string localization = YandexGamesSdk.Environment.i18n.lang;

            localization = localization switch
            {
                DataLocalization.EnCulture => DataLocalization.English,
                DataLocalization.RuCulture => DataLocalization.Russian,
                DataLocalization.TrCulture => DataLocalization.Turkish,
                _ => localization
            };

            DataLocalization.CurrentLanguage = localization;
            _leanLocalization.SetCurrentLanguage(localization);
#endif
            yield break;
        }
    }
}