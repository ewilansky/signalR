using Microsoft.AspNet.SignalR.Client;
using System;

namespace UWPTestSignalR
{
    public class SignalRClient
    {
        private IHubProxy _hub;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public IHubProxy SignalRHub { get { return _hub; } }

        public async void InitializeSignalR()
        {
            var hubConnection = new HubConnection("https://mini.local/testhub", false);
            _hub = hubConnection.CreateHubProxy("testHub");

            _hub.On <string, double> ("newUpdate",
                    (command, state) => ValueChanged?.Invoke(this, new ValueChangedEventArgs(command, state)));

            _hub.On<string>("send", data => {  });

            await hubConnection.Start();
        }
    }
}
