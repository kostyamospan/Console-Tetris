using System;

namespace Tetris
{
    class KeyboarEventArgs : EventArgs
    {
        public ConsoleKey Key { get; set; }
    }
}