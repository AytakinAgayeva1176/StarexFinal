#pragma checksum "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd25354673c8498eee07e017c6a42a0454f28f6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__OrderDetails), @"mvc.1.0.view", @"/Views/Shared/_OrderDetails.cshtml")]
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
#line 1 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\_ViewImports.cshtml"
using Starex;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\_ViewImports.cshtml"
using Starex.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd25354673c8498eee07e017c6a42a0454f28f6d", @"/Views/Shared/_OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bb75c0b6025f82fb3894717e101f0462229cd0e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Starex.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/usa.7b416161.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/turkey.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/chin.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""modal fade show"" tabindex=""-1"" role=""dialog"" id=""orderDetails"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Details</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div>
                    <dl class=""row"">
                        <dt class=""col-sm-2"">

                            ");
#nullable restore
#line 18 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.TrackingCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10 details\">\r\n\r\n");
#nullable restore
#line 22 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                             if (Model.CountryId == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fd25354673c8498eee07e017c6a42a0454f28f6d5625", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                            }
                            else if (Model.CountryId == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fd25354673c8498eee07e017c6a42a0454f28f6d7015", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 29 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                            }

                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fd25354673c8498eee07e017c6a42a0454f28f6d8381", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 35 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.TrackingCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 38 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\" style=\"cursor:pointer;\">\r\n                            <a");
            BeginWriteAttribute("href", " href=", 1714, "", 1756, 1);
#nullable restore
#line 41 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
WriteAttributeValue("", 1720, Html.DisplayFor(model => model.Url), 1720, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"copy-btn\" data-type=\"attribute\"\r\n                                      data-attr-name=\"data-clipboard-text\" data-model=\"couponCode\"\r\n                                      data-clipboard-text=\"");
#nullable restore
#line 44 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                                                      Write(Html.DisplayFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                               Write(Html.DisplayFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </span>\r\n                            </a>\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 50 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 53 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 56 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.ProductSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 59 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.ProductSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 62 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.ProductColor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 65 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.ProductColor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 68 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.Product_Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 71 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.Product_Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 74 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.Cargo_Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 77 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.Cargo_Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 80 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.PriceResult));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 83 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.PriceResult));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 86 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayNameFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 89 "C:\Users\Code\source\repos\StarexFinalProject\Starex\Starex\Views\Shared\_OrderDetails.cshtml"
                       Write(Html.DisplayFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </dd>
                    </dl>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary modalNone"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Starex.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
