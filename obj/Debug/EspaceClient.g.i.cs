﻿#pragma checksum "..\..\EspaceClient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17B8C5B8AD3B2AA064DAD7686B28E3474367028C3B554151BBC480FAD29D518D"
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
    /// EspaceClient
    /// </summary>
    public partial class EspaceClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Retour;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock IdCdR;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PrenomClient;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NomClient;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TelClient;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NbCommandesClient;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EspaceCrea;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\EspaceClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditInfos;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjetBDD-WPF;component/espaceclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EspaceClient.xaml"
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
            
            #line 57 "..\..\EspaceClient.xaml"
            this.Retour.Click += new System.Windows.RoutedEventHandler(this.Retour_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IdCdR = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.PrenomClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.NomClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TelClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.NbCommandesClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.EspaceCrea = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\EspaceClient.xaml"
            this.EspaceCrea.Click += new System.Windows.RoutedEventHandler(this.Createur_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditInfos = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\EspaceClient.xaml"
            this.EditInfos.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
