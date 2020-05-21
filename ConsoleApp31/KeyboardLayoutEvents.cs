using System;

namespace ConsoleApp67
{
    class KeyboardLayoutEvents
    {
        private KeyboardInputProvider _inputPprovider;

        public event EventHandler OnLeftArrowPressed;
        public event EventHandler OnRightArrowPressed;
        public event EventHandler OnUpArrowPressed;
        public event EventHandler OnDownArrowPressed;
        public event EventHandler OnEscapePressed;
        public event EventHandler OnEnterPressed;

        public KeyboardLayoutEvents()
        {
            _inputPprovider = new KeyboardInputProvider();
            _inputPprovider.EventHandler += OnButtonPressedEvent;
        }

        protected void OnButtonPressedEvent(object sender, KeyboarEventArgs args)
        {
            EventHandler curEvent = null;

            switch (args.Key)
            {
                case ConsoleKey.LeftArrow: curEvent = OnLeftArrowPressed; break;
                case ConsoleKey.RightArrow: curEvent = OnRightArrowPressed; break;
                case ConsoleKey.UpArrow: curEvent = OnUpArrowPressed; break;
                case ConsoleKey.DownArrow: curEvent = OnDownArrowPressed; break;
                case ConsoleKey.Escape: curEvent = OnEscapePressed; break;
                case ConsoleKey.Enter: curEvent = OnEnterPressed; break;
            }

            curEvent?.Invoke(this, new EventArgs());
        }
    }
}