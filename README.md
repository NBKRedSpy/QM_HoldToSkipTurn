# Quasimorph Hold To Skip Turn
![thumbnail icon](media/thumbnail.png)
Ever have to wait twenty turns for a Baron to finally reach you and when spamming the space bar, accidentally skip one too many turns?

Maybe spammed space bar one too many times and now the Baron is four tiles closer?

This mod allows the user to hold down the space bar (or whatever the game's Skip Turn key is currently bound to) to skip turns until an enemy is seen or detected.

By default, the user must hold the space bar for one second and will skip turns every quarter second until released or stopped by enemy seen/detection.

*Important*: Just like the game's default rules, this currently doesn't stop skipping turns if an enemy caused damage.  I'm looking into this.

# Configuration
The mod's configuration can be changed on the Main Menu -> Mods -> WaitForEnemy.

If MCM is not installed, the configuration file can be directly edited at `%UserProfile%\AppData\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\HoldToSkipTurn\config.json`
\config.json`, and will be created on the first game run.

|Name|Default|Description|
|--|--|--|
|SkipTurnHoldDelay|1000|The delay in milliseconds the skip key must be held before this mod auto skips turns.|
|SkipRepeatDelay|250|When skip turn is held down, this is the delay in milliseconds before the action is repeated.|

# Enjoy the Mods?
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thank you!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_HoldToSkipTurn

# Change Log
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_HoldToSkipTurn/blob/main/CHANGELOG.md
