#pragma checksum "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1f75514e5b3060e4f334bb89253d484a7d1f857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Game.Pages_Game_Index), @"mvc.1.0.razor-page", @"/Pages/Game/Index.cshtml")]
namespace WebApp.Pages.Game
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
#line 1 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
using GameLogic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
using Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1f75514e5b3060e4f334bb89253d484a7d1f857", @"/Pages/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7d619a4042103fa1b5e41bea579666037da10ea", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Game_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("PlaceBoats"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
  
                                  
    var game = Model.Battleships?? new Battleships(Model.GameOptions);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("<div class=\"text-center\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1f75514e5b3060e4f334bb89253d484a7d1f8574912", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 26 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 27 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
     if (Model.Battleships?.EndGame != 0)
    {//todo ascii

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>WINNER WINNER CHICKEN DINNER!</h2>\n");
#nullable restore
#line 30 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n");
#nullable restore
#line 32 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
     if (Request.Query.ContainsKey("PlaceBoats"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>COMMANDERS!</h2>\n        <h2>Your ships are waiting for the order!</h2>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1f75514e5b3060e4f334bb89253d484a7d1f8577406", async() => {
                WriteLiteral("\n            <div class=\"row\">\n                <div class=\"col\">\n                    <table class=\"table table-bordered\">\n                        <h3> First Player</h3>\n");
#nullable restore
#line 41 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                          
                            var index1 = 1;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                             foreach (var boat in game.GetBoatsArrays().Item1)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\n                                    <td>\n                                        ");
#nullable restore
#line 47 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                   Write(index1);

#line default
#line hidden
#nullable disable
                WriteLiteral(". ");
#nullable restore
#line 47 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                            Write(boat.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(", Size = ");
#nullable restore
#line 47 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                               Write(boat.Size);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                        <br>\n                                        <!--<input type=\"number\" min=\"-1\" max=\"");
#nullable restore
#line 49 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                           Write(game.GetSide() - 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" value=\"-1\" name=\"pOne_col_");
#nullable restore
#line 49 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                                                           Write(index1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" placeholder=\"col\">\n                                        <input type=\"number\" min=\"-1\" max=\"");
#nullable restore
#line 50 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                       Write(game.GetSide() - 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" value=\"-1\" name=\"pOne_row_");
#nullable restore
#line 50 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                                                       Write(index1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" placeholder=\"row\">\n                                        <input type=\"checkbox\" value=\'1\' name=\"pOne_hor_");
#nullable restore
#line 51 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                   Write(index1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" checked/> horizontal?\n                                        <input type=\"hidden\" value=\'0\' name=\"pOne_hor_");
#nullable restore
#line 52 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                 Write(index1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"/>-->\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 55 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                index1++;
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </table>\n                </div>\n                <div class=\"col\">\n                    <table class=\"table table-bordered\">\n                        <h3> Second Player</h3>\n");
#nullable restore
#line 65 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                          
                            var index2 = 1;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                             foreach (var boat in game.GetBoatsArrays().Item2)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\n                                    <td>\n                                        ");
#nullable restore
#line 71 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                   Write(index2);

#line default
#line hidden
#nullable disable
                WriteLiteral(". ");
#nullable restore
#line 71 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                            Write(boat.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(", Size = ");
#nullable restore
#line 71 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                               Write(boat.Size);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                        <br>\n                                        <!--<input type=\"number\" min=\"-1\" max=\"");
#nullable restore
#line 73 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                           Write(game.GetSide() - 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" value=\"-1\" name=\"pOne_col_");
#nullable restore
#line 73 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                                                           Write(index2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" placeholder=\"col\">\n                                        <input type=\"number\" min=\"-1\" max=\"");
#nullable restore
#line 74 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                       Write(game.GetSide() - 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" value=\"-1\" name=\"pOne_row_");
#nullable restore
#line 74 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                                                       Write(index2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" placeholder=\"row\">\n                                        <input type=\"checkbox\" value=\'1\' name=\"pOne_hor_");
#nullable restore
#line 75 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                   Write(index2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" checked/> horizontal?\n                                        <input type=\"hidden\" value=\'0\' name=\"pOne_hor_");
#nullable restore
#line 76 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                                                                 Write(index2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"/>-->\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 79 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                index2++;
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </table>
                </div>

            </div>

            <!--<input type=""submit"" name=""PlaceManually"" value=""Place Ships"" class=""btn btn-primary""/>-->
            <input type=""submit"" name=""PlaceRandomly"" value=""Ships on positions!"" class=""btn btn-primary""/>
            <input type=""submit"" name=""ContinueGame"" value=""Continue"" class=""btn btn-primary""/>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 93 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\n");
#nullable restore
#line 97 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
             if (game.NextMoveByFirst)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>COMMANDER ONE!</h2>\n                <h2>Attaaack!</h2>\n");
#nullable restore
#line 101 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>FUEHRER ZWEI!</h2>\n                <h2>Feuer!!!</h2>\n");
#nullable restore
#line 106 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\n                <div class=\"col\">\n                    <a>");
#nullable restore
#line 109 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                         if (game.NextMoveByFirst)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>ENEMY SOMEWHERE IN THIS AREA</h3>\n");
#nullable restore
#line 112 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>OUR POSITIONS</h3>\n");
#nullable restore
#line 116 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                    <table class=\"table table-bordered\">\n");
#nullable restore
#line 118 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                         for (var row = 0; row < Model.GameOptions.BoardSide; row++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"height:50px\">\n");
#nullable restore
#line 121 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                 for (var col = 0; col < Model.GameOptions.BoardSide; col++)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                     if (game.NextMoveByFirst)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td style=\"width:100px\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5065, "\"", 5118, 7);
            WriteAttributeValue("", 5075, "window.location.href", 5075, 20, true);
            WriteAttributeValue(" ", 5095, "=", 5096, 2, true);
            WriteAttributeValue(" ", 5097, "\'?col=", 5098, 7, true);
#nullable restore
#line 125 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
WriteAttributeValue("", 5104, col, 5104, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5108, "&row=", 5108, 5, true);
#nullable restore
#line 125 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
WriteAttributeValue("", 5113, row, 5113, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5117, "\'", 5117, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor: pointer\">\n                                            ");
#nullable restore
#line 126 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                       Write(GetCellContent(game.GetBoards().Item1[row, col], !game.NextMoveByFirst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n");
#nullable restore
#line 128 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td style=\"width:100px\">\n                                            ");
#nullable restore
#line 132 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                       Write(GetCellContent(game.GetBoards().Item1[row, col], !game.NextMoveByFirst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n");
#nullable restore
#line 134 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                            </tr>\n");
#nullable restore
#line 139 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </table>\n                </div>\n                <div class=\"col\">\n                    <a>");
#nullable restore
#line 143 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                         if (game.NextMoveByFirst)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>OUR POSITIONS</h3>\n");
#nullable restore
#line 146 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>ENEMY SOMEWHERE IN THIS AREA</h3>\n");
#nullable restore
#line 150 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                    <table class=\"table table-bordered\">\n");
#nullable restore
#line 152 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                         for (var row = 0; row < Model.GameOptions.BoardSide; row++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"height:50px\">\n");
#nullable restore
#line 155 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                 for (var col = 0; col < Model.GameOptions.BoardSide; col++)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                     if (!game.NextMoveByFirst)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td style=\"width:100px\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6691, "\"", 6744, 7);
            WriteAttributeValue("", 6701, "window.location.href", 6701, 20, true);
            WriteAttributeValue(" ", 6721, "=", 6722, 2, true);
            WriteAttributeValue(" ", 6723, "\'?col=", 6724, 7, true);
#nullable restore
#line 159 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
WriteAttributeValue("", 6730, col, 6730, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6734, "&row=", 6734, 5, true);
#nullable restore
#line 159 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
WriteAttributeValue("", 6739, row, 6739, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6743, "\'", 6743, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor: pointer\">\n                                            ");
#nullable restore
#line 160 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                       Write(GetCellContent(game.GetBoards().Item2[row, col], game.NextMoveByFirst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n");
#nullable restore
#line 162 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td style=\"width:100px\">\n                                            ");
#nullable restore
#line 166 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                       Write(GetCellContent(game.GetBoards().Item2[row, col], game.NextMoveByFirst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n");
#nullable restore
#line 168 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 168 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\n");
#nullable restore
#line 171 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </table>\n\n                </div>\n\n            </div>\n        </div>\n        <div><h2>Tired From This Insane Battle?</h2>\n            <h3>Save this Battle in Memories, and Go to Sleep!</h3></div>\n        <div>\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1f75514e5b3060e4f334bb89253d484a7d1f85730257", async() => {
                WriteLiteral("\n                <input type=\"text\" name=\"SaveName\" placeholder=\"Enter battle name\">\n                <input type=\"hidden\" name=\"boardState\"");
                BeginWriteAttribute("value", " value=\"", 7808, "\"", 7860, 1);
#nullable restore
#line 183 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
WriteAttributeValue("", 7816, Model.Battleships!.GetSerializedGameState(), 7816, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                <br>\n                <input type=\"submit\" name=\"SaveGame\" value=\"Save This Battle\" class=\"btn btn-primary\"/>\n                \n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n");
#nullable restore
#line 189 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "/Users/jevgeni/RiderProjects/icd0008-2020f/ConsoleApp/ConsoleAppProject/WebApp/Pages/Game/Index.cshtml"
 
    static string GetCellContent(ECellState cellState, bool playersTurn)
    {
        return cellState switch
        {
            ECellState.Empty => " ",
            ECellState.Miss => "@",
            ECellState.Object => playersTurn ? "S" : " ",
            ECellState.Wreck => "X",
            _ => throw new ArgumentException()
            };
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Pages.Game.Index> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.Game.Index> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.Game.Index>)PageContext?.ViewData;
        public WebApp.Pages.Game.Index Model => ViewData.Model;
    }
}
#pragma warning restore 1591
