using Exiled.API.Features;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features.Pickups;
using System.Linq;

namespace ItemDeleter
{
    public class EventHandlers
    {
        private readonly Config _config;
        private readonly List<KeyValuePair<ItemType, GameObject>> _droppedItems = new List<KeyValuePair<ItemType, GameObject>>();
        private CoroutineHandle _itemCleanupCoroutine;
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public EventHandlers(Config config)
        {
            _config = config;
            _itemCleanupCoroutine = Timing.RunCoroutine(ItemCleanupRoutine());
        }
        public void OnItemDropped(DroppingItemEventArgs ev)
        {
            var droppedItem = ev.Item.Base.gameObject;
            var dropTimeComponent = droppedItem.AddComponent<DropTimeComponent>();
            _droppedItems.Add(new KeyValuePair<ItemType, GameObject>(ev.Item.Type, ev.Item.Base.gameObject));
        }
        private IEnumerator<float> ItemCleanupRoutine()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(60f); // Check every 60 seconds

                var currentTime = Time.time;

                foreach (var item in _droppedItems.ToList())
                {
                    float itemTimer;

                    if (_config.ItemSpecificTimers.TryGetValue(item.Key, out itemTimer))
                    {
                        itemTimer *= 60f; // Convert minutes to seconds
                    }
                    else
                    {
                        itemTimer = _config.GlobalTimer * 60f; // Use global timer if item-specific timer is not found
                    }

                    if (currentTime - item.Value.GetComponent<DropTimeComponent>().DropTime >= itemTimer)
                    {
                        Object.Destroy(item.Value);
                        _droppedItems.Remove(item);
                    }
                }
            }
        }
        }
}
