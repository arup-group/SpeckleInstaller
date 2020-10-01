# Speckle Installer - CX

![Installer Builds](https://img.shields.io/github/workflow/status/arup-group/speckleinstaller/Create%20Installer)![GitHub All Releases](https://img.shields.io/github/downloads/arup-group/speckleinstaller/total)

![image](https://user-images.githubusercontent.com/2679513/48942587-fba54a00-ef17-11e8-8708-65f6be50ebe0.png) 

Arup Speckle desktop client installer for:

- Grasshopper
- Rhino
- Dynamo
- [SpeckleCoreGeometry](https://github.com/speckleworks/SpeckleCoreGeometry)
- (New) [GSA](https://github.com/arup-group/SpeckleGSA)

The installer does not require admin privileges and auto updates!

## Creating a Release

1. Select Actions Tab
2. Select `Create installer` workflow
3. Press the `Run Workflow` button
4. Select the `Master` branch
5. Input the first three digits of the release version in the input box. e.g. `1.8.32`
6. Press the `Run Workflow` button

![gif on how to create a release](https://raw.githubusercontent.com/arup-group/SpeckleInstaller/master/Docs/how-to-make-a-release.gif)

## Installer tool
This project uses [Inno Setup](http://www.jrsoftware.org/) to create the installer.

If you'd like to contribute to the project, please first head over to [Inno Setup download page](http://www.jrsoftware.org/isdl.php) and install it. 
