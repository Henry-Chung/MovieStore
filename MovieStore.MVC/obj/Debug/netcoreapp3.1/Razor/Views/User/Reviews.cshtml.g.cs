#pragma checksum "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ac6d76af39475dc3705c706980fc8c4b9640a6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Reviews), @"mvc.1.0.view", @"/Views/User/Reviews.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ac6d76af39475dc3705c706980fc8c4b9640a6e", @"/Views/User/Reviews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09aa387f5e615eecbf69936df9de009cac81cba1", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Reviews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieStore.Core.Entities.Review>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
  
    ViewData["Title"] = "Reviews";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
    <div>
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-6 cl-lg-3 col-sm-4 col-xl-2"">
                    <h5>Movie</h5>
                </div>
                <div class=""col"">
                    <h5>Rating</h5>
                </div>
                <div class=""col"">
                    <h5>Comment</h5>
                </div>
            </div>

");
#nullable restore
#line 22 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
             foreach (var review in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-6 cl-lg-3 col-sm-4 col-xl-2\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 710, "\"", 739, 1);
#nullable restore
#line 26 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
WriteAttributeValue("", 716, review.Movie.PosterUrl, 716, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 758, "\"", 783, 1);
#nullable restore
#line 26 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
WriteAttributeValue("", 764, review.Movie.Title, 764, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <text>");
#nullable restore
#line 27 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
                         Write(review.Movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</text>\r\n                    </div>\r\n                    <div class=\"col\">\r\n                        <text>");
#nullable restore
#line 30 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
                         Write(review.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</text>\r\n                    </div>\r\n                    <div class=\"col\">\r\n                        <text>");
#nullable restore
#line 33 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
                         Write(review.ReviewText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</text>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 36 "C:\code\Antra\Project\MovieStore\MovieStore.MVC\Views\User\Reviews.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieStore.Core.Entities.Review>> Html { get; private set; }
    }
}
#pragma warning restore 1591
