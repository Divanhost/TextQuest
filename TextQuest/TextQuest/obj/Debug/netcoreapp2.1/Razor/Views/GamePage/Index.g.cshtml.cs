#pragma checksum "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1c346cdd6c8595b5ebf12d86a8177702c4788ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GamePage_Index), @"mvc.1.0.view", @"/Views/GamePage/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/GamePage/Index.cshtml", typeof(AspNetCore.Views_GamePage_Index))]
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
#line 1 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\_ViewImports.cshtml"
using TextQuest;

#line default
#line hidden
#line 2 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\_ViewImports.cshtml"
using TextQuest.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1c346cdd6c8595b5ebf12d86a8177702c4788ac", @"/Views/GamePage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c247342addd42e1afde703a0ae953360e0862f7", @"/Views/_ViewImports.cshtml")]
    public class Views_GamePage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TextQuest.Models.SceneListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onunload", new global::Microsoft.AspNetCore.Html.HtmlString("alert(\'Вы точно решили покинуть наш сайт ?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\Index.cshtml"
  
    ViewBag.Title = "Hello World";

#line default
#line hidden
            BeginContext(85, 8, true);
            WriteLiteral("\r\n\r\n<h3>");
            EndContext();
            BeginContext(94, 13, false);
#line 8 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(107, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
            BeginContext(114, 229, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1067aa78149d4b09acf2a293d9290226", async() => {
                BeginContext(176, 46, true);
                WriteLiteral("\r\n\r\n    <div class=\"background\">\r\n        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 222, "\"", 266, 1);
#line 12 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\Index.cshtml"
WriteAttributeValue("", 228, Model.CurrentScene.BackgroundImageUrl, 228, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(267, 15, true);
                WriteLiteral(" />\r\n\r\n        ");
                EndContext();
                BeginContext(283, 39, false);
#line 14 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\Index.cshtml"
   Write(Html.Partial("_GetSceneObjects", Model));

#line default
#line hidden
                EndContext();
                BeginContext(322, 14, true);
                WriteLiteral("\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(343, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TextQuest.Models.SceneListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
