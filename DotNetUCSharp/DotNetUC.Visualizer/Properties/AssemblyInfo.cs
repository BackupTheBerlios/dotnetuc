using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Meta Information for the visualizer
[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(DotNetUC.Visualizer.PathVisualizer),
    typeof(DotNetUC.Visualizer.PathSerializer),
    Target = typeof(System.Drawing.Drawing2D.GraphicsPath),
    Description = "GraphicsPath Visualizer")]

[assembly: System.Diagnostics.DebuggerVisualizer(
   typeof(DotNetUC.Visualizer.ImageVisualizer),
   typeof(Microsoft.VisualStudio.DebuggerVisualizers.VisualizerObjectSource),
   Target = typeof(System.Drawing.Image),
   Description = "Image Visualizer")]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DotNetUC.Visualizer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Thomas Mentzel")]
[assembly: AssemblyProduct("DotNetUC.Visualizer")]
[assembly: AssemblyCopyright("Copyright © 2006 Thomas Mentzel")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("48d4af8c-fa01-4649-ae07-db6bd41d7e8d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("0.1.0")]
[assembly: AssemblyFileVersion("0.1.0")]
