# On Screen Console

Based on [https://answers.unity.com/questions/1020051/print-debuglog-to-screen-c.html](https://answers.unity.com/questions/1020051/print-debuglog-to-screen-c.html)

![Alt text](readmeImages/example0.jpg?raw=true "Title")

Prints Debug.Log, Debug.LogWarning, Debug.LogError and Exceptions to Screen through Unity OnGUI
How to Use
- Demo scenes are available
- Place the OnScreenConsoleHandler prefab into your scene
- All debug log calls will be routed to both unity console and the GUI console
- Font size and other settings can be changed on the OnScreenConsoleHandler script

Notes
- Buttons do not work in editor
- Logs will be printed in editor, without play mode