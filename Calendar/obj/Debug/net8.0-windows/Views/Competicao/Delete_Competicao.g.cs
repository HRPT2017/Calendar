﻿#pragma checksum "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D9EAE6321B5255C0440C0DB48A9475826B474735"
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
    /// Delete_Competicao
    /// </summary>
    public partial class Delete_Competicao : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 235 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modalidade;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modalidade;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_competicao;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_competicao;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_delete;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_eventos;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/views/competicao/delete_competicao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
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
            
            #line 236 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
            this.cb_modalidade.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modalidade_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l_competicao = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cb_competicao = ((System.Windows.Controls.ComboBox)(target));
            
            #line 238 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
            this.cb_competicao.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_evento_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bt_delete = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
            this.bt_delete.Click += new System.Windows.RoutedEventHandler(this.bt_delete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\..\..\Views\Competicao\Delete_Competicao.xaml"
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

