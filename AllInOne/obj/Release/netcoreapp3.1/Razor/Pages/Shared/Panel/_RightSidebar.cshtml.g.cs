#pragma checksum "F:\Projects\Azure Repo\AllInOne\AllInOne\Pages\Shared\Panel\_RightSidebar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdc78a2e38c42928127057511eb4bcf78020d872"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared_Panel__RightSidebar), @"mvc.1.0.view", @"/Pages/Shared/Panel/_RightSidebar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdc78a2e38c42928127057511eb4bcf78020d872", @"/Pages/Shared/Panel/_RightSidebar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c837a291a51cf43395483b6d0428a5598cd089b0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Panel__RightSidebar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""right-sidebar"">
    <div class=""sidebar-container"">
        <ul class=""nav nav-tabs navs-3"">
            <li class=""active"">
                <a data-toggle=""tab"" href=""#tab-1"">
                    یاداشت ها
                </a>
            </li>
            <li>
                <a data-toggle=""tab"" href=""#tab-2"">
                    پروژه ها
                </a>
            </li>
            <li");
            BeginWriteAttribute("class", " class=\"", 420, "\"", 428, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <a data-toggle=""tab"" href=""#tab-3"">
                    <i class=""fa fa-gear""></i>
                </a>
            </li>
        </ul>
        <div class=""tab-content"">
            <div id=""tab-1"" class=""tab-pane active"">
                <div class=""sidebar-title"">
                    <h3> <i class=""fa fa-comments-o""></i> آخرین یادداشت ها</h3>
                    <small><i class=""fa fa-tim""></i> شما 10 پیام بازدید نشده دارید.</small>
                </div>
                <div>
                    <div class=""sidebar-message"">
                        <a href=""#"">
                            <div class=""pull-left text-center"">
                                <img alt=""image"" class=""img-circle message-avatar"" src=""/img/favicon.png"">

                                <div class=""m-t-xs"">
                                    <i class=""fa fa-star text-warning""></i>
                                    <i class=""fa fa-star text-warning""></i>
                                </div");
            WriteLiteral(@">
                            </div>
                            <div class=""media-body"">

                                راه های زیادی برای رسیدن به خدا است.
                                <br>
                                <small class=""text-muted"">امروز 4:21 ب.ظ</small>
                            </div>
                        </a>
                    </div>
                </div>
            </div>

            <div id=""tab-2"" class=""tab-pane"">
                <div class=""sidebar-title"">
                    <h3> <i class=""fa fa-cube""></i> Latest projects</h3>
                    <small><i class=""fa fa-tim""></i> You have 14 projects. 10 not completed.</small>
                </div>
                <ul class=""sidebar-list"">
                    <li>
                        <a href=""#"">
                            <div class=""small pull-right m-t-xs"">9 hours ago</div>
                            <h4>Business valuation</h4>
                            It is a long established fact t");
            WriteLiteral(@"hat a reader will be distracted.

                            <div class=""small"">Completion with: 22%</div>
                            <div class=""progress progress-mini"">
                                <div style=""width: 22%;"" class=""progress-bar progress-bar-warning""></div>
                            </div>
                            <div class=""small text-muted m-t-xs"">Project end: 4:00 pm - 12.06.2014</div>
                        </a>
                    </li>
                </ul>
            </div>

            <div id=""tab-3"" class=""tab-pane"">
                <div class=""sidebar-title"">
                    <h3><i class=""fa fa-gears""></i> Settings</h3>
                    <small><i class=""fa fa-tim""></i> You have 14 projects. 10 not completed.</small>
                </div>
                <div class=""setings-item"">
                    <span>
                        Show notifications
                    </span>
                    <div class=""switch"">
                        ");
            WriteLiteral(@"<div class=""onoffswitch"">
                            <input type=""checkbox"" name=""collapsemenu"" class=""onoffswitch-checkbox"" id=""example"">
                            <label class=""onoffswitch-label"" for=""example"">
                                <span class=""onoffswitch-inner""></span>
                                <span class=""onoffswitch-switch""></span>
                            </label>
                        </div>
                    </div>
                </div>

                <div class=""sidebar-content"">
                    <h4>Settings</h4>
                    <div class=""small"">
                        I belive that. Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                        And typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.
                        Over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                    </div>
                </");
            WriteLiteral("div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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