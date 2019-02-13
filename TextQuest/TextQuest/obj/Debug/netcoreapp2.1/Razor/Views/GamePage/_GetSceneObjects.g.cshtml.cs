#pragma checksum "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c372ade982bb09cb1238fdf8c55c8c30c81847d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GamePage__GetSceneObjects), @"mvc.1.0.view", @"/Views/GamePage/_GetSceneObjects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/GamePage/_GetSceneObjects.cshtml", typeof(AspNetCore.Views_GamePage__GetSceneObjects))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c372ade982bb09cb1238fdf8c55c8c30c81847d", @"/Views/GamePage/_GetSceneObjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c247342addd42e1afde703a0ae953360e0862f7", @"/Views/_ViewImports.cshtml")]
    public class Views_GamePage__GetSceneObjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TextQuest.Models.SceneListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 9, true);
            WriteLiteral("\r\n<div>\r\n");
            EndContext();
#line 4 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
     foreach (var obj in Model.CurrentScene.SceneObjects)
    {
        string x = obj.x + "px";
        string y = obj.y + "px";
        string id = obj.Id.ToString();

#line default
#line hidden
            BeginContext(223, 12, true);
            WriteLiteral("        <div");
            EndContext();
            BeginWriteAttribute("id", "   id=", 235, "", 244, 1);
#line 9 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 241, id, 241, 3, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(244, 20, true);
            WriteLiteral(" class=\"sceneObject\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 264, "\"", 305, 5);
            WriteAttributeValue("", 272, "position:absolute;left:", 272, 23, true);
#line 9 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 295, x, 295, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 297, ";top:", 297, 5, true);
#line 9 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 302, y, 302, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 304, ";", 304, 1, true);
            EndWriteAttribute();
            BeginContext(306, 17, true);
            WriteLiteral(">\r\n            <a");
            EndContext();
            BeginWriteAttribute("title", " title=", 323, "", 339, 1);
#line 10 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 330, obj.Name, 330, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(339, 5, true);
            WriteLiteral("><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 344, "\"", 363, 1);
#line 10 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 350, obj.ImageUrl, 350, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 364, "\"", 372, 1);
#line 10 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 369, id, 369, 3, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 373, "\"", 395, 3);
            WriteAttributeValue("", 383, "inc(", 383, 4, true);
#line 10 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
WriteAttributeValue("", 387, obj.Id, 387, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 394, ")", 394, 1, true);
            EndWriteAttribute();
            BeginContext(396, 24, true);
            WriteLiteral("/></a>\r\n        </div>\r\n");
            EndContext();
#line 12 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
    }

#line default
#line hidden
            BeginContext(427, 256, true);
            WriteLiteral(@"</div>
<div class=""container"">
    <div class=""inner first"" onclick=""inc()"">Hello</div>
    <div class=""inner second"">And</div>
    <div class=""inner third"">Goodbye</div>
</div>
<script>
    function inc(data_id) {
        console.log(data_id);

");
            EndContext();
#line 23 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
          
            var scobj = @Model.CurrentScene.SpawnedSceneObjects.FirstOrDefault(so => so.Id == 6);
            string xs = scobj.x + "px";
            string ys = scobj.y + "px";
        

#line default
#line hidden
            BeginContext(887, 541, true);
            WriteLiteral(@"
        var id = data_id;

            $.ajax({
                url: ""/GamePage/DisplaySpawn"",
                type: ""post"",
                data: String(id), //add parameter
                success: function (data) {
                    //success
                    console.log(data);
                },
                error: function () {
                    alert(""error"");
                }
            });



        $(""#"" + id).replaceWith($(""<div>"").addClass(""sceneObject"").css(""position"",""absolute"").css(""left"",""");
            EndContext();
            BeginContext(1429, 2, false);
#line 46 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
                                                                                                     Write(xs);

#line default
#line hidden
            EndContext();
            BeginContext(1431, 14, true);
            WriteLiteral("\").css(\"top\",\"");
            EndContext();
            BeginContext(1446, 2, false);
#line 46 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
                                                                                                                      Write(ys);

#line default
#line hidden
            EndContext();
            BeginContext(1448, 50, true);
            WriteLiteral("\").append($(\"<a>\").append($(\"<img>\").attr(\"src\", \"");
            EndContext();
            BeginContext(1499, 14, false);
#line 46 "C:\Users\Student\source\repos\TextQuest\TextQuest\Views\GamePage\_GetSceneObjects.cshtml"
                                                                                                                                                                           Write(scobj.ImageUrl);

#line default
#line hidden
            EndContext();
            BeginContext(1513, 467, true);
            WriteLiteral(@""").attr(""onclick"", ""inc()""))));

    }
</script>









<script>
    function IncrementCount() {
        $.ajax({
            type: ""POST"",
            url: ""/GamePage/IncrementCount"",
            async: true,
            data: ""Hello"",
            success: function (msg) {
                ServiceSucceeded(msg);
            },
            error: function () {
                return ""error"";
            }
        });

    }
</script>");
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
