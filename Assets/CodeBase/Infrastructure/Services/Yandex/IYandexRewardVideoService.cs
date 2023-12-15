using System;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public interface IYandexRewardVideoService
    {
        void ShowAds();
        event Action Reward;
    }
}