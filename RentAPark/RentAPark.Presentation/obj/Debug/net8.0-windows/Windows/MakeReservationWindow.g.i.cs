﻿#pragma checksum "..\..\..\..\Windows\MakeReservationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "609593015CD91F111093EB599E0D51FBF72992C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RentAPark.Presentation.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace RentAPark.Presentation.Windows {
    
    
    /// <summary>
    /// MakeReservationWindow
    /// </summary>
    public partial class MakeReservationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CustomerButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CustomerLabel;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ParkByLocationButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ParkByFacilityButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ParkLabel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDatePicker;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDatePicker;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumberOfPersons;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewHousesButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Windows\MakeReservationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RentAPark.Presentation;V1.0.0.0;component/windows/makereservationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomerButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.CustomerButton.Click += new System.Windows.RoutedEventHandler(this.CustomerButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CustomerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ParkByLocationButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.ParkByLocationButton.Click += new System.Windows.RoutedEventHandler(this.ParkByLocationButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ParkByFacilityButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.ParkByFacilityButton.Click += new System.Windows.RoutedEventHandler(this.ParksByFaciliesButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ParkLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.StartDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 54 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.StartDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.StartDatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EndDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 57 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.EndDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.EndDatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NumberOfPersons = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.NumberOfPersons.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NumberOfPersons_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ViewHousesButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.ViewHousesButton.Click += new System.Windows.RoutedEventHandler(this.ViewHousesButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Windows\MakeReservationWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

