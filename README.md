Automatically Cleansup items on a per-GameObject basis, each dropped item will remember the time it was spawned, and every 60 seconds, a coroutine will run that will delete items that have been spawned for longer than configured allowed.

Default config:

```yaml
# Is the plugin Enabled?
is_enabled: true
# Enable/Disable debug printouts
debug: false
# Global Item Timer, all items not specified below will be deleted every this many minutes
global_timer: 15
# Item specific timers, in minutes. Will override global timer.
item_specific_timers:
  KeycardScientist: 5
  GunCOM15: 10
```
