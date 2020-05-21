using System;

namespace ConsoleApp67
{
    partial class Program
    {
        interface IInputEventProvider<T> where T : EventArgs
        {
            event EventHandler<T> EventHandler;          
        }
    }
}