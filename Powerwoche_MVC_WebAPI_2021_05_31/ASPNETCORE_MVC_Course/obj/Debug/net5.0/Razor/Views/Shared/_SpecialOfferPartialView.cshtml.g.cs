#pragma checksum "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c83ac8c4a8314f8e9701d4b2a7c5a20cca0dcb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ASPNETCORE_MVC_Course.ViewComponents.Shared.Views_Shared__SpecialOfferPartialView), @"mvc.1.0.view", @"/Views/Shared/_SpecialOfferPartialView.cshtml")]
namespace ASPNETCORE_MVC_Course.ViewComponents.Shared
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
#line 1 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\_ViewImports.cshtml"
using ASPNETCORE_MVC_Course;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\_ViewImports.cshtml"
using ASPNETCORE_MVC_Course.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\_ViewImports.cshtml"
using ASPNETCORE_MVC_Course.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c83ac8c4a8314f8e9701d4b2a7c5a20cca0dcb5", @"/Views/Shared/_SpecialOfferPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89153c4df508c94861ee096c325759f09a9488b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SpecialOfferPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASPNETCORE_MVC_Course.Models.Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml"
  
    Movie movieWithLowestPrice = null;

    if (Model.Any())
    {
        movieWithLowestPrice = Model.OrderBy(n => n.Price).First();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml"
 if (movieWithLowestPrice != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Sonderangebot</p>\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <p>");
#nullable restore
#line 22 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml"
          Write(movieWithLowestPrice.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>");
#nullable restore
#line 23 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml"
          Write(movieWithLowestPrice.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 26 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Shared\_SpecialOfferPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASPNETCORE_MVC_Course.Models.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
