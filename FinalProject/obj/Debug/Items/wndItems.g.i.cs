﻿#pragma checksum "..\..\..\Items\wndItems.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB2329E4F82E7DEA044EB1A32EFB96F349E25DF5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinalProject.Items;
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


namespace FinalProject.Items {
    
    
    /// <summary>
    /// wndItems
    /// </summary>
    public partial class wndItems : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewItem;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUpdateItem;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCode;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCost;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblError;
        
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
            System.Uri resourceLocater = new System.Uri("/FinalProject;component/items/wnditems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Items\wndItems.xaml"
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
            
            #line 9 "..\..\..\Items\wndItems.xaml"
            ((FinalProject.Items.wndItems)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ListBox1 = ((System.Windows.Controls.ListBox)(target));
            
            #line 12 "..\..\..\Items\wndItems.xaml"
            this.ListBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Items\wndItems.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNewItem = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Items\wndItems.xaml"
            this.btnNewItem.Click += new System.Windows.RoutedEventHandler(this.btnNewItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnUpdateItem = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Items\wndItems.xaml"
            this.BtnUpdateItem.Click += new System.Windows.RoutedEventHandler(this.BtnUpdateItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtCost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.lblError = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

