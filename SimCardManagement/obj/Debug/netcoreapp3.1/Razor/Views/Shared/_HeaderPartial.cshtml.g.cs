#pragma checksum "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\Shared\_HeaderPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4529f214f096e2aee303bc283c5c6ccdc0a233e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HeaderPartial), @"mvc.1.0.view", @"/Views/Shared/_HeaderPartial.cshtml")]
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
#line 1 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\_ViewImports.cshtml"
using SimCardManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\_ViewImports.cshtml"
using SimCardManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\_ViewImports.cshtml"
using SimCardManagement.ModelView;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4529f214f096e2aee303bc283c5c6ccdc0a233e6", @"/Views/Shared/_HeaderPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86bb0d4618c73bde4e8ead260e7e29f2dfab267c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HeaderPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HeaderModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Header -->
<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class=""col-lg-6 col-7"">
                    <span style=""color:white""><a href=""#""><i class=""fas fa-home"" style=""color:white""></i></a> - </span>
                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">

                            <li class=""breadcrumb-item""><a href=""#"">");
#nullable restore
#line 13 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\Shared\_HeaderPartial.cshtml"
                                                               Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 14 "I:\Visual Studio 2019 Projects\SimCardManagement\SimCardManagement\Views\Shared\_HeaderPartial.cshtml"
                                                                              Write(Model.subTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ol>
                    </nav>
                </div>
                <div class=""col-lg-6 col-5 text-left"">
                    <a href=""#"" class=""btn btn-sm btn-neutral"">New</a>
                    <a href=""#"" class=""btn btn-sm btn-neutral"">Filters</a>
                </div>
            </div>

        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HeaderModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591