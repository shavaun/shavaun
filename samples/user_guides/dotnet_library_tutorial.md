# Tutorial: Make a Windows Application with .Net That Displays Sheet Music

This tutorial walks you through the steps to use [Microsoft Visual Studio](https://visualstudio.microsoft.com/) to create a small Windows application that displays sheet music from a [MusicXML](https://www.musicxml.com) file.

## Requirements

To follow this tutorial, you will need the following:

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/) on Windows 10.
- A MusicXML file. There are many public domain MusicXML files available at the [Petrucci Music Library](https://imslp.org).
- Beginner-level familiarity with XML
- Beginner-level familiarity with C#

All required libraries will be installed through this tutorial.

## Step 1: Setup application environment

To setup the environment new application, perform the following steps within Visual Studio:

1. From the *File* menu, select *New* > *Project...*.
2. Select *WPF App (.NET Framework)* from the list of project templates and click *Next*.

   Tip: To assist with locating the correct template, type *WPF* into the *Search for templates* field. If you still do not see the *WPF App 
(.NET Framework)* template, click *Install more tools and features* and follow the steps to install it.

3. Enter "MusicSample" as the project name and click *Create*.

## Step 2: Install the Manufaktura library

[Manufaktura](http://manufaktura-controls.com/en-US/Home/) is a library that provides classes for creating and displaying sheet music. We will use it to load a MusicXML file and draw the sheet music in the application.

1. From the *Project* menu, select *Manage NuGet Packages...*.
2. Click *Browse* and enter "Manufaktura.Controls* into the *Search* field.
3. Select *Manufaktura.Controls.WPF" from the list of results and click *Install*.
4. Select *Manufaktura.Controls* from the list of results and click *Install*.
5. At the top of the *NuGet* tab, click *X* to close the tab.

## Step 3: Setup the data model class

To use Manufaktura, we need to create a class for the data model. This will contain the directions for what to draw and how to draw it.

1. In the *Solution Explorer* dockable window, right click the project name and select *Add* and then *Class...*. 

  Tip: If you do not see the *Solution Explorer* dockable window, press CTRL+ALT+L to open it.

2. In the *Name* field, enter "DataViewModel" and click *Add*.
3. At the top of the new class, replace the list of `using` statements with the following:

```
using System.Xml.Linq; // Used for loading the MusicXML file
using Manufaktura.Controls.Model; // Used for drawing the sheet music
using Manufaktura.Controls.Parser; // Used for interpreting the MusicXML file
```

4. In the body of the `LoadTestData()` method, insert the following code, replacing `[full path to MusicXML file]` with the full path to your MusicXML file:

```
var parser = new MusicXmlParser();
var score = parser.Parse(XDocument.Load(@"[full path to MusicXML file]"));
Data = score;
```

Your *DataViewModel.cs* file should now look like this:

```
using System.Xml.Linq;
using Manufaktura.Controls.Model;
using Manufaktura.Controls.Parser;

namespace MusicSample
{
    public class DataViewModel : ViewModel
    {
        private Score data;
        public Score Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(() => Data); }
        }
        public void LoadTestData()
        {
            var parser = new MusicXmlParser();
            var score = parser.Parse(XDocument.Load(@"C:\Users\name\Downloads\Gnossienne_No1.musicxml"));
            Data = score;
        }
    }
}
```

## Step 4: Update the XAML file to draw the sheet music

Now that the class has all of the code it needs to draw the sheet music when it is called, we need to update the XAML file to display the NoteViewer created by the DataViewModel.

1. Click the *MainWindow.xaml* tab to switch to that file.
2. Add the *Margin* attribute to the *Grid* tag and set it to a value of *10*.
3. Insert the following code so that it is inside the *Grid* tag:

```
<ManufakturaControls:NoteViewer ScoreSource="{Binding Data}" RenderingMode="SinglePage"/>
```

4. Hover your mouse over the *ManufakturaControls:NoteViewer* tag and press Alt+Enter on your keyboard. Visual Studio will provide a suggestion to add the missing namespace, press Enter again to automatically fill in the correct namespace.

Your *MainWindow.xaml* file should now look like this:

```
<Window x:Class="MusicSample.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MusicSample"
        xmlns:ManufakturaControls="clr-namespace:Manufaktura.Controls.WPF;assembly=Manufaktura.Controls.WPF"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Grid Margin="10">
        <ManufakturaControls:NoteViewer ScoreSource="{Binding Data}" RenderingMode="SinglePage"/>
    </Grid>
</Window>
    

```

## Step 5: Call the class

The only code left is to add the code that calls the DataViewModel class.

1. Click the *MainWindow.xaml.cs* tab to switch to that file.
2. In the *MainWindow* method, add the following code below `InitializeComponent();`:

```
var viewModel = new DataViewModel();
DataContext = viewModel;
viewModel.LoadTestData();
```

Your *MainWindow.xaml.cs* file should now look like this:

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new DataViewModel();
            DataContext = viewModel;
            viewModel.LoadTestData();
        }
    }
}
```

## Step 6: Run the application

Press F5 and Visual Studio will build and run your new application. You can resize the window if your sheet music is longer than the default window size. 


