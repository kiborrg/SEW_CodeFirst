#pragma checksum "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e3bf0d6ba53ccaec940db22c04cc74eb7bb8270"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\_ViewImports.cshtml"
using SEW_CodeFirst;

#line default
#line hidden
#line 2 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\_ViewImports.cshtml"
using SEW_CodeFirst.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e3bf0d6ba53ccaec940db22c04cc74eb7bb8270", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22753d67dd1b53d484f6fe89fa168a4f99062308", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SEW_CodeFirst.Models.DTO.SearchResult>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 3 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Web search";

#line default
#line hidden
            BeginContext(106, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(108, 986, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7561c55dec314e5ca102f33dfd967e1b", async() => {
                BeginContext(178, 351, true);
                WriteLiteral(@"
    <input style=""width: 90%;margin-left:auto;margin-right:auto ;border: groove; height: 40px; "" class=""form-control"" id=""searchVal"" autofocus=""autofocus"" type=""text"" name=""searchVal"" placeholder=""Search in web"" required />
    <button type=""submit"" style=""height: 40px; margin-left:auto"" class=""btn btn-success"">Search it!</button>
    <br />

");
                EndContext();
#line 12 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
     if (Model != null)
    {
        var a = Model.FirstOrDefault(i => i.Query != null);

#line default
#line hidden
                BeginContext(622, 25, true);
                WriteLiteral("        <h2>Results for \"");
                EndContext();
                BeginContext(648, 7, false);
#line 15 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
                    Write(a.Query);

#line default
#line hidden
                EndContext();
                BeginContext(655, 22, true);
                WriteLiteral("\"</h2>\r\n        <ul>\r\n");
                EndContext();
#line 17 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(734, 64, true);
                WriteLiteral("                <li style=\"width:500px\">\r\n                    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 798, "\"", 815, 1);
#line 20 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
WriteAttributeValue("", 805, item.Link, 805, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(816, 20, true);
                WriteLiteral(" style=\"color:blue\">");
                EndContext();
                BeginContext(837, 10, false);
#line 20 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
                                                       Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(847, 73, true);
                WriteLiteral("</a><br />\r\n                    <span style=\"font-size:15px;color:green\">");
                EndContext();
                BeginContext(921, 9, false);
#line 21 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
                                                        Write(item.Link);

#line default
#line hidden
                EndContext();
                BeginContext(930, 61, true);
                WriteLiteral("</span><br />\r\n                    <span style=\"color:gray;\">");
                EndContext();
                BeginContext(992, 12, false);
#line 22 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
                                         Write(item.Snippet);

#line default
#line hidden
                EndContext();
                BeginContext(1004, 32, true);
                WriteLiteral("</span>\r\n                </li>\r\n");
                EndContext();
#line 24 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1051, 29, true);
                WriteLiteral("            \r\n        </ul>\r\n");
                EndContext();
#line 27 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 7 "D:\Github_Projects\SEW_CodeFirst\SEW_CodeFirst\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 142, Url.Action("Index"), 142, 20, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SEW_CodeFirst.Models.DTO.SearchResult>> Html { get; private set; }
    }
}
#pragma warning restore 1591
