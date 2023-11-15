using System.Collections.Generic;
using Cinemachine;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressesReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        GameObject CreateHero(GameObject at);
        CinemachineVirtualCamera CreateCameraFollow();
        void Cleanup();
    }
}