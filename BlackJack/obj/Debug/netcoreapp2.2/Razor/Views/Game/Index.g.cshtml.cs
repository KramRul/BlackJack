#pragma checksum "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ac83b766df8ed5f844a3cd12d006ca6c55955df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/Index.cshtml", typeof(AspNetCore.Views_Game_Index))]
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
#line 1 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\_ViewImports.cshtml"
using BlackJack;

#line default
#line hidden
#line 2 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\_ViewImports.cshtml"
using BlackJack.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ac83b766df8ed5f844a3cd12d006ca6c55955df", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"674458a2880bae0d8b0dea2766582e776d54dde0", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BlackJack.DataAccess.Entities.Player>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(103, 76, true);
            WriteLiteral("\r\n<!--<form method=\"post\" asp-controller=\"Home\" asp-action=\"StartGame\">-->\r\n");
            EndContext();
            BeginContext(179, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df3663", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 7 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(219, 185, true);
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    <label for=\"exampleFormControlSelect1\">Выберите количество ботов</label>\r\n    <select class=\"form-control\" id=\"countOfBots\" name=\"countOfBots\">\r\n        ");
            EndContext();
            BeginContext(404, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df5492", async() => {
                BeginContext(412, 1, true);
                WriteLiteral("0");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(422, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(432, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df6668", async() => {
                BeginContext(440, 1, true);
                WriteLiteral("1");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(450, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(460, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df7844", async() => {
                BeginContext(468, 1, true);
                WriteLiteral("2");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(478, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(488, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df9020", async() => {
                BeginContext(496, 1, true);
                WriteLiteral("3");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(506, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(516, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df10196", async() => {
                BeginContext(524, 1, true);
                WriteLiteral("4");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(534, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(544, 18, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac83b766df8ed5f844a3cd12d006ca6c55955df11373", async() => {
                BeginContext(552, 1, true);
                WriteLiteral("5");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(562, 187, true);
            WriteLiteral("\r\n    </select>\r\n</div>\r\n<div class=\"form-group\">\r\n    <label>Username:</label>\r\n    <input name=\"player\" id=\"player\" list=\"players\" class=\"form-control\" />\r\n    <datalist id=\"players\">\r\n");
            EndContext();
#line 23 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
            BeginContext(798, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(806, 31, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6ac83b766df8ed5f844a3cd12d006ca6c55955df13042", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 25 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
          WriteLiteral(user.UserName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(837, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 26 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(850, 452, true);
            WriteLiteral(@"    </datalist>
    <div>
        <label>Password:</label>
        <input type=""password"" id=""Password"" name=""Password"" class=""form-control"">
    </div>
</div>
<div class=""form-group"">
    <input type=""button"" class=""btn btn-primary btn-lg"" name=""SubmitLogin"" id=""SubmitLogin"" value=""Login"" />
</div>

<input type=""button"" class=""btn btn-primary btn-lg btn-block"" id=""SubmitStartGame"" name=""SubmitStartGame"" value=""Start Game"">

<div>
    ");
            EndContext();
            BeginContext(1303, 93, false);
#line 40 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Просмотреть все игры", new { action = "AllGames", controller = "StartGame" }));

#line default
#line hidden
            EndContext();
            BeginContext(1396, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1418, 89, false);
#line 43 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Просмотреть всех игроков", new { action = "Index", controller = "User" }));

#line default
#line hidden
            EndContext();
            BeginContext(1507, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1529, 92, false);
#line 46 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Просмотреть игры игроков", new { action = "AllGames", controller = "User" }));

#line default
#line hidden
            EndContext();
            BeginContext(1621, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1643, 91, false);
#line 49 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Просмотреть всех дилеров", new { action = "Index", controller = "Dealer" }));

#line default
#line hidden
            EndContext();
            BeginContext(1734, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1756, 86, false);
#line 52 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Просмотреть всех ботов", new { action = "Index", controller = "Bot" }));

#line default
#line hidden
            EndContext();
            BeginContext(1842, 21, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1864, 79, false);
#line 55 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
Write(Html.RouteLink("Register", new { action = "Register", controller = "Account" }));

#line default
#line hidden
            EndContext();
            BeginContext(1943, 93, true);
            WriteLiteral("\r\n</div>\r\n<input type=\"hidden\" name=\"SubmitLoginPath\" id=\"SubmitLoginPath\" data-submit-Path=\"");
            EndContext();
            BeginContext(2037, 30, false);
#line 57 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
                                                                              Write(Url.Action("Login", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(2067, 106, true);
            WriteLiteral("\">\r\n<input type=\"hidden\" name=\"SubmitStartGamePath\" id=\"SubmitStartGamePath\" data-submit-Start-Game-Path=\"");
            EndContext();
            BeginContext(2174, 27, false);
#line 58 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
                                                                                                 Write(Url.Action("Start", "Game"));

#line default
#line hidden
            EndContext();
            BeginContext(2201, 94, true);
            WriteLiteral("\">\r\n\r\n<input type=\"button\" hidden name=\"getDataByLogin\" id=\"getDataByLogin\" data-submit-Path=\"");
            EndContext();
            BeginContext(2296, 26, false);
#line 60 "C:\Users\Anuitex - 62\source\repos\ProjectsNew\BlackJack\BlackJack\Views\Game\Index.cshtml"
                                                                                   Write(Url.Action("Test", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(2322, 4, true);
            WriteLiteral("\">\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BlackJack.DataAccess.Entities.Player>> Html { get; private set; }
    }
}
#pragma warning restore 1591
