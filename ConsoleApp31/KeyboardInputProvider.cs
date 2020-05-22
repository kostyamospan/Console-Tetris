using System;
using System.Threading.Tasks;

namespace Tetris
{
    internal class KeyboardInputProvider : IInputEventProvider<KeyboarEventArgs>
    {
        public event EventHandler<KeyboarEventArgs> EventHandler;

        public Task Task { get; private set; }

        public KeyboardInputProvider()
        {
            Task = Task.Factory.StartNew(() =>
            {
                do
                {
                    var key = Console.ReadKey();
                    OnButtonPressed(new KeyboarEventArgs { Key = key.Key });
                } while (true);
            });
        }

        protected virtual void OnButtonPressed(KeyboarEventArgs e) => EventHandler?.Invoke(this, e);
    }
}