#pragma checksum "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab6f4fdded960f868990b82da5b47aef70e19177"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_vBlog_Content), @"mvc.1.0.razor-page", @"/Pages/vBlog/Content.cshtml")]
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
#line 1 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\_ViewImports.cshtml"
using AllInOne.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
using Utility.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab6f4fdded960f868990b82da5b47aef70e19177", @"/Pages/vBlog/Content.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c837a291a51cf43395483b6d0428a5598cd089b0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_vBlog_Content : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
  
    ViewData["Title"] = "بلاگ - محتوای مقاله";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
Write(await Html.PartialAsync("StructuredData/_OrganizationJsonLD"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
Write(await Html.PartialAsync("Shared/StructuredData/_ArticleJsonLD",Model.ArticleModel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Canonical", async() => {
                WriteLiteral("\r\n    <link rel=\"canonical\"");
                BeginWriteAttribute("href", " href=\"", 356, "\"", 432, 1);
#nullable restore
#line 13 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
WriteAttributeValue("", 363, "https://humate.ir/vBlog/Content?articleId="+Model.ArticleModel.Id, 363, 69, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            DefineSection("Description", async() => {
                WriteLiteral("\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 494, "\"", 549, 1);
#nullable restore
#line 17 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
WriteAttributeValue("", 504, Html.Raw(Model.ArticleModel.MetaDescription), 504, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            DefineSection("Robots", async() => {
                WriteLiteral("\r\n    <meta name=\"robots\"");
                BeginWriteAttribute("content", " content=\"", 601, "\"", 641, 1);
#nullable restore
#line 21 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
WriteAttributeValue("", 611, Model.ArticleModel.MetaRobots, 611, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            DefineSection("Keywords", async() => {
                WriteLiteral("\r\n    <meta name=\"Keywords\"");
                BeginWriteAttribute("content", " content=\"", 697, "\"", 749, 1);
#nullable restore
#line 25 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
WriteAttributeValue("", 707, Html.Raw(Model.ArticleModel.MetaKeywords), 707, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            WriteLiteral(@"<div class=""top-padding"">
    <div class=""wrapper wrapper-content  animated fadeInRight article"">
        <div class=""row"">
            <div class=""col-lg-10 col-lg-offset-1"">
                <div class=""ibox"">
                    <div class=""ibox-content"">
                        <div class=""text-center article-title"">
                            <span class=""text-muted""><i class=""fa fa-clock-o""></i> ");
#nullable restore
#line 34 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                              Write(Model.ArticleModel.CreationDate.GetPersianDateTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <h1>\r\n                                ");
#nullable restore
#line 36 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                           Write(Model.ArticleModel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </h1>\r\n                            <h4>\r\n                                ");
#nullable restore
#line 39 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                           Write(Model.ArticleModel.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </h4>\r\n                        </div>\r\n                        <div>\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1582, "\"", 1738, 1);
#nullable restore
#line 43 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
WriteAttributeValue("", 1588, string.IsNullOrWhiteSpace(Model.ArticleModel.ImageUrl)?
                                          "img/Humate-512.png":Model.ArticleModel.ImageUrl, 1588, 150, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"w-100\"/>\r\n                        </div>\r\n                        <div>\r\n                            ");
#nullable restore
#line 47 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                       Write(Html.Raw(Model.ArticleModel.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-md-3"">
                                <div class=""small text-right"">
                                    <h5>گروه مقاله:</h5>
                                    <div> <i class=""fa fa-archive""> </i> در گروه ");
#nullable restore
#line 54 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                            Write(Model.ArticleModel.ArticleGroup?.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                </div>
                            </div>
                            <div class=""col-md-3"">
                                <div class=""small text-right"">
                                    <h5>جزئیات:</h5>
                                    <div> <i class=""fa fa-clock-o""> </i> تاریخ: ");
#nullable restore
#line 60 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                           Write(Model.ArticleModel.CreationDate.GetPersianDateTime());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                                    <i class=\"fa fa-eye\"> </i> تعداد بازدید: ");
#nullable restore
#line 61 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                        Write(Model.ArticleModel.VisitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""col-md-3"">
                                <div class=""small text-right"">
                                    <h5>نویسنده:</h5>
                                    <div> <i class=""fa fa-pencil""> </i> ");
#nullable restore
#line 67 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                   Write(Model.ArticleModel.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-md-3\">\r\n                                <div class=\"pull-right\">\r\n                                    <h6>");
#nullable restore
#line 72 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                   Write(Model.ArticleModel.MetaDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                                </div>
                            </div>
                        </div>
                        <hr/>
                        <div class=""row"">
                            <div class=""col-lg-offset-5 col-lg-7"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab6f4fdded960f868990b82da5b47aef70e1917712202", async() => {
                WriteLiteral("بازگشت به لیست مقالات");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-articleGroupId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\vBlog\Content.cshtml"
                                                                    WriteLiteral(Model.ArticleModel.ArticleGroupId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleGroupId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-articleGroupId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleGroupId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllInOne.Pages.vBlog.ContentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AllInOne.Pages.vBlog.ContentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AllInOne.Pages.vBlog.ContentModel>)PageContext?.ViewData;
        public AllInOne.Pages.vBlog.ContentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
