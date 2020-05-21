using System;

namespace ConsoleApp67
{

    interface IInputEventProvider<T> where T : EventArgs
    {
        event EventHandler<T> EventHandler;
    }

}