#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C739298EA3C36FFA3B5BE0573C2183B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Yetic___MeLo;


namespace Yetic___MeLo
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeWindow;

#line default
#line hidden


#line 39 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFullScreen;

#line default
#line hidden


#line 42 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOriginalScreen;

#line default
#line hidden


#line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTaskBar;

#line default
#line hidden


#line 50 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrev;

#line default
#line hidden


#line 53 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;

#line default
#line hidden


#line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;

#line default
#line hidden


#line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayerFullScreen;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Yetic - MeLo;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.closeWindow = ((System.Windows.Controls.Button)(target));

#line 35 "..\..\MainWindow.xaml"
                    this.closeWindow.Click += new System.Windows.RoutedEventHandler(this.closeWindow_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnFullScreen = ((System.Windows.Controls.Button)(target));

#line 39 "..\..\MainWindow.xaml"
                    this.btnFullScreen.Click += new System.Windows.RoutedEventHandler(this.fullScreen_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btnOriginalScreen = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\MainWindow.xaml"
                    this.btnOriginalScreen.Click += new System.Windows.RoutedEventHandler(this.originalScreen_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btnTaskBar = ((System.Windows.Controls.Button)(target));

#line 45 "..\..\MainWindow.xaml"
                    this.btnTaskBar.Click += new System.Windows.RoutedEventHandler(this.taskBar_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btnPrev = ((System.Windows.Controls.Button)(target));

#line 50 "..\..\MainWindow.xaml"
                    this.btnPrev.Click += new System.Windows.RoutedEventHandler(this.btnPrev_Click_1);

#line default
#line hidden
                    return;
                case 6:
                    this.btnPlay = ((System.Windows.Controls.Button)(target));

#line 53 "..\..\MainWindow.xaml"
                    this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.btnNext = ((System.Windows.Controls.Button)(target));

#line 57 "..\..\MainWindow.xaml"
                    this.btnNext.Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btnPlayerFullScreen = ((System.Windows.Controls.Button)(target));

#line 60 "..\..\MainWindow.xaml"
                    this.btnPlayerFullScreen.Click += new System.Windows.RoutedEventHandler(this.btnPlayerFullScreen_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button btnPutDown;
        internal System.Windows.Controls.WrapPanel wpPlayer;
    }
}

