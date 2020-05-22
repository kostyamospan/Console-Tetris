using System;

namespace Tetris
{
    internal interface IInputEventProvider<T> where T : EventArgs
    {
        event EventHandler<T> EventHandler;
    }
}