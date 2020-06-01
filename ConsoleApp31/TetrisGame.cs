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

        private int _currentFrameSkip = 9;
        private int _countFrameSkip = 1;

        private const int QUEUE_CAPACITY = 3;
        private ConsoleKey _lastPressedKey;

        public TetrisGame() : base(new ConsoleContainer(10, 20))
        {
            _figureQueue = new Queue<Figure>(QUEUE_CAPACITY);
            _layoutEventsProvider = new KeyboardLayoutEvents();

            RefillQueue();
        }

        public void GameLogic()
        {
            // _countFrameSkip = 1;
            /*if (_gameContainer.RenderedFrame == null)
            {
                _gameContainer.SetRenderFrame();
            }*/
            Frame lastFrame = _gameContainer.RenderedFrame;

            if (_currentFigure == null)
            {
                _currentFigure = _figureQueue.Dequeue();
                SubscribeFigureBehavior();
                RefillQueue();
            }
            else
            {
                DeleteLastFigure();
            }

            bool isBottomReached = false;

            if (_countFrameSkip >= _currentFrameSkip)
            {
                isBottomReached = FigureBehavior.MoveDown(_currentFigure, _gameContainer);
                _countFrameSkip = 1;
            }
            else
                _countFrameSkip++;

            lastFrame.CombineWith(_currentFigure.Position.X, _currentFigure.Position.Y, _currentFigure.Pixels);

            _gameContainer.SetRenderFrame(lastFrame);
            _gameContainer.RenderFrame();

            if (isBottomReached)
            {
                UnSubscribeFigureBehavior();
                _currentFigure = null;
            }
        }

        private void DeleteLastFigure()
        {
            _gameContainer?.RenderedFrame?.DeletePixels(_currentFigure.Position.X, _currentFigure.Position.Y, _currentFigure.Pixels);
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
            _layoutEventsProvider.OnRightArrowPressed += OnRightArrowClick;
        }
        private void UnSubscribeFigureBehavior()
        {
            _layoutEventsProvider.OnLeftArrowPressed -= OnLeftArrowClick;
            _layoutEventsProvider.OnRightArrowPressed -= OnRightArrowClick;
        }

        private void OnLeftArrowClick(object sender, EventArgs e)
        {
            FigureBehavior.MoveLeft(_currentFigure, _gameContainer);
        }
        private void OnRightArrowClick(object sender, EventArgs e)
        {
            FigureBehavior.MoveRight(_currentFigure, _gameContainer);
        }

        private void RefillQueue()
        {
            int comp = QUEUE_CAPACITY - _figureQueue.Count;
            for (int i = 0; i < comp; i++)
            {
                _figureQueue.Enqueue(Figure.CentredFigue(_gameContainer.Width));
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
