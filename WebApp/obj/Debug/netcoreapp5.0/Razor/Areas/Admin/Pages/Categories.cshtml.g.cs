#pragma checksum "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f4987095075f9e1f15e95128a608b789653bf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Areas_Admin_Pages_Categories), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/Categories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f4987095075f9e1f15e95128a608b789653bf9", @"/Areas/Admin/Pages/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54a580a236bf4511f2b8e02a6219a9844921dafb", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Categories : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h4>Welcome to the admin area!</h4>\r\n<hr />\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"col\">ID#</th>\r\n            <th scope=\"col\">Kategori</th>\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 14 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\Categories.cshtml"
     foreach (var cat in Model.Cats)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 17 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\Categories.cshtml"
           Write(cat.CategoryID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\Categories.cshtml"
           Write(cat.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 20 "C:\Users\jan\source\repos\WebshopCLI\WebApp\Areas\Admin\Pages\Categories.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Areas.Admin.Pages.CategoriesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Areas.Admin.Pages.CategoriesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Areas.Admin.Pages.CategoriesModel>)PageContext?.ViewData;
        public WebApp.Areas.Admin.Pages.CategoriesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
