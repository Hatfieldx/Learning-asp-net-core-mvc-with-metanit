#pragma checksum "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb8d6990e25fce97f06c98025a41ef757894b92e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\EDU_C#\asp core\metanit\Views\Views\Views\_ViewImports.cshtml"
using Views;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\_ViewImports.cshtml"
using Views.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb8d6990e25fce97f06c98025a41ef757894b92e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dbabd4896d882914fa112d117d38b482fd9750b", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17fdce776c1aab105b8b4a34467ef4894aae34a0", @"/Views/Home/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Person p = new Person();
    Person p1 = new Person();
    Layout = "~/Views/Shared/_Master.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n\r\n\r\n\r\n<div>\r\n\r\n    ");
#nullable restore
#line 27 "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("_GetMessage", new List<string> {DayOfWeek.Monday.ToString()
                                                                ,DayOfWeek.Tuesday.ToString()
                                                                ,DayOfWeek.Wednesday.ToString()
                                                                ,DayOfWeek.Thursday.ToString()
                                                                ,DayOfWeek.Friday.ToString()
                                                                ,DayOfWeek.Saturday.ToString()
                                                                ,DayOfWeek.Sunday.ToString()}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
            DefineSection("Footer", async() => {
                WriteLiteral("\r\n\r\n    <p>Все права защищены. Site Corp. 2016.</p>\r\n");
                WriteLiteral("\r\n    <p>Current time: ");
#nullable restore
#line 42 "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\Index.cshtml"
                Write(Timer.GetCurrentTime());

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "D:\EDU_C#\asp core\metanit\Views\Views\Views\Home\Index.cshtml"
 
    public string GetValue(string val)
    {

        return val;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Views.Services.ITimer Timer { get; private set; }
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
