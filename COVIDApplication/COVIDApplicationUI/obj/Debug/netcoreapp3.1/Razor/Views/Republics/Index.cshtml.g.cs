#pragma checksum "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2911b6ddb0331c999b8a8cf7f092db41b1186236"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Republics_Index), @"mvc.1.0.view", @"/Views/Republics/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\_ViewImports.cshtml"
using COVIDApplicationUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\_ViewImports.cshtml"
using Domain.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\_ViewImports.cshtml"
using COVIDApplicationUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2911b6ddb0331c999b8a8cf7f092db41b1186236", @"/Views/Republics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cad6dba9bacc0fa84698c14b672e20f15f41b735", @"/Views/_ViewImports.cshtml")]
    public class Views_Republics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Commands.Republics.Queries.GetAllRepublics.RepublicsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Index</h1>
<table class=""table"">
    <thead>
        <tr>
            <th>
              Population
            </th>
            <th>
                Square
            </th>
            <th>
                Title
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 23 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
 foreach (var item in Model.Republics) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Population));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Square));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n            ");
#nullable restore
#line 32 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\User\Desktop\COVIDApplication\COVIDApplicationUI\Views\Republics\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Commands.Republics.Queries.GetAllRepublics.RepublicsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591