﻿#pragma checksum "..\..\Menu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E12A12B863892044547A949837D78E1A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FyndDyne;
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


namespace FyndDyne {
    
    
    /// <summary>
    /// Menuxaml
    /// </summary>
    public partial class Menuxaml : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Logout;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Main;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Breads;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Desserts;
        
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
            System.Uri resourceLocater = new System.Uri("/FyndDyne;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
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
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Menu.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Logout = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Menu.xaml"
            this.Logout.Click += new System.Windows.RoutedEventHandler(this.LogoutButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Main = ((System.Windows.Controls.ListView)(target));
            
            #line 32 "..\..\Menu.xaml"
            this.Main.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemSelected);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Breads = ((System.Windows.Controls.ListView)(target));
            
            #line 56 "..\..\Menu.xaml"
            this.Breads.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemSelected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Desserts = ((System.Windows.Controls.ListView)(target));
            
            #line 78 "..\..\Menu.xaml"
            this.Desserts.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemSelected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

