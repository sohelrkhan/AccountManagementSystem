#pragma checksum "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c433c4c9f7876918a825e0c1e8d7f58d68c7efe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Salary_PrintById), @"mvc.1.0.view", @"/Views/Salary/PrintById.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Salary/PrintById.cshtml", typeof(AspNetCore.Views_Salary_PrintById))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c433c4c9f7876918a825e0c1e8d7f58d68c7efe3", @"/Views/Salary/PrintById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cea8c9a7a39c059a3c8516ab26e1dbc95d2b05e", @"/Views/_ViewImports.cshtml")]
    public class Views_Salary_PrintById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMS.Models.Salary>
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
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
  
    ViewData["Title"] = "Index";
    //Layout = "~/Views/Shared/_LayoutAccountant.cshtml";

#line default
#line hidden
            BeginContext(128, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(130, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c433c4c9f7876918a825e0c1e8d7f58d68c7efe34411", async() => {
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
            BeginContext(178, 387, true);
            WriteLiteral(@"

<div class=""app-content"">
    <br/>
    <br/>
    <br/>
    <h1 class=""text-center"">New Prattasha High School</h1>
    
    <br/>
    <h1 class=""text-center"">Salary Information</h1>
    <br/>
    <table class=""table table-bordered table-hover"">
        <thead>
        <tr>
            <th>
                Staff Id
            </th>
            <th>
                ");
            EndContext();
            BeginContext(566, 40, false);
#line 26 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(606, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(662, 42, false);
#line 29 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(704, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(760, 43, false);
#line 32 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayNameFor(model => model.Remarks));

#line default
#line hidden
            EndContext();
            BeginContext(803, 123, true);
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n        </thead>\r\n        <tbody>\r\n\r\n        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(927, 43, false);
#line 41 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayFor(modelItem => Model.StaffId));

#line default
#line hidden
            EndContext();
            BeginContext(970, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1026, 40, false);
#line 44 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1066, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1122, 42, false);
#line 47 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1164, 58, true);
            WriteLiteral(" Tk\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1223, 43, false);
#line 50 "E:\01. Web Development 2019\02. Accounts Management System OurEdu\AMS_OurEdu\AMS WebApp\AMS\Views\Salary\PrintById.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Remarks));

#line default
#line hidden
            EndContext();
            BeginContext(1266, 153, true);
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n\r\n        </tbody>\r\n    </table>\r\n    <br/>\r\n    <br/>\r\n    <br/>\r\n    <br/>\r\n    <h4>Signature & Date</h4>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMS.Models.Salary> Html { get; private set; }
    }
}
#pragma warning restore 1591