﻿#pragma checksum "..\..\..\..\Views\Delete_Event.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "878E766BA49BE156435566554E97135572406705"
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
    /// Delete_Evento
    /// </summary>
    public partial class Delete_Evento : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 249 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modalidade;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modalidade;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_evento;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_evento;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_data;
        
        #line default
        #line hidden
        
        
        #line 255 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_data;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_delete;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_competicoes;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\..\Views\Delete_Event.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_competicoes;
        
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/views/delete_event.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Delete_Event.xaml"
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
            
            #line 250 "..\..\..\..\Views\Delete_Event.xaml"
            this.cb_modalidade.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modalidade_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l_evento = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cb_evento = ((System.Windows.Controls.ComboBox)(target));
            
            #line 252 "..\..\..\..\Views\Delete_Event.xaml"
            this.cb_evento.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_evento_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.l_data = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tb_data = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.bt_delete = ((System.Windows.Controls.Button)(target));
            
            #line 256 "..\..\..\..\Views\Delete_Event.xaml"
            this.bt_delete.Click += new System.Windows.RoutedEventHandler(this.bt_delete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 257 "..\..\..\..\Views\Delete_Event.xaml"
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

