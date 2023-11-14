using System;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public interface IYandexRewardVideoService
    {
        void ShowAds();
        event Action Reward;
    }
}