using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Game
    {   

        protected ConsoleContainer _gameContainer;
        protected WindowRefreshEventProvider _refreshEventProvider;


        public Game(ConsoleContainer container)
        {
            _refreshEventProvider = WindowRefreshEventProvider.GetInstance();
            _gameContainer = container;     
        }


        protected abstract void OnRefresh(object sender, EventArgs e);
            
        public virtual void StartGame()
        {
            _refreshEventProvider.RefreshEvent += OnRefresh;
        }
        public virtual void EndGame()
        {
            _refreshEventProvider.RefreshEvent -= OnRefresh;
        }

       // public void 
        protected class WindowRefreshEventProvider
        {
            private static WindowRefreshEventProvider _instance;

            public event EventHandler RefreshEvent;
            public Task UsedTask { get; private set; }

            public const int FRAMES_PER_SECOND = 10;

            private WindowRefreshEventProvider()
            {
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        Thread.Sleep(1000 / FRAMES_PER_SECOND);
                        OnRefresh(this, new EventArgs());
                    } while (true);
                });
            }

            private void OnRefresh(object sender, EventArgs args) => RefreshEvent?.Invoke(sender, args);


            public static WindowRefreshEventProvider GetInstance()
            {
                if (_instance == null)
                    _instance = new WindowRefreshEventProvider();

                return _instance;
            }
        }

    }
}
