#pragma checksum "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e781a6c4a9cb10dfb4fbfb5732eae056e4b0d860"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared_Panel__Navigation), @"mvc.1.0.view", @"/Pages/Shared/Panel/_Navigation.cshtml")]
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
#line 1 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
using Model.Entity.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
using Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e781a6c4a9cb10dfb4fbfb5732eae056e4b0d860", @"/Pages/Shared/Panel/_Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c837a291a51cf43395483b6d0428a5598cd089b0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Panel__Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Permission>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ContactUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/About", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Home/Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<nav class=""navbar-default navbar-static-side"" role=""navigation"">
    <div class=""sidebar-collapse"">
        <ul class=""nav"" id=""side-menu"">
            <li class=""nav-header"">
                <div class=""dropdown profile-element"">
                    <span>
                        <img alt=""تصویر کاربر"" class=""img-circle""");
            BeginWriteAttribute("src", "\r\n                             src=\"", 410, "\"", 677, 1);
#nullable restore
#line 12 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 446, string.IsNullOrWhiteSpace(Context.Session.Get<User>("CurrentUser").Person.PersonPictureUrl)?
                                      "/img/profile/person-image.png":Context.Session.Get<User>("CurrentUser").Person.PersonPictureUrl, 446, 231, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" 
                             data-src=""/img/profile/person-image.png"" width=""90%"" />
                    </span>
                    <a data-toggle=""dropdown"" class=""dropdown-toggle"" href=""#"">
                        <span class=""clear"">
                            <span class=""block m-t-xs"">
                                <strong class=""font-bold"">");
#nullable restore
#line 19 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                                                      Write(Context.Session.Get<User>("CurrentUser").Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>
                            </span>
                            <span class=""text-muted text-xs block"">امکانات<b class=""caret""></b></span>
                        </span>
                    </a>
                    <ul class=""dropdown-menu animated fadeInRight m-t-xs"">
                        <li><a href=""/"">صفحه ی اصلی</a></li>
                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e781a6c4a9cb10dfb4fbfb5732eae056e4b0d8606229", async() => {
                WriteLiteral("تماس با ما");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e781a6c4a9cb10dfb4fbfb5732eae056e4b0d8607419", async() => {
                WriteLiteral("درباره ی ما");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li class=\"divider\"></li>\r\n                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e781a6c4a9cb10dfb4fbfb5732eae056e4b0d8608665", async() => {
                WriteLiteral("خروج");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                    </ul>\r\n                </div>\r\n                <div class=\"logo-element\">\r\n                    <span class=\"fs-12 font-bold\">پنل کاربری هومت</span><hr />\r\n                    <img alt=\"تصویر کاربر\" class=\"img-circle\"");
            BeginWriteAttribute("src", "\r\n                         src=\"", 1940, "\"", 2202, 1);
#nullable restore
#line 35 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 1972, string.IsNullOrWhiteSpace(Context.Session.Get<User>("CurrentUser").Person.PersonPictureUrl) ?
                                  "/img/profile/person-image.png" : Context.Session.Get<User>("CurrentUser").Person.PersonPictureUrl, 1972, 230, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         data-src=\"/img/profile/person-image.png\" width=\"90%\" />\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 40 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
              
                var father = Model.FirstOrDefault(p => p.ParentId == Guid.Empty);
                foreach (var permission in Model.Where(p => p.ParentId == father?.Id).OrderBy(p => p.SortOrder))
                {
                    var childrens = Model.Where(p => p.ParentId == permission.Id).OrderBy(p => p.SortOrder).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2733, "\"", 2758, 1);
#nullable restore
#line 46 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 2740, permission.Action, 2740, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i");
            BeginWriteAttribute("class", " class=\"", 2792, "\"", 2872, 1);
#nullable restore
#line 47 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 2800, string.IsNullOrEmpty(permission.Icon)?"fa fa-columns":permission.Icon, 2800, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                            <span class=\"nav-label\" data-i18n=\"nav.dashboard\">");
#nullable restore
#line 48 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                                                                         Write(permission.FaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 49 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                             if (childrens.Count > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"fa arrow\"></span>\r\n");
#nullable restore
#line 52 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </a>\r\n");
#nullable restore
#line 54 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                         if (childrens.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul class=\"nav nav-second-level collapse\">\r\n");
#nullable restore
#line 57 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                                 foreach (var child in childrens)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3532, "\"", 3552, 1);
#nullable restore
#line 60 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 3539, child.Action, 3539, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <i");
            BeginWriteAttribute("class", " class=\"", 3602, "\"", 3672, 1);
#nullable restore
#line 61 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
WriteAttributeValue("", 3610, string.IsNullOrEmpty(child.Icon)?"fa fa-columns":child.Icon, 3610, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                            ");
#nullable restore
#line 62 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                                       Write(child.FaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </a>\r\n                                    </li>\r\n");
#nullable restore
#line 65 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 67 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 69 "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_Navigation.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</nav>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Permission>> Html { get; private set; }
    }
}
#pragma warning restore 1591
