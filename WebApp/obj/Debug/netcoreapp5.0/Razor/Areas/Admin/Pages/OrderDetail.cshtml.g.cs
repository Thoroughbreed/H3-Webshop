#pragma checksum "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "084a4549ef487d966fd0987c596bfdd7f45e6864"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Areas_Admin_Pages_OrderDetail), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/OrderDetail.cshtml")]
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
#line 1 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a4549ef487d966fd0987c596bfdd7f45e6864", @"/Areas/Admin/Pages/OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56255396305d1d1888ad93afc9c47568e44a4220", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_OrderDetail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\n    <div class=\"col-4\">\n        <br /><br /><br />\n        Navn: ");
#nullable restore
#line 7 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
         Write(Model.Order.Customer.FName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                                     Write(Model.Order.Customer.LName);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        Adresse: ");
#nullable restore
#line 8 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
            Write(Model.Order.Customer.RoadName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                                           Write(Model.Order.Customer.RoadNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 8 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                                                                             Write(Model.Order.Customer.PostNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                                                                                                              Write(Model.Order.Customer.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        Email: ");
#nullable restore
#line 9 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
          Write(Model.Order.Customer.EMail);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        Tel: ");
#nullable restore
#line 10 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
        Write(Model.Order.Customer.PhoneMain);

#line default
#line hidden
#nullable disable
            WriteLiteral(", Mobil: ");
#nullable restore
#line 10 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                                                Write(Model.Order.Customer.PhoneMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n        Oprettet: ");
#nullable restore
#line 11 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
             Write(Model.Order.PurchaseDate.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <div class=""col-8"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th scope=""col"">Produkt</th>
                    <th scope=""col"">Pris</th>
                    <th scope=""col"">Antal</th>
                    <th scope=""col"">Total</th>
                </tr>
            </thead>
");
#nullable restore
#line 23 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
             foreach (var item in Model.Order.OrderItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 26 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                   Write(item.Products.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 27 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                   Write(item.Products.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 28 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                   Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 29 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                   Write(item.LinePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 31 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tfoot>\n                <tr>\n                    <th scope=\"col\"></th>\n                    <th scope=\"col\"></th>\n                    <th scope=\"col\">I alt: </th>\n                    <th scope=\"col\">");
#nullable restore
#line 37 "/Users/janandreasen/RiderProjects/Webshop/H3-Webshop/WebApp/Areas/Admin/Pages/OrderDetail.cshtml"
                               Write(Model.Order.OrderItems.Sum(o => o.LinePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                </tr>\n            </tfoot>\n        </table>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Areas.Admin.Pages.OrderDetailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Areas.Admin.Pages.OrderDetailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Areas.Admin.Pages.OrderDetailModel>)PageContext?.ViewData;
        public WebApp.Areas.Admin.Pages.OrderDetailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
