﻿#pragma checksum "..\..\CreationRecette.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A8EED3E25432755C23247BF4EE467A19A85BA7336067E3923AD73D02977E721B"
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
    /// CreationRecette
    /// </summary>
    public partial class CreationRecette : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Retour;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nomrecette;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoixCategorie;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Prix;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Informations1;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Informations2;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\CreationRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreerRecette;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjetBDD-WPF;component/creationrecette.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreationRecette.xaml"
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
            
            #line 56 "..\..\CreationRecette.xaml"
            this.Retour.Click += new System.Windows.RoutedEventHandler(this.Retour_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Nomrecette = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ChoixCategorie = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Prix = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Informations1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Informations2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CreerRecette = ((System.Windows.Controls.Button)(target));
            
            #line 167 "..\..\CreationRecette.xaml"
            this.CreerRecette.Click += new System.Windows.RoutedEventHandler(this.Creation_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

