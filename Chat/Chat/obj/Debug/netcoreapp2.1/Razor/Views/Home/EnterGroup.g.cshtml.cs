#pragma checksum "d:\C#\Chat_Repository\Chat\Chat\Views\Home\EnterGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf7f2b4dfa72786de6e5802bcc33d5e156744543"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EnterGroup), @"mvc.1.0.view", @"/Views/Home/EnterGroup.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/EnterGroup.cshtml", typeof(AspNetCore.Views_Home_EnterGroup))]
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
#line 1 "d:\C#\Chat_Repository\Chat\Chat\Views\_ViewImports.cshtml"
using Chat;

#line default
#line hidden
#line 2 "d:\C#\Chat_Repository\Chat\Chat\Views\_ViewImports.cshtml"
using Chat.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf7f2b4dfa72786de6e5802bcc33d5e156744543", @"/Views/Home/EnterGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae0d8c26f1bac4ebadd6a59a67055e7526028212", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EnterGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "caddfc5f97da4165be2cc822efe369be", async() => {
                BeginContext(31, 65, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <title>SignalR Chat</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(103, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(105, 2049, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a625ea7acbd45dc839a2d13839e5c7a", async() => {
                BeginContext(111, 221, true);
                WriteLiteral("\r\n   <div id=\"header\"></div><br />\r\n\r\n    <div id=\"inputForm\">\r\n        <input type=\"text\" id=\"message\" />\r\n        <input type=\"button\" id=\"sendBtn\" value=\"Отправить\" />\r\n    </div>\r\n    <div id=\"chatroom\"></div>\r\n\r\n    ");
                EndContext();
                BeginContext(332, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e13aeef564543f2a296c8d30b957bec", async() => {
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
                EndContext();
                BeginContext(365, 1332, true);
                WriteLiteral(@"</script>
    <script>
        
        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(""/chat"")
            .build();        
        // получение сообщения от сервера
        hubConnection.on(""Receive"", function (message, userName) {

            // создаем элемент <b> для имени пользователя
            let userNameElem = document.createElement(""b"");
            userNameElem.appendChild(document.createTextNode(userName + "": ""));

            // создает элемент <p> для сообщения пользователя
            let elem = document.createElement(""p"");
            elem.appendChild(userNameElem);
            elem.appendChild(document.createTextNode(message));

            var firstElem = document.getElementById(""chatroom"").firstChild;
            document.getElementById(""chatroom"").insertBefore(elem, firstElem);

        });
        // диагностическое сообщение
        hubConnection.on(""Notify"", function (message) {

            let elem = document.createElement(""p");
                WriteLiteral(@""");
            elem.appendChild(document.createTextNode(message));

            var firstElem = document.getElementById(""chatroom"").firstChild;
            document.getElementById(""chatroom"").insertBefore(elem, firstElem);
        });

        // установка имени пользователя
        var userName = ");
                EndContext();
                BeginContext(1698, 12, false);
#line 49 "d:\C#\Chat_Repository\Chat\Chat\Views\Home\EnterGroup.cshtml"
                  Write(ViewBag.name);

#line default
#line hidden
                EndContext();
                BeginContext(1710, 26, true);
                WriteLiteral(";\r\n        var groupname= ");
                EndContext();
                BeginContext(1737, 17, false);
#line 50 "d:\C#\Chat_Repository\Chat\Chat\Views\Home\EnterGroup.cshtml"
                  Write(ViewBag.groupname);

#line default
#line hidden
                EndContext();
                BeginContext(1754, 393, true);
                WriteLiteral(@";
        // отправка сообщения на сервер
        document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
            let message = document.getElementById(""message"").value;
            hubConnection.invoke(""Send"", message, userName, groupname);
            document.getElementById(""message"").value = """";
        });

        hubConnection.start();
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2154, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
