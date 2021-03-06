#pragma checksum "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d41649e0b6f57d22ae5a846d393bc3d160328b65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_NavPartial), @"mvc.1.0.view", @"/Views/Shared/NavPartial.cshtml")]
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
#line 2 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using Application.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using Application.Domain.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using Application.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\univer\Диплом\Application\Application\Application\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d41649e0b6f57d22ae5a846d393bc3d160328b65", @"/Views/Shared/NavPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb288e282e79b32309cb5f25a14c81a715241a4", @"/_ViewImports.cshtml")]
    public class Views_Shared_NavPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Nav -->\r\n<nav id=\"nav\">\r\n    <ul>\r\n        <li><a href=\"/news\">Новини</a></li>\r\n        <li><a href=\"/schedule\">Розклад</a></li>\r\n        <li><a href=\"/studyingGraph\">Графік навчання</a></li>\r\n        <li><a href=\"/\">Головна</a></li>\r\n");
#nullable restore
#line 8 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
         if (User.IsInRole(AllRoles.StudentRole))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a href=\"/student/Statement/Statement\">Відомість</a></li>\r\n");
#nullable restore
#line 11 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
        }
        else if (User.IsInRole(AllRoles.TeacherRole))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a href=\"/teacher/Statement/Statement\">Відомість</a></li>\r\n");
#nullable restore
#line 15 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a href=\"/\">Відомість</a></li>\r\n");
#nullable restore
#line 19 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li><a href=\"/Chat/Index\">Пошта</a></li>\r\n");
#nullable restore
#line 21 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
         if (!User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a href=\"/account/login\" class=\"Button\">Войти</a></li>\r\n");
#nullable restore
#line 24 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a href=\"/account/logout\" class=\"Button\">Вийти</a></li>\r\n");
#nullable restore
#line 28 "D:\univer\Диплом\Application\Application\Application\Views\Shared\NavPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</nav>\r\n");
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
