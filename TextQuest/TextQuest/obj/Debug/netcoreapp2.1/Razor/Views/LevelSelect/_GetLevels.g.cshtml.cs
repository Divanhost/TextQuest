#pragma checksum "C:\Users\Danil\Desktop\TQ PART 2\new\TextQuest\TextQuest-master\TextQuest\TextQuest\Views\LevelSelect\_GetLevels.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4aa539e6dbdb0d6194565044bcb538cbc435f94d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LevelSelect__GetLevels), @"mvc.1.0.view", @"/Views/LevelSelect/_GetLevels.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LevelSelect/_GetLevels.cshtml", typeof(AspNetCore.Views_LevelSelect__GetLevels))]
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
#line 1 "C:\Users\Danil\Desktop\TQ PART 2\new\TextQuest\TextQuest-master\TextQuest\TextQuest\Views\_ViewImports.cshtml"
using TextQuest;

#line default
#line hidden
#line 2 "C:\Users\Danil\Desktop\TQ PART 2\new\TextQuest\TextQuest-master\TextQuest\TextQuest\Views\_ViewImports.cshtml"
using TextQuest.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa539e6dbdb0d6194565044bcb538cbc435f94d", @"/Views/LevelSelect/_GetLevels.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"374edcb61f9db9a5823563c483f1e281d8fc97a7", @"/Views/_ViewImports.cshtml")]
    public class Views_LevelSelect__GetLevels : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TextQuest.Models.LevelListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 90, true);
            WriteLiteral("\n\n<div class=\"background\">\n    \n    <div class=\"sceneObjectsContainer\" id=\"scContainer\">\r\n");
            EndContext();
#line 7 "C:\Users\Danil\Desktop\TQ PART 2\new\TextQuest\TextQuest-master\TextQuest\TextQuest\Views\LevelSelect\_GetLevels.cshtml"
         foreach (var obj in Model.Levels)
        {

#line default
#line hidden
            BeginContext(184, 353, true);
            WriteLiteral(@"            <div>test</div>
            <!--<div id=id class=""sceneObject"" title=""obj.Name"" style=""position:absolute;left:x;top:y;"" onmouseover=""ShowAction(obj.Id)"">
            <a><img src=""obj.ImageUrl"" onclick=""scObjHandler(obj.Id,Model.CurrentScene.Id,Model.Inventory.Id)"" oncontextmenu=""ShowInfo(obj.Id);return false;"" /></a>
        </div>-->
");
            EndContext();
#line 13 "C:\Users\Danil\Desktop\TQ PART 2\new\TextQuest\TextQuest-master\TextQuest\TextQuest\Views\LevelSelect\_GetLevels.cshtml"
        }

#line default
#line hidden
            BeginContext(548, 27, true);
            WriteLiteral("    </div>\n    \n\n</div>\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TextQuest.Models.LevelListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
