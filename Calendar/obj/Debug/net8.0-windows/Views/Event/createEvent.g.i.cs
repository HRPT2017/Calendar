﻿#pragma checksum "..\..\..\..\..\Views\Event\createEvent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB4AA698496EAE630EF427C32269913D5E528CF6"
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
    /// CreateEvent
    /// </summary>
    public partial class CreateEvent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 235 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_modality;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_modality;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_event_name;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_event_name;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_start_date;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_start_date;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_end_date;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_end_date;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_event;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_return;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l_competicoes;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\..\..\..\Views\Event\createEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lb_competitions;
        
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/views/event/createevent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Event\createEvent.xaml"
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
            this.l_modality = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cb_modality = ((System.Windows.Controls.ComboBox)(target));
            
            #line 236 "..\..\..\..\..\Views\Event\createEvent.xaml"
            this.cb_modality.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_modality_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l_event_name = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tb_event_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.l_start_date = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.dp_start_date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.l_end_date = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.dp_end_date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.bt_event = ((System.Windows.Controls.Button)(target));
            
            #line 243 "..\..\..\..\..\Views\Event\createEvent.xaml"
            this.bt_event.Click += new System.Windows.RoutedEventHandler(this.bt_event_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.bt_return = ((System.Windows.Controls.Button)(target));
            
            #line 244 "..\..\..\..\..\Views\Event\createEvent.xaml"
            this.bt_return.Click += new System.Windows.RoutedEventHandler(this.bt_return_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.l_competicoes = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lb_competitions = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

