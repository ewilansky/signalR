using System;

namespace UWPTestSignalR
{
    public class ValueChangedEventArgs : EventArgs
    {
        public string Command { get; private set; }
        public double State { get; private set; }
        public ValueChangedEventArgs(string command, double state)
        {
            Command = command;
            State = state;
        }
    }
}
