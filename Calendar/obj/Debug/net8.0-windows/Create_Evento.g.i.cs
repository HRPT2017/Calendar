﻿#pragma checksum "..\..\..\Create_Evento.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C849007EDD60857B68BF58F986CF19E588BEB670"
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
    /// Create_Evento
    /// </summary>
    public partial class Create_Evento : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 234 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modalidade;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modalidade;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_nome_evento;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_nome_evento;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_data;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_data;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_evento;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_competicoes;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\Create_Evento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_competicoes;
        
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/create_evento.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Create_Evento.xaml"
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
            this.l_modalidade = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cb_modalidade = ((System.Windows.Controls.ComboBox)(target));
            
            #line 235 "..\..\..\Create_Evento.xaml"
            this.cb_modalidade.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modalidade_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l_nome_evento = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tb_nome_evento = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.l_data = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.dp_data = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.bt_evento = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\Create_Evento.xaml"
            this.bt_evento.Click += new System.Windows.RoutedEventHandler(this.bt_evento_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 241 "..\..\..\Create_Evento.xaml"
            this.bt_return.Click += new System.Windows.RoutedEventHandler(this.bt_return_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.l_competicoes = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lb_competicoes = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

