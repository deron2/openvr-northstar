project(NorthstarLauncher LANGUAGES CSharp)

include(CSharpUtilities)

#FILE(TO_NATIVE_PATH "${CMAKE_CURRENT_SOURCE_DIR}" DOS_STYLE_SOURCE_DIR)

#include_external_msproject(
#    NorthstarLauncher "${CMAKE_CURRENT_SOURCE_DIR}/NorthstarLauncher.csproj"
#    TYPE FAE04EC0-301F-11D3-BF4B-00C04F79EFBC)

set(NorthstarLauncher_SOURCES 
    App.config
    App.xaml
    App.xaml.cs
    MainWindow.xaml
    MainWindow.xaml.cs
    leap_images/explodedview.jpg
    steamvrconfig.json
    packages.config
    Resources/icon.ico
    Properties/AssemblyInfo.cs
    Properties/Resources.Designer.cs
    Properties/Resources.resx
    Properties/Settings.Designer.cs
    Properties/Settings.settings
)

configure_file(${CMAKE_CURRENT_SOURCE_DIR}/steamvrconfig.json ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/steamvrconfig.json COPYONLY)
file(COPY Resources DESTINATION ${CMAKE_RUNTIME_OUTPUT_DIRECTORY})

#CMAKE_RUNTIME_OUTPUT_DIRECTORY
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_RUNTIME_OUTPUT_DIRECTORY})
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_RUNTIME_OUTPUT_DIRECTORY})

# Then set the file property.
set_property(SOURCE leap_images/explodedview.jpg PROPERTY VS_TOOL_OVERRIDE "Resource")
set_property(SOURCE Resources/icon.ico PROPERTY VS_TOOL_OVERRIDE "Resource")

# Define the executable, including any .cs files. 
# The .resx and other Properties files are optional here, but including them makes them visible in the VS solution for easy editing. 
add_executable(NorthstarLauncher ${NorthstarLauncher_SOURCES})

# Set the source file properties for Windows Forms use.
csharp_set_windows_forms_properties(${NorthstarLauncher_SOURCES})

csharp_set_xaml_cs_properties(
    App.xaml
    App.xaml.cs
    MainWindow.xaml
    MainWindow.xaml.cs
    Properties/AssemblyInfo.cs
    Properties/Resources.Designer.cs
    Properties/Resources.resx
    Properties/Settings.Designer.cs
    Properties/Settings.settings
    Resources/icon.ico
)

set_property(SOURCE App.xaml PROPERTY VS_XAML_TYPE "ApplicationDefinition")

# Set the .NET Framework version for the executable.
#set_property(TARGET NorthstarLauncher PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2")
set_property(TARGET NorthstarLauncher PROPERTY DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2")
set_property(TARGET NorthstarLauncher PROPERTY WIN32_EXECUTABLE TRUE)

set_property(TARGET NorthstarLauncher PROPERTY VS_GLOBAL_ApplicationIcon "${CMAKE_CURRENT_SOURCE_DIR}/Resources/icon.ico")    

# NuGet package references
set_property(TARGET NorthstarLauncher PROPERTY VS_PACKAGE_REFERENCES "MahApps.Metro_1.6.5;Newtonsoft.Json_12.0.2;ControlzEx_3.0.2.4")
# Add in the .NET reference libraries.
set_property(TARGET NorthstarLauncher PROPERTY VS_DOTNET_REFERENCES "Microsoft.CSharp;PresentationCore;PresentationFramework;System;System.Core;System.Data;System.Data.DataSetExtensions;System.IO.Compression.FileSystem;System.Net.Http;System.Xaml;System.Xml;System.Xml.Linq;System.Windows.Forms;WindowsBase")


get_cmake_property(_variableNames VARIABLES)
list (SORT _variableNames)
foreach (_variableName ${_variableNames})
    #message(STATUS "${_variableName}=${${_variableName}}")
endforeach()