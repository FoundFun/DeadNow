using CodeBase.Infrastructure.Services.Yandex;
using UnityEngine;

namespace CodeBase.Data
{
    public class PlayerData
    {
        private const string BestScoreHash = "BestScoreHash";
        
        private readonly IYandexLeaderBoardService _yandexLeaderBoardService;

        public int LeaderBordScore { get; private set; }

        public PlayerData(IYandexLeaderBoardService yandexLeaderBoardService)
        {
            _yandexLeaderBoardService = yandexLeaderBoardService;
            
            if (PlayerPrefs.HasKey(BestScoreHash)) 
                LeaderBordScore = PlayerPrefs.GetInt(BestScoreHash);
        }

        public void ChangeLeaderBordScore(int bestScore)
        {
            LeaderBordScore = bestScore;
            PlayerPrefs.SetInt(BestScoreHash, bestScore);
#if YANDEX_GAMES
            _yandexLeaderBoardService.SetScore(LeaderBordScore);
#endif
        }
    }
}