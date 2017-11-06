using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace UWPTestSignalRCore02
{
    public class SignalRClient
    {
        private HubConnection _hub;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public HubConnection SignalRHub { get { return _hub; } }

        public async void InitializeSignalR()
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://mini.local/testHub")
                .WithConsoleLogger()
                .Build();

            // var hubConnection = new HubConnection("https://mini.local/", false);
            // _hub = hubConnection.CreateHubProxy("testHub");

            _hub = hubConnection;

            _hub.On<string, double>("newUpdate", 
                (command, state) => ValueChanged?.Invoke(this, new ValueChangedEventArgs(command, state)));


            await _hub.StartAsync();
        }
    }
}
