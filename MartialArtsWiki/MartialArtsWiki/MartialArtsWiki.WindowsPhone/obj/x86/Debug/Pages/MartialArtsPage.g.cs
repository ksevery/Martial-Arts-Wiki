﻿

#pragma checksum "D:\My Stuff\12.Mobile Development\Windows Project\MartialArtsWiki\MartialArtsWiki\MartialArtsWiki.Shared\Pages\MartialArtsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D18EEC61E00CD637F7FC344166F28014"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MartialArtsWiki.Pages
{
    partial class MartialArtsPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 28 "..\..\..\Pages\MartialArtsPage.xaml"
                ((global::MartialArtsWiki.Views.BarPageTop)(target)).OnLogout += this.NavigateOnLogout;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 56 "..\..\..\Pages\MartialArtsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.NavigateOnAddEntry;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 39 "..\..\..\Pages\MartialArtsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.OnMartialArtSelect;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


