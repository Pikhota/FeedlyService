#pragma checksum "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdcd153adf9ae5ae296585e3796ecef1ae0a389f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__contentList), @"mvc.1.0.view", @"/Views/Home/_contentList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_contentList.cshtml", typeof(AspNetCore.Views_Home__contentList))]
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
#line 1 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\_ViewImports.cshtml"
using TestWebClient;

#line default
#line hidden
#line 2 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\_ViewImports.cshtml"
using TestWebClient.Models;

#line default
#line hidden
#line 3 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\_ViewImports.cshtml"
using TestWebClient.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdcd153adf9ae5ae296585e3796ecef1ae0a389f", @"/Views/Home/_contentList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a65ca9e61fdf0033449333519a03fbf7c7d5f358", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__contentList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddContentToCollection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteContentFromCollection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "GetFeedsFromCollection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "GetContent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "GetAllNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::TestWebClient.Models.PageLinkTagHelper __TestWebClient_Models_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
 switch (ViewBag.Content)
{
    case ContentState.EditContent:
        {

#line default
#line hidden
            BeginContext(99, 61, true);
            WriteLiteral("            <div class=\"col-md-pull-4\">\r\n                <h2>");
            EndContext();
            BeginContext(161, 22, false);
#line 9 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
               Write(Model.Collection.Title);

#line default
#line hidden
            EndContext();
            BeginContext(183, 27, true);
            WriteLiteral("</h2>\r\n            </div>\r\n");
            EndContext();
#line 11 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
             foreach (var feedRss in Model.Feeds)
            {

#line default
#line hidden
            BeginContext(276, 63, true);
            WriteLiteral("                <div class=\"col-md-11\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 339, "\"", 359, 1);
#line 14 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 346, feedRss.Link, 346, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(360, 30, true);
            WriteLiteral(">\r\n                        <p>");
            EndContext();
            BeginContext(391, 13, false);
#line 15 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                      Write(feedRss.Title);

#line default
#line hidden
            EndContext();
            BeginContext(404, 33, true);
            WriteLiteral("</p>\r\n                        <p>");
            EndContext();
            BeginContext(438, 19, false);
#line 16 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                      Write(feedRss.Description);

#line default
#line hidden
            EndContext();
            BeginContext(457, 96, true);
            WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n                <div class=\"col-md-1\">\r\n");
            EndContext();
#line 20 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                     if (feedRss.FeedsCollections.Where(feed => feed.CollectionId == ViewBag.CollectionId).Count() == 0)
                    {

#line default
#line hidden
            BeginContext(698, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(722, 392, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "da4b4d521a2347b29bff6a810f2cfb0d", async() => {
                BeginContext(800, 70, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"collectionId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 870, "\"", 899, 1);
#line 23 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 878, ViewBag.CollectionId, 878, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(900, 67, true);
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"feedId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 967, "\"", 986, 1);
#line 24 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 975, feedRss.Id, 975, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(987, 120, true);
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-success\">Follow</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1114, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 27 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1188, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1212, 398, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a64b3892c4a14308ba8c2b0a12b614ab", async() => {
                BeginContext(1295, 70, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"collectionId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1365, "\"", 1394, 1);
#line 31 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 1373, ViewBag.CollectionId, 1373, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1395, 67, true);
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"feedId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1462, "\"", 1481, 1);
#line 32 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 1470, feedRss.Id, 1470, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1482, 121, true);
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-danger\">Unfollow</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1610, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 35 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                    }

#line default
#line hidden
            BeginContext(1635, 24, true);
            WriteLiteral("                </div>\r\n");
            EndContext();
#line 37 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
            }

#line default
#line hidden
#line 37 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
             
        }
        break;
    case ContentState.GetFeedsFromCollection:
        {

#line default
#line hidden
            BeginContext(1759, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1771, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("page-link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70772f71bbcb40b88ca1c4dc77a5dfe5", async() => {
            }
            );
            __TestWebClient_Models_PageLinkTagHelper = CreateTagHelper<global::TestWebClient.Models.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__TestWebClient_Models_PageLinkTagHelper);
#line 42 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
__TestWebClient_Models_PageLinkTagHelper.PageModel = Model.PageViewModel;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __TestWebClient_Models_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __TestWebClient_Models_PageLinkTagHelper.PageAction = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1864, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1868, 31, true);
            WriteLiteral("            <div class=\"row\">\r\n");
            EndContext();
#line 45 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                 foreach (var item in Model.Items)
                {

#line default
#line hidden
            BeginContext(1970, 65, true);
            WriteLiteral("                    <div class=\"row\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2035, "\"", 2411, 1);
#line 48 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 2042, Url.Action("GetNewsInfo", "Home",
                              new
                              {
                                  title = item.Title,
                                  description = item.Description,
                                  image = item.ImageLink,
                                  link = item.Link
                              }), 2042, 369, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2412, 113, true);
            WriteLiteral(">\r\n                            <div class=\"col-md-12\" style=\"border: solid\">\r\n                                <p>");
            EndContext();
            BeginContext(2526, 10, false);
#line 57 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2536, 100, true);
            WriteLiteral("</p>\r\n                            </div>\r\n                        </a>\r\n                    </div>\r\n");
            EndContext();
#line 61 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                }

#line default
#line hidden
            BeginContext(2655, 20, true);
            WriteLiteral("            </div>\r\n");
            EndContext();
#line 63 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
        }
        break;
    case ContentState.GetNewsInfo:
        {

#line default
#line hidden
            BeginContext(2749, 16, true);
            WriteLiteral("            <h2>");
            EndContext();
            BeginContext(2766, 16, false);
#line 67 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
           Write(Model.Item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2782, 28, true);
            WriteLiteral("</h2><b />\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2810, "\"", 2837, 1);
#line 68 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 2816, Model.Item.ImageLink, 2816, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2838, 20, true);
            WriteLiteral(" />\r\n            <p>");
            EndContext();
            BeginContext(2859, 22, false);
#line 69 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
          Write(Model.Item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(2881, 20, true);
            WriteLiteral("</p>\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2901, "\"", 2924, 1);
#line 70 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 2908, Model.Item.Link, 2908, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2925, 17, true);
            WriteLiteral(">Go to News</a>\r\n");
            EndContext();
#line 71 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
        }
        break;
    case ContentState.GetFeedItems:
        {

#line default
#line hidden
            BeginContext(3017, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(3029, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("page-link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eec983305503473d9116b38a7d318fd4", async() => {
            }
            );
            __TestWebClient_Models_PageLinkTagHelper = CreateTagHelper<global::TestWebClient.Models.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__TestWebClient_Models_PageLinkTagHelper);
#line 75 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
__TestWebClient_Models_PageLinkTagHelper.PageModel = Model.PageViewModel;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __TestWebClient_Models_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __TestWebClient_Models_PageLinkTagHelper.PageAction = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3110, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3114, 31, true);
            WriteLiteral("            <div class=\"row\">\r\n");
            EndContext();
#line 78 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                 foreach (var item in Model.Items)
                {

#line default
#line hidden
            BeginContext(3216, 65, true);
            WriteLiteral("                    <div class=\"row\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3281, "\"", 3657, 1);
#line 81 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 3288, Url.Action("GetNewsInfo", "Home",
                              new
                              {
                                  title = item.Title,
                                  description = item.Description,
                                  image = item.ImageLink,
                                  link = item.Link
                              }), 3288, 369, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3658, 113, true);
            WriteLiteral(">\r\n                            <div class=\"col-md-12\" style=\"border: solid\">\r\n                                <p>");
            EndContext();
            BeginContext(3772, 10, false);
#line 90 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(3782, 100, true);
            WriteLiteral("</p>\r\n                            </div>\r\n                        </a>\r\n                    </div>\r\n");
            EndContext();
#line 94 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                }

#line default
#line hidden
            BeginContext(3901, 20, true);
            WriteLiteral("            </div>\r\n");
            EndContext();
#line 96 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
        }
        break;
    case ContentState.GetAllNews:
        {

#line default
#line hidden
            BeginContext(3994, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(4006, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("page-link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59420cc60394b66962a3df42e4a9dc2", async() => {
            }
            );
            __TestWebClient_Models_PageLinkTagHelper = CreateTagHelper<global::TestWebClient.Models.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__TestWebClient_Models_PageLinkTagHelper);
#line 100 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
__TestWebClient_Models_PageLinkTagHelper.PageModel = Model.PageViewModel;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __TestWebClient_Models_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __TestWebClient_Models_PageLinkTagHelper.PageAction = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4087, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(4091, 31, true);
            WriteLiteral("            <div class=\"row\">\r\n");
            EndContext();
#line 103 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                 foreach (var item in Model.Items)
                {

#line default
#line hidden
            BeginContext(4193, 65, true);
            WriteLiteral("                    <div class=\"row\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4258, "\"", 4634, 1);
#line 106 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
WriteAttributeValue("", 4265, Url.Action("GetNewsInfo", "Home",
                              new
                              {
                                  title = item.Title,
                                  description = item.Description,
                                  image = item.ImageLink,
                                  link = item.Link
                              }), 4265, 369, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4635, 113, true);
            WriteLiteral(">\r\n                            <div class=\"col-md-12\" style=\"border: solid\">\r\n                                <p>");
            EndContext();
            BeginContext(4749, 10, false);
#line 115 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(4759, 100, true);
            WriteLiteral("</p>\r\n                            </div>\r\n                        </a>\r\n                    </div>\r\n");
            EndContext();
#line 119 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
                }

#line default
#line hidden
            BeginContext(4878, 20, true);
            WriteLiteral("            </div>\r\n");
            EndContext();
#line 121 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
        }
        break;
    case ContentState.Default:
        {

#line default
#line hidden
            BeginContext(4968, 51, true);
            WriteLiteral("            <h2>Asp.Net MVC Core test client</h2>\r\n");
            EndContext();
#line 126 "D:\KodiSoft\FeedlyServiceApi\TestWebClient\Views\Home\_contentList.cshtml"
        }
        break;
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
