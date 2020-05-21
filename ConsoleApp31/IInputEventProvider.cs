using System;

namespace Tetris
{

    interface IInputEventProvider<T> where T : EventArgs
    {
        event EventHandler<T> EventHandler;
    }

}