# InputSharp
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

[![Nuget](https://img.shields.io/nuget/v/InputSharp?label=NuGet&style=plastic)](https://www.nuget.org/packages/InputSharp/)

InputSharp is a library and nuget package that allows you to simulate keyboard and mouse clicks in the Windows operating system.

# Examples
```csharp
using InputSharp;
using InputSharp.Extensions;
using InputSharp.InputCommands;

InputManager.ClickKey(ScanKey.A); // Direct way to simulate input
 
var builder = new InputSequenceBuilder(); // Creating builder
builder.ClickKey(ScanKey.A).Wait(1000).KeyDown(ScanKey.LShift)
.ClickKey(ScanKey.A).KeyUp(DirectKey.LShift); // Configuring builder
InputSequence input = builder.Build(); // Builder creates input sequence
input.Execute(); // Executing sequence
 
var input2 = new InputSequence();// Creating empty sequence
input2.Wheel(-120).Wait(1000).ClickKey(ScanKey.S);// Adding input commands (requires InputSharp.Extensions)
input2.Execute();
 
var input3 = new InputSequence();
input3.Add(new KeyboardCommand(ScanKey.T, KeyboardEvent.KeyClick)); // Adding input commands in sequence (requires InputSharp.InputCommands)
input3.Add(new MouseCommand(0,0, MouseMovement.SetPos));
input3.Execute();
```
# Realisation
- Library use P/Invoke and Windows user32.dll SendInput(). Method can use scan codes and virtual keys to identify keyboard keys (ScanKey and VirtualKey in code respectively).
