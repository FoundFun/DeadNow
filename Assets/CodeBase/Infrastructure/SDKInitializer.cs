using System.Collections;
using Agava.YandexGames;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class SDKInitializer : MonoBehaviour
    {
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
            yield return YandexGamesSdk.Initialize();
        }

        private void OnDestroy() => 
            PlayerAccount.AuthorizedInBackground -= OnAuthorizedInBackground;

        private void OnAuthorizedInBackground() => 
            Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
    }
}