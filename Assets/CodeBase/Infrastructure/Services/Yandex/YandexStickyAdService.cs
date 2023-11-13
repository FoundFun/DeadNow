using Agava.YandexGames;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexStickyAdService : IYandexStickyAdService
    {
        public void OnShowStickyAdButtonClick() => 
            StickyAd.Show();

        public void OnHideStickyAdButtonClick() => 
            StickyAd.Hide();
    }
}