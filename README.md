# RT Macros

These are tools that were created to be used by allowance audit and allowance billing teams.

## Note

Please note that the code in this workbook is from when I first started to learn to program to a few years of expereince. Unfortunately, this has made it messy and hard to follow at times and I was unable to go back and clean things up ☹

That said, best of luck to those that inherit this mess! 😊

![Farley Scared](https://media.giphy.com/media/NIvUx6LX6w3lu/giphy.gif)

## Overview

Most all of the tools are written in VBA and are located in the file `RT_Macros.xlsb`.

Each user get's a copy of this workbook saved to `C:\rtmacros` on their local machine.

This workbook is hidden by default so it is open in the background after the user runs `RT_Macros_Box` from the command ribbon.

## Config Files

- [config.json](config.json) - This contains version numbers and group lists for the three different user groups: stable, insider, and tester. Users can be added or removed inside this file and versions can be updated in this as well. This is the file that each users system will read to check for updates.
- [.env](.env) - This file has only recently been created so it has not been used very much. But is a great place to store variables to be used with the `env` class object in `RT_Macros`. Can be used to change variables in a testing version or a version that is being used by all members.
- [bouncerReportEmailer.json](data/bouncerReportEmailer.json) - Email list for the bouncer report that is sent out every week. Array of email addresses.
- [Note.txt](data/Note.txt) - Is the message that will be displayed on the main dashboard of `RT_Macros`. ![Dashboard Notes](images/dashboard-notes.jpg)

## Version Control and Distribution

These are the instructions to save updates made to the code and optionally push out the update to users.

![](https://media.giphy.com/media/1Qmn2CFhz1E2dPMcTc/giphy.gif)

### How it works?

Every time a user opens up the main form in RT_Macros it call a global function `CheckForUpdates`. This function reads a config file and get's the current version that users should be on and compares it to the version they are currently using. If they do not match then the updated version is then copied over from the shared folder into the users own folder (`C:\rtmacros`).

### How to Save updates?

In the the VBE (visual basic editor) immediate window, type in `Version` and provide what type of update it is `major|minor|patch`. This will update the variable `VersionNumber` and increment it based on [semantic versioning](https://semver.org/) and save that version to the [shared folder](versions) using the format `x.x.x RT_Macros.xlsb`.

![Immediate window](images/immediate-version.JPG)

By default it will then open a prompt to see if you want to push updates to any user group.

### How to push updates?

To push out updates to the various user groups you can manually change it in the [config file](../config.json). This is where you can also control the users under each group.

## Additional Update Process

Open "Version Control" Module in VBA RT tools. (Open a blank Excel sheet and press ALT+F11)

1.      At the top of the Version Control module change the constant  "Public Const VersionNumber As String =" to the next version desired. "X.X.X". 
2.       Scroll through the module until you see "Private Sub SaveUpdatedVersion()"
3.      Place Cursor within this Sub
4.       Open the Immediate Window in VBA console (Ctrl+G)
5.      In the Immediate Window type "SaveUpdatedVersion"
6.      Press F5 - and wait for a prompt box to appear.
7.      Enter the reason for the update. 
8.      Click if you want this version to be pushed to testers or all
9.      To change who has access to this file in the future see the [config file](../config.json)
10.     Push an update for all users by changing the Config file to the newest file. Cna also be done to fall back to a past stable version if need be.



