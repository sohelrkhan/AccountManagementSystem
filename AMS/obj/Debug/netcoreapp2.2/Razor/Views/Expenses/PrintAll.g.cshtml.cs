#pragma checksum "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "373b9b00382a902cee047434468878df6c5d92e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expenses_PrintAll), @"mvc.1.0.view", @"/Views/Expenses/PrintAll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Expenses/PrintAll.cshtml", typeof(AspNetCore.Views_Expenses_PrintAll))]
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
#line 1 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\_ViewImports.cshtml"
using AMS;

#line default
#line hidden
#line 2 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\_ViewImports.cshtml"
using AMS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"373b9b00382a902cee047434468878df6c5d92e4", @"/Views/Expenses/PrintAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cea8c9a7a39c059a3c8516ab26e1dbc95d2b05e", @"/Views/_ViewImports.cshtml")]
    public class Views_Expenses_PrintAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AMS.Models.Expenses>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/table.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAccountant.cshtml";

#line default
#line hidden
            BeginContext(141, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(147, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "373b9b00382a902cee047434468878df6c5d92e44440", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(195, 227, true);
            WriteLiteral("\r\n<div class=\"app-content\">\r\n    <h1 class=\"text-center\">Academic Expense Information</h1>\r\n    <br />\r\n\r\n\r\n    <table class=\"table table-bordered table-hover\">\r\n        <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(423, 40, false);
#line 20 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(463, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(519, 43, false);
#line 23 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Details));

#line default
#line hidden
            EndContext();
            BeginContext(562, 116, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Amount\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(679, 40, false);
#line 29 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(719, 73, true);
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 35 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(841, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(902, 39, false);
#line 39 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(941, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1009, 42, false);
#line 42 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Details));

#line default
#line hidden
            EndContext();
            BeginContext(1051, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1119, 41, false);
#line 45 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1160, 70, true);
            WriteLiteral(" Tk\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1231, 39, false);
#line 48 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1270, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 51 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Expenses\PrintAll.cshtml"
        }

#line default
#line hidden
            BeginContext(1325, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(1455, 34, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n");
            EndContext();
            BeginContext(1547, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AMS.Models.Expenses>> Html { get; private set; }
    }
}
#pragma warning restore 1591