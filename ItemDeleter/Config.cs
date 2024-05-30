using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;


namespace ItemDeleter
{
    public class Config : IConfig
    {
        [Description("Is the plugin Enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Enable/Disable debug printouts")]
        public bool Debug { get; set; } = false;
        [Description("Global Item Timer, all items not specified below will be deleted every this many minutes")]
        public float GlobalTimer { get; set; } = 15f;
        [Description("Item specific timers, in minutes. Will override global timer.")]
        public Dictionary<ItemType, float> ItemSpecificTimers { get; set; } = new Dictionary<ItemType, float>
    {
        { ItemType.KeycardScientist, 5f },
        { ItemType.GunCOM15, 10f }
    };

    }
}
