﻿#pragma checksum "..\..\..\WindowDB.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2FCF03CDB1FCAD88B8B5184A214BF2ED4A9BA323"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GB_Final_test;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace GB_Final_test {
    
    
    /// <summary>
    /// WindowDB
    /// </summary>
    public partial class WindowDB : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMaximize;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView DataList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateAnimal;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\WindowDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveAnimal;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GB_Final_test;V1.0.0.0;component/windowdb.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowDB.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\WindowDB.xaml"
            ((GB_Final_test.WindowDB)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftBUttonDown);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\WindowDB.xaml"
            ((GB_Final_test.WindowDB)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\WindowDB.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btn_Minimize);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\WindowDB.xaml"
            this.btnMaximize.Click += new System.Windows.RoutedEventHandler(this.btn_Maximize);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\WindowDB.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btn_Close);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataList = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.UpdateAnimal = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\WindowDB.xaml"
            this.UpdateAnimal.Click += new System.Windows.RoutedEventHandler(this.UpdateAnimal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RemoveAnimal = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\WindowDB.xaml"
            this.RemoveAnimal.Click += new System.Windows.RoutedEventHandler(this.RemoveAnimal_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

