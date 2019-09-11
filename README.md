# HBRelog
A Relogger for World of Warcraft and Honorbuddy with task support. 
Releases can be downloaded from [here](https://github.com/highvoltz/HBRelog/releases/latest).

### Requirements
* Windows Vista SP2 or a newer windows. 
* .Net 4.6.1 - [link](https://www.microsoft.com/en-us/download/details.aspx?id=49982)
* Visual C++ Redist. for Visual Studio 2015 - [link](https://www.microsoft.com/en-us/download/details.aspx?id=48145)
* World of Warcraft - http://www.battle.net
* Honorbuddy - http://www.honorbuddy.com

### Features
* Automatically logs into WoW and starts up Honorbuddy
* Completely out of process.
* Options to choose which botbase, profile and combat routine to run
* WoW and Honorbuddy crash detection
* Automatically scans for new memory offsets whenever WoW updates
* WoW window re-size, placement and custom title
* Authenticator support
* Task system. 

### Installation 
You can either download and build the source using Visual Studio (project file is from VS2013)
or download the binaries from [here](https://github.com/highvoltz/HBRelog/releases/latest).
There is no installer, simply extract zip into any folder and run the HBRelog executable.



### 修复记录
#### 2019-09-11 
* 把原来的GreyMagic库换成了Process.Net,妄想一步登天，直接使用。然而完全忘记了 wow\wowpattern.cs这回事。
* 希望看到的大能能顺便教一手。


