#pragma checksum "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1a19c4054c0446888407d0a2ccce251fbcccdc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Areas_Admin_Pages__ProductListing), @"mvc.1.0.view", @"/Areas/Admin/Pages/_ProductListing.cshtml")]
namespace WebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1a19c4054c0446888407d0a2ccce251fbcccdc0", @"/Areas/Admin/Pages/_ProductListing.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54a580a236bf4511f2b8e02a6219a9844921dafb", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages__ProductListing : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataLayer.Models.Products>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h4>Model.Name</h4>\r\n<p>");
#nullable restore
#line 3 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml"
Write(Model.LName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 4 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml"
Write(Model.RoadName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 4 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml"
              Write(Model.RoadNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 5 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml"
Write(Model.PostNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 5 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\_ProductListing.cshtml"
                Write(Model.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<hr />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataLayer.Models.Products> Html { get; private set; }
    }
}
#pragma warning restore 1591
