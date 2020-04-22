﻿#pragma checksum "..\..\TaskControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2B137309C384D0ED50341AA887E08B85FB24342F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Playground;
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


namespace Playground {
    
    
    /// <summary>
    /// TaskControl
    /// </summary>
    public partial class TaskControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\TaskControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Title;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\TaskControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Description;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\TaskControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Assignee;
        
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
            System.Uri resourceLocater = new System.Uri("/Playground;component/taskcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TaskControl.xaml"
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
            
            #line 9 "..\..\TaskControl.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TaskPreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 9 "..\..\TaskControl.xaml"
            ((System.Windows.Controls.Border)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.TaskMouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Title = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 11 "..\..\TaskControl.xaml"
            this.Title.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OnTaskControlClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Description = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 12 "..\..\TaskControl.xaml"
            this.Description.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OnTaskControlClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Assignee = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 13 "..\..\TaskControl.xaml"
            this.Assignee.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OnTaskControlClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

