using System.Collections;
using Agava.YandexGames;
using BasicTemplate.CodeBase.StaticData;
using Lean.Localization;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class YandexInitialization : MonoBehaviour
    {
        private Coroutine _coroutine;
        private LeanLocalization _leanLocalization;

        public bool IsInitialized => YandexGamesSdk.IsInitialized;

        public void Construct(LeanLocalization leanLocalization) => 
            _leanLocalization = leanLocalization;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
            PlayerAccount.AuthorizedInBackground += OnAuthorizedInBackground;
        }

        private IEnumerator Start()
        {
#if !YANDEX_GAMES
            yield break;
#endif
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Init());

            yield return YandexGamesSdk.Initialize();
        }

        private void OnDestroy() => 
            PlayerAccount.AuthorizedInBackground -= OnAuthorizedInBackground;

        private IEnumerator Init()
        {
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
        }

        private void OnAuthorizedInBackground()
        {
            Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
        }
    }
}