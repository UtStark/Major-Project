#pragma checksum "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e05830aca41e982a22a5ba99874c185a2047538"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
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
#line 1 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\_ViewImports.cshtml"
using CollegeWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\_ViewImports.cshtml"
using CollegeWebsite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e05830aca41e982a22a5ba99874c185a2047538", @"/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26dd838858fd374967c35e19a4cf6dcfc501116a", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CollegeWebsite.Models.ViewModel.RegistrationVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
  
    ViewData["Title"] = "Issued Books";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-bordered table-striped table-dark\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th scope=\"col\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e05830aca41e982a22a5ba99874c185a20475383798", async() => {
                WriteLiteral("Book Name");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortOrder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                                               WriteLiteral(ViewData["NameSortParm"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortOrder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                                                                                                   WriteLiteral(ViewData["CurrentFilter"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentFilter", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n            </th>\r\n            <th scope=\"col\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e05830aca41e982a22a5ba99874c185a20475386890", async() => {
                WriteLiteral("Aurthor Name");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortOrder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                                               WriteLiteral(ViewData["AuthSortParm"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortOrder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                                                                                                   WriteLiteral(ViewData["CurrentFilter"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentFilter", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            </th>


            <th scope=""col"">
                Issued Date
            </th>

            <th scope=""col"">
                Due Date
            </th>

           

            <th scope=""col""></th>

        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 37 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
         foreach (var obj in Model.IssuedBooks)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td width=\"50%\">");
#nullable restore
#line 40 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                           Write(obj.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td width=\"30%\">");
#nullable restore
#line 41 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                           Write(obj.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            \r\n                <td width=\"30%\">");
#nullable restore
#line 43 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                           Write(obj.IssueDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td width=\"30%\">");
#nullable restore
#line 44 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
                           Write(obj.DueDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 50 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        \r\n\r\n    </tbody>\r\n</table>\r\n\r\n<h1>Pending Fine : ");
#nullable restore
#line 57 "D:\Applications\CollegeWebsite - Copy\CollegeWebsite\Views\Student\Index.cshtml"
              Write(Model.Form.Fine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CollegeWebsite.Models.ViewModel.RegistrationVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
