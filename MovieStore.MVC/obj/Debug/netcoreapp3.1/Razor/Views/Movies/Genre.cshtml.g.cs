#pragma checksum "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\Movies\Genre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f403a5374a717d477628ac7f65ab1d1cb5859764"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Genre), @"mvc.1.0.view", @"/Views/Movies/Genre.cshtml")]
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
#line 1 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\_ViewImports.cshtml"
using MovieStore.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\_ViewImports.cshtml"
using MovieStore.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f403a5374a717d477628ac7f65ab1d1cb5859764", @"/Views/Movies/Genre.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09aa387f5e615eecbf69936df9de009cac81cba1", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Genre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieStore.Core.Entities.Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\Movies\Genre.cshtml"
  
    ViewData["Title"] = "Genre";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div>\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\Movies\Genre.cshtml"
             foreach (var movie in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\Movies\Genre.cshtml"
           Write(await Html.PartialAsync("_MovieCard", movie));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\Movies\Genre.cshtml"
                                                             
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieStore.Core.Entities.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
