﻿#pragma checksum "..\..\MapUserContol.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C7A064F97EABAECDD505F7B7C8D7857"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace MapApplication {
    
    
    /// <summary>
    /// MapUserControl
    /// </summary>
    public partial class MapUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map MyMap;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.MapLayer DataLayer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Infobox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InfoboxTitle;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InfoboxDescription;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\MapUserContol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider ZoomBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MapApplication;component/mapusercontol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MapUserContol.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MyMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            case 2:
            this.DataLayer = ((Microsoft.Maps.MapControl.WPF.MapLayer)(target));
            return;
            case 3:
            this.Infobox = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 20 "..\..\MapUserContol.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseInfobox_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.InfoboxTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.InfoboxDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 44 "..\..\MapUserContol.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PanMap_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 45 "..\..\MapUserContol.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PanMap_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 46 "..\..\MapUserContol.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PanMap_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 47 "..\..\MapUserContol.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PanMap_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ZoomBar = ((System.Windows.Controls.Slider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

