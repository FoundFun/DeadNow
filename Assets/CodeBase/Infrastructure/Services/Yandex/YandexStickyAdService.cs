using Agava.YandexGames;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public class YandexStickyAdService : IYandexStickyAdService
    {
        public void OnShowStickyAdButtonClick() => 
            StickyAd.Show();

        public void OnHideStickyAdButtonClick() => 
            StickyAd.Hide();
    }
}