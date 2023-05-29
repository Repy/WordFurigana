#define MyAppName "WordFurigana"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Repy"
#define MyAppURL "https://github.com/Repy/WordFurigana/"

[Setup]
AppId={{F2FFA6B1-E314-48C4-8914-62C17B789FFF}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\Repy\{#MyAppName}
DisableDirPage=yes
DefaultGroupName=a
DisableProgramGroupPage=yes
LicenseFile=..\LICENSE.txt
PrivilegesRequired=lowest
OutputDir=..
OutputBaseFilename=WordFuriganaSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Files]
Source: "..\WordFurigana\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Office\Word\Addins\Repy.WordFurigana"; Flags: uninsdeletekey; ValueType: string; ValueName: "Manifest"; ValueData: "{app}\WordFurigana.vsto|vstolocal"
Root: HKCU; Subkey: "Software\Microsoft\Office\Word\Addins\Repy.WordFurigana"; Flags: uninsdeletekey; ValueType: string; ValueName: "Description"; ValueData: "WordFurigana"
Root: HKCU; Subkey: "Software\Microsoft\Office\Word\Addins\Repy.WordFurigana"; Flags: uninsdeletekey; ValueType: string; ValueName: "FriendlyName"; ValueData: "WordFurigana"
Root: HKCU; Subkey: "Software\Microsoft\Office\Word\Addins\Repy.WordFurigana"; Flags: uninsdeletekey; ValueType: dword; ValueName: "LoadBehavior"; ValueData: 3
