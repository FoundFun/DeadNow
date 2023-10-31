using System;
using System.Collections;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private GameOverCanvas _gameOver;
    [SerializeField] private float _waitingTimeOpenCanvas;
    [SerializeField] private Player _player;

    public static Action<int> GameOver;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitingTimeOpenCanvas);
        GameOver += StartGameOver;
    }

    private void StartGameOver(int animationDeath)
    {
        if (_coroutine != null)
            _coroutine = StartCoroutine(OnGameOver(animationDeath));
    }

    private IEnumerator OnGameOver(int animationDeath)
    {
        _player.AnimatorController.SetAnimation(Animation.Die);
        yield return _waitForSeconds;
        _gameOver.Open();
    }

    private void OnDestroy()
    {
        GameOver -= StartGameOver;
    }
}