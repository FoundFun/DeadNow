using System;
using System.Collections.Generic;
using BasicTemplate.CodeBase.Infrastructure;
using Cinemachine;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            HeroInput input,
            AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, input, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain,
                    services.Single<IGameFactory>(), services.Single<IPersistentProgressService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistentProgressService>(),
                    services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}