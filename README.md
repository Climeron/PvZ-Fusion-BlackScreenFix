# BlackScreenFix
A small mod that fixes the problem with a black screen when starting the game.
Relevant for version 2.1.4.
# Installation
1. Download and install [MelonLoader](https://github.com/LavaGang/MelonLoader.Installer/releases).
2. Download the [mod](https://github.com/Climeron/PvZ-Fusion-BlackScreenFix/releases) (.dll) for your version of PvZ.
3. Download [coremod](https://github.com/Climeron/PvZ-Fusion-Tools/releases) (.dll) version not higher than this mod version, but the latest possible.
4. Paste the mod file into the Mods folder in the game directory.
5. Have fun while playing the game.
# Cause of the problem
The main menu might not be appeared because the game did not initialize its files correctly. This is related to the selected system language, as some localizations use a "dot" as a separator for fractional numbers, while others use a "comma". The game simply did not know how to handle values ​​with a separator that did not match the selected system language. Therefore, the problem could be solved by selecting, for example, the English as the system language.
