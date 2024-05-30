using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace ItemDeleter
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name { get; } = "ItemDeleter";
        public override string Author { get; } = "Benjamin01";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 9, 2);

        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            _eventHandlers = new EventHandlers(this);
            Player.DroppingItem += _eventHandlers.OnItemDropped;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            _eventHandlers = null;
            Player.DroppingItem -= _eventHandlers.OnItemDropped;
            base.OnDisabled();
        }
    }
}
