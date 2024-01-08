﻿#pragma checksum "..\..\MemberManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49ECF82073B4F93929D99B98C7C6D16C47E5426B374416A5DA185E3D2B4DEF32"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace Library {
    
    
    /// <summary>
    /// MemberManagement
    /// </summary>
    public partial class MemberManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\MemberManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFirstName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MemberManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLastName;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MemberManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpRegistrationDate;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MemberManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMembers;
        
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
            System.Uri resourceLocater = new System.Uri("/Library;component/membermanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MemberManagement.xaml"
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
            this.txtFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpRegistrationDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            
            #line 49 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddMember_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 50 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateMember_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 51 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteMember_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 56 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HomeMember_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 57 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearMember_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 61 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExportMembers_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 62 "..\..\MemberManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportMembers_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dgMembers = ((System.Windows.Controls.DataGrid)(target));
            
            #line 69 "..\..\MemberManagement.xaml"
            this.dgMembers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgMembers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
