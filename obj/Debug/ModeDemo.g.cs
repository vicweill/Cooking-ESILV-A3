﻿#pragma checksum "..\..\ModeDemo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "89D0179F35D415636AA6A67ADF054FD23171F6E430B88D06CF42FEA668821E91"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjetBDD_WPF;
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


namespace ProjetBDD_WPF {
    
    
    /// <summary>
    /// ModeDemo
    /// </summary>
    public partial class ModeDemo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Retour;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Avancer;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nbclient;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nbcrea;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListeCrea;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nbrecettes;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListeProd;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nomProd;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PhotoRecette;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button validerNom;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProdText;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\ModeDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ProduitsRecette;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjetBDD-WPF;component/modedemo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModeDemo.xaml"
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
            this.Retour = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\ModeDemo.xaml"
            this.Retour.Click += new System.Windows.RoutedEventHandler(this.Retour_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Avancer = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\ModeDemo.xaml"
            this.Avancer.Click += new System.Windows.RoutedEventHandler(this.Avancer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nbclient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.nbcrea = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ListeCrea = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.nbrecettes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ListeProd = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.nomProd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.PhotoRecette = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.validerNom = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\ModeDemo.xaml"
            this.validerNom.Click += new System.Windows.RoutedEventHandler(this.validerNom_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ProdText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.ProduitsRecette = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

