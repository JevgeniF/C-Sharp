#pragma checksum "/Users/jevgeni/RiderProjects/icd0008-2020f/CarExpencesMonitor/WebApp/Views/Shared/DisplayTemplates/DateTime.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35ddc85683f64a8638c894b47a6c2d63159c602c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_DisplayTemplates_DateTime), @"mvc.1.0.view", @"/Views/Shared/DisplayTemplates/DateTime.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35ddc85683f64a8638c894b47a6c2d63159c602c", @"/Views/Shared/DisplayTemplates/DateTime.cshtml")]
    public class Views_Shared_DisplayTemplates_DateTime : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/jevgeni/RiderProjects/icd0008-2020f/CarExpencesMonitor/WebApp/Views/Shared/DisplayTemplates/DateTime.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/jevgeni/RiderProjects/icd0008-2020f/CarExpencesMonitor/WebApp/Views/Shared/DisplayTemplates/DateTime.cshtml"
Write(Model.Value.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/jevgeni/RiderProjects/icd0008-2020f/CarExpencesMonitor/WebApp/Views/Shared/DisplayTemplates/DateTime.cshtml"
                                             
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime?> Html { get; private set; }
    }
}
#pragma warning restore 1591
