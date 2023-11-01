namespace BasicTemplate.CodeBase.Yandex
{
    public class LeaderBoardModel
    {
        private readonly LineBoardView _view;
        private readonly int _number;
        private readonly string _name;
        private readonly int _score;

        public LeaderBoardModel(LineBoardView view,int number, int score, string name)
        {
            _view = view;
            _number = number;
            _name = name;
            _score = score;
        }

        public void SetValue() => 
            _view.SetValue(_number, _name, _score);
    }
}