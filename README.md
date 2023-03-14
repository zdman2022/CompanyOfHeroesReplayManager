# Company Of Heroes 3 Replay Manager

Very simple app that runs in the task tray. It automatically renames files after a match. In the tray, you should see a "C3 RE" icon that you can click to open a window. 

Features
* Automatically renames the replay file after a match
* View the list of replays.  Select a replay to view the players and what map the replay is on.  Double click the replay to open the replay in COH3.
* Easily open the folder that contains the replays
* View a reference sheet on how to remove FOW and change the replay speed

Pre-Req: .NET 7.0 runtime (Download the runtime from https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Configuration
* Edit COH3ReplayManager.dll.config in a text editor
* Set the value of COH3Path to the path to your COH3 exe
* You can explicitly set where to find the replays by setting COH3PlaybackPath.  I'm not sure if this is useful but it's there if needed.

How to setup to automatically run:

* Extract zip to a location of your choosing
* Create a shortcut to the exe file
* Open the startup folder (Windows logo key + r, type shell:startup, then select OK)
* Copy and paste (or drag) the shortcut file to the Startup folder
