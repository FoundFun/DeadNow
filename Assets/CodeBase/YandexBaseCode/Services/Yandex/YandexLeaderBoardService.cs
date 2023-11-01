using System.Linq;
using Agava.YandexGames;
using BasicTemplate.CodeBase.StaticData;
using BasicTemplate.CodeBase.Yandex;
using Lean.Localization;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexLeaderBoardService : IYandexLeaderBoardService
    {
        private readonly YandexLeaderBoardView _view;
        private readonly YandexAuthorizationView _authorizationView;

        public YandexLeaderBoardService(YandexLeaderBoardView view, YandexAuthorizationView authorizationView)
        {
            _view = view;
            _authorizationView = authorizationView;

            Enable();
        }

        public void SetScore(int score)
        {
            Leaderboard.GetPlayerEntry("TheBestLevel", (result) =>
            {
                if (result.score < score)
                    Leaderboard.SetScore("TheBestLevel", score);
            });
        }

        public int GetScore()
        {
            int score = 0;
            
            Leaderboard.GetPlayerEntry("TheBestLevel", (result) =>
            {
                score = result.score;
            });

            return score;
        }

        private void OnGetLeaderboardEntriesButtonClick()
        {
            Clear();

            Leaderboard.GetEntries("TheBestLevel", (result) =>
            {
                for (int i = 0; i < result.entries.Take(_view.LineBoards.Count).Count(); i++)
                {
                    string publicName = result.entries[i].player.publicName;
                    int publicScore = result.entries[i].score;

                    if (string.IsNullOrEmpty(publicName))
                    {
                        publicName = DataLocalization.CurrentLanguage switch
                        {
                            DataLocalization.English => DataLocalization.NullNameEnglish,
                            DataLocalization.Russian => DataLocalization.NullNameRussian,
                            DataLocalization.Turkish => DataLocalization.NullNameTurkish,
                            _ => DataLocalization.NullNameEnglish
                        };
                    }

                    SetValueLeaderBord(i, publicScore, publicName);
                }
            });
        }

        private void Clear()
        {
            foreach (LineBoardView bord in _view.LineBoards)
                bord.Clear();
        }

        private void SetValueLeaderBord(int index, int publicScore, string publicName)
        {
            LeaderBoardModel leaderBoardModel =
                new LeaderBoardModel(_view.LineBoards[index], index + 1, publicScore, publicName);

            leaderBoardModel.SetValue();
        }

        private void Open()
        {
#if YANDEX_GAMES
            if (!PlayerAccount.IsAuthorized)
            {
                _authorizationView.Open();

                return;
            }
#endif
            OnGetLeaderboardEntriesButtonClick();
            _view.OpenTopListPlayer();
        }

        private void Enable() =>
            _view.Open += Open;

        private void Disable() =>
            _view.Open -= Open;
    }
}