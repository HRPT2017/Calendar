﻿#pragma checksum "..\..\..\Edit_Competicao.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F35548EC5F1A4C1F7E548553991ABE05A95A7669"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

using Calendar;
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


namespace Calendar {
    
    
    /// <summary>
    /// Edit_Competicao
    /// </summary>
    public partial class Edit_Competicao : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 234 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modalidade;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modalidade;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_edit_competicao;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_edit_competicao;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_edit_competicao;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_edit_competicao;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_eventos_edit;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_eventos_edit;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_evento_edit;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\Edit_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_evento_edit;
        
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/edit_competicao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Edit_Competicao.xaml"
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
            
            #line 9 "..\..\..\Edit_Competicao.xaml"
            ((Calendar.Edit_Competicao)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.l_modalidade = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cb_modalidade = ((System.Windows.Controls.ComboBox)(target));
            
            #line 235 "..\..\..\Edit_Competicao.xaml"
            this.cb_modalidade.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modalidade_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.l_edit_competicao = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\..\Edit_Competicao.xaml"
            this.bt_return.Click += new System.Windows.RoutedEventHandler(this.bt_return_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cb_edit_competicao = ((System.Windows.Controls.ComboBox)(target));
            
            #line 238 "..\..\..\Edit_Competicao.xaml"
            this.cb_edit_competicao.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_edit_competicao_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_edit_competicao = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.bt_edit_competicao = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\Edit_Competicao.xaml"
            this.bt_edit_competicao.Click += new System.Windows.RoutedEventHandler(this.bt_edit_competicao_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.l_eventos_edit = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lb_eventos_edit = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.l_evento_edit = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lb_evento_edit = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

