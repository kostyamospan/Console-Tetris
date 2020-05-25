using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrisGame : Game
    {
        public int Score { get; private set; }

        private Queue<Figure> _figureQueue;
        private Figure _currentFigure;
        private KeyboardLayoutEvents _layoutEventsProvider;

        private int _currentFrameSkip = 3;
        private int _countFrameSkip = 1;

        private const int QUEUE_CAPACITY = 3;

        public TetrisGame() : base(new ConsoleContainer(10,20))
        {
            _figureQueue = new Queue<Figure>(QUEUE_CAPACITY);
            _layoutEventsProvider = new KeyboardLayoutEvents();

            RefillQueue();
        }
        
        public void GameLogic()
        {
            _currentFigure = _figureQueue.Dequeue();
            RefillQueue();

            if (_countFrameSkip < _currentFrameSkip)
                _countFrameSkip++;
            else
            {
                _countFrameSkip = 1;

                if (_currentFigure == null)
                {
                    _currentFigure = _figureQueue.Dequeue();
                    RefillQueue();
                }
                  
                
                //_gameContainer.RenderedFrame.RandomizeFrame();
                _gameContainer.RenderFrame();
            }
        }
    
        protected override void OnRefresh(object sender, EventArgs e)
        {
            GameLogic();
             /*_gameContainer.RenderedFrame.RandomizeFrame();
            _gameContainer.RenderFrame();*/
        }
        
        private void SubscribeFigureBehavior()
        {
            _layoutEventsProvider.OnLeftArrowPressed += OnLeftArrowClick;
        }
        private void UnSubscribeFigureBehavior()
        {
            _layoutEventsProvider.OnLeftArrowPressed -= OnLeftArrowClick;
        }

        private void OnLeftArrowClick(object sender, EventArgs e)
        {
            if(_currentFigure != null) FigureBehavior.MoveLeft(_currentFigure, _gameContainer);
        }

        private void RefillQueue()
        {
            int comp = QUEUE_CAPACITY - _figureQueue.Count;
            for (int i = 0; i < comp; i++)
            {
                _figureQueue.Enqueue(Figure.RandomFigure());
            }
        }    
        protected static class FigureBehavior
        {
            internal static void MoveLeft(Figure figure, ConsoleContainer container)
            {
                figure.Position.X =
                    (figure.Position.X + container.Position.X - 1) > container.Position.X ? 
                        --figure.Position.X : figure.Position.X;
                    
            }
            internal static void MoveRight(Figure figure, ConsoleContainer container)
            {
                figure.Position.X =
                    (figure.Position.X + container.Position.X + figure.Width + 1) < container.Position.X + container.Width ?
                        ++figure.Position.X : figure.Position.X;
            }

            internal static bool MoveDown(Figure figure, ConsoleContainer container)
            {
                int oldY = figure.Position.Y;

                figure.Position.Y =
                    (figure.Position.Y + container.Position.Y + 1) < container.Position.Y + container.Height ?
                        ++figure.Position.Y : figure.Position.Y;

                if (oldY == figure.Position.Y) return true;
                return false;
            }
        }
    }
}
