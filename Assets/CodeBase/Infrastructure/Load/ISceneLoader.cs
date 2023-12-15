using System;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.Load
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
        void Restart();
    }
}