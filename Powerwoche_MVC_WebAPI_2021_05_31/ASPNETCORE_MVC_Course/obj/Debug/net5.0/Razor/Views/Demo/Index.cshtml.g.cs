#pragma checksum "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Demo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22efd33b848fde97fe2b8f4d658b03612218b786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ASPNETCORE_MVC_Course.ViewComponents.Demo.Views_Demo_Index), @"mvc.1.0.view", @"/Views/Demo/Index.cshtml")]
namespace ASPNETCORE_MVC_Course.ViewComponents.Demo
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22efd33b848fde97fe2b8f4d658b03612218b786", @"/Views/Demo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89153c4df508c94861ee096c325759f09a9488b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Demo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_2021_05_31\Powerwoche_MVC_WebAPI_2021_05_31\ASPNETCORE_MVC_Course\Views\Demo\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Index</h1>

<fieldset>
    <legend>Demo 1</legend>
    <input type=""button"" value=""Demo 1"" id=""buttonDemo1"" />
    <br />
    <span id=""result1""></span>
</fieldset>

<fieldset>
    <legend>Demo 2</legend>
    Full Name <input type=""text"" id=""fullName"" />
    <input type=""button"" value=""Demo 2"" id=""buttonDemo2"" />
    <br />
    <span id=""result2""></span>
</fieldset>

<fieldset>
    <legend>Demo 3</legend>
    <input type=""button"" value=""Demo 3"" id=""buttonDemo3"" />
    <br />
    <span id=""result3""></span>
</fieldset>

<fieldset>
    <legend>Demo 4</legend>
    <input type=""button"" value=""Demo 4"" id=""buttonDemo4"" />
    <br />
    <span id=""result4""></span>
</fieldset>



<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script type=""text/javascript"">
    $(document).ready(function () {

        $('#buttonDemo1').click(function () {
            $.ajax({
                type: 'GET',
                url: '/demo/demo1',
       ");
            WriteLiteral(@"         success: function (result) {
                    $('#result1').html(result);
                }
            });
        });

        $('#buttonDemo2').click(function () {
            var fullName = $('#fullName').val();
            $.ajax({
                type: 'GET',
                url: '/demo/demo2/' + fullName,
                success: function (result) {
                    $('#result2').html(result);
                }
            });
        });

        $('#buttonDemo3').click(function () {
            $.ajax({
                type: 'GET',
                url: '/demo/demo3',
                success: function (result) {
                    var s = 'Id: ' + result.id;
                    s += '<br>Name: ' + result.name;
                    s += '<br>Price: ' + result.price;
                    $('#result3').html(s);
                },
                fail: function (result) {
                    var msg = result.error;
                    $('#result3').html(msg);
  ");
            WriteLiteral(@"              },
                error: function (result) {
                    var msg = result.error;
                    $('#result3').html(msg);
                }
            });
        });

        $('#buttonDemo4').click(function () {
            $.ajax({
                type: 'GET',
                url: '/demo/demo4',
                success: function (result) {
                    var s = '';
                    for (var i = 0; i < result.length; i++) {
                        s += '<br>Id: ' + result[i].id;
                        s += '<br>Name: ' + result[i].name;
                        s += '<br>Price: ' + result[i].price;
                        s += '<br>------------------';
                    }
                    $('#result4').html(s);
                }
            });
        });

    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
