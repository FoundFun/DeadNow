using System;

namespace CodeBase.StaticData
{
    public class EventBus
    {
        private static EventBus _instance;

        public static EventBus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventBus();

                return _instance;
            }
        }

        public Action HeroJump;
        public Action HeroAttack;
        public Action HeroSquat;
        public Action GoodGameOver;
        public Action BadFireGameOver;
        public Action WarGameOver;
        public Action BadGameOver;
    }
}