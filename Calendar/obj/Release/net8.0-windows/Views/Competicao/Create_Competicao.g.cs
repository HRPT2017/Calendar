﻿#pragma checksum "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10596054A7E4244454A3346F3A78932D7C7911A0"
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
    /// Create_Competicao
    /// </summary>
    public partial class Create_Competicao : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 232 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modalidade;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modalidade;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_nome_competicao;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_competicao;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_competicao_create;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_eventos;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_eventos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Calendar;component/views/competicao/create_competicao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.l_modalidade = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cb_modalidade = ((System.Windows.Controls.ComboBox)(target));
            
            #line 233 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
            this.cb_modalidade.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modalidade_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l_nome_competicao = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tb_competicao = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.bt_competicao_create = ((System.Windows.Controls.Button)(target));
            
            #line 236 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
            this.bt_competicao_create.Click += new System.Windows.RoutedEventHandler(this.bt_competicao_create_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\..\..\..\Views\Competicao\Create_Competicao.xaml"
            this.bt_return.Click += new System.Windows.RoutedEventHandler(this.bt_return_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.l_eventos = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lb_eventos = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

