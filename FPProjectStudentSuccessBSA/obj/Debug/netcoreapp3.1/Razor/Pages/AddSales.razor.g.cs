#pragma checksum "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ea37c4bd1350ea9c5d8a71e61a8eef0df1dc716"
// <auto-generated/>
#pragma warning disable 1591
namespace FPProjectStudentSuccessBSA.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using FPProjectStudentSuccessBSA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\_Imports.razor"
using FPProjectStudentSuccessBSA.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
using FPProjectStudentSuccess.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addsales")]
    public partial class AddSales : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n\r\n");
                __builder2.AddMarkupContent(3, "\r\n\r\n    ");
                __builder2.AddMarkupContent(4, "<h3>Add Sales</h3>\r\n    ");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "form-group");
                __builder2.AddMarkupContent(7, "\r\n        ");
                __builder2.OpenElement(8, "input");
                __builder2.AddAttribute(9, "class", "form-control");
                __builder2.AddAttribute(10, "type", "text");
                __builder2.AddAttribute(11, "placeholder", "Search Game name on IGDB...");
                __builder2.AddAttribute(12, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                      Filter

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Filter = __value, Filter));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n        <br>\r\n        ");
                __builder2.OpenElement(15, "button");
                __builder2.AddAttribute(16, "type", "button");
                __builder2.AddAttribute(17, "class", "btn btn-primary");
                __builder2.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                LoadData

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(19, "Search IGDB");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(20, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n    ");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "class", "container");
                __builder2.AddMarkupContent(24, "\r\n        ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "class", "row");
                __builder2.AddMarkupContent(27, "\r\n            ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "col-12");
                __builder2.AddMarkupContent(30, "\r\n                ");
                __builder2.OpenElement(31, "table");
                __builder2.AddAttribute(32, "class", "table table-bordered");
                __builder2.AddMarkupContent(33, "\r\n                    ");
                __builder2.AddMarkupContent(34, @"<thead>
                        <tr>
                            <th scope=""col"">Product Name</th>
                            <th scope=""col"">Publisher</th>
                            <th scope=""col"">Year</th>
                            <th scope=""col"">Use This</th>
                        </tr>
                    </thead>
                    ");
                __builder2.OpenElement(35, "tbody");
                __builder2.AddMarkupContent(36, "\r\n");
#nullable restore
#line 32 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                         foreach (var pdt in IGBDList)
                        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(37, "                            ");
                __builder2.OpenElement(38, "tr");
                __builder2.AddMarkupContent(39, "\r\n                                ");
                __builder2.OpenElement(40, "td");
                __builder2.AddContent(41, 
#nullable restore
#line 35 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                     pdt.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n                                ");
                __builder2.OpenElement(43, "td");
                __builder2.AddContent(44, 
#nullable restore
#line 36 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                     pdt.Publisher

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n                                ");
                __builder2.OpenElement(46, "td");
                __builder2.AddContent(47, 
#nullable restore
#line 37 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                     pdt.Year

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(48, "\r\n                                ");
                __builder2.OpenElement(49, "td");
                __builder2.AddMarkupContent(50, "\r\n                                    ");
                __builder2.OpenElement(51, "button");
                __builder2.AddAttribute(52, "type", "button");
                __builder2.AddAttribute(53, "class", "btn btn-success");
                __builder2.AddAttribute(54, "style", "height:25px; width:auto");
                __builder2.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                                                              () => Edit(pdt)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(56, "\r\n                                        ");
                __builder2.AddMarkupContent(57, @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""14"" height=""14"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"" style=""display:flex; align-items:center;"">
                                            <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z""></path>
                                        </svg>
                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n");
#nullable restore
#line 46 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(61, "                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(62, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(63, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, "\r\n    ");
                __builder2.OpenElement(67, "form");
                __builder2.AddAttribute(68, "class", "row g-3");
                __builder2.AddMarkupContent(69, "\r\n        ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "col-md-6");
                __builder2.AddMarkupContent(72, "\r\n            ");
                __builder2.AddMarkupContent(73, "<label for=\"inputName\" class=\"form-label\"><b>Product Name</b></label>\r\n            ");
                __builder2.OpenElement(74, "input");
                __builder2.AddAttribute(75, "type", "text");
                __builder2.AddAttribute(76, "class", "form-control");
                __builder2.AddAttribute(77, "id", "inputName");
                __builder2.AddAttribute(78, "readonly", true);
                __builder2.AddAttribute(79, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 55 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                          name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(80, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => name = __value, name));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(81, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(82, "\r\n        ");
                __builder2.OpenElement(83, "div");
                __builder2.AddAttribute(84, "class", "col-12");
                __builder2.AddMarkupContent(85, "\r\n            ");
                __builder2.AddMarkupContent(86, "<label for=\"inputPlataform\" class=\"form-label\"><b>Plataform</b></label>\r\n            ");
                __builder2.OpenElement(87, "div");
                __builder2.AddMarkupContent(88, "\r\n                ");
                __builder2.OpenElement(89, "label");
                __builder2.AddMarkupContent(90, "\r\n                    ");
                __builder2.OpenElement(91, "input");
                __builder2.AddAttribute(92, "type", "radio");
                __builder2.AddAttribute(93, "value", "PC");
                __builder2.AddAttribute(94, "name", "plataform");
                __builder2.AddAttribute(95, "aria-label", "PC");
                __builder2.AddAttribute(96, "id", "PC");
                __builder2.AddAttribute(97, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 61 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                                        () => plataform = "PC"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(98, " PC\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(99, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(100, "\r\n            ");
                __builder2.OpenElement(101, "div");
                __builder2.AddMarkupContent(102, "\r\n                ");
                __builder2.OpenElement(103, "label");
                __builder2.AddMarkupContent(104, "\r\n                    ");
                __builder2.OpenElement(105, "input");
                __builder2.AddAttribute(106, "type", "radio");
                __builder2.AddAttribute(107, "value", "XBOXX");
                __builder2.AddAttribute(108, "name", "plataform");
                __builder2.AddAttribute(109, "aria-label", "XBOXX");
                __builder2.AddAttribute(110, "id", "XBOXX");
                __builder2.AddAttribute(111, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 67 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                       () => plataform = "XBox Series X"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(112, " XBox Series X\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(113, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(114, "\r\n            ");
                __builder2.OpenElement(115, "div");
                __builder2.AddMarkupContent(116, "\r\n                ");
                __builder2.OpenElement(117, "label");
                __builder2.AddMarkupContent(118, "\r\n                    ");
                __builder2.OpenElement(119, "input");
                __builder2.AddAttribute(120, "type", "radio");
                __builder2.AddAttribute(121, "value", "XBOX1");
                __builder2.AddAttribute(122, "name", "plataform");
                __builder2.AddAttribute(123, "aria-label", "XBOX1");
                __builder2.AddAttribute(124, "id", "XBOX1");
                __builder2.AddAttribute(125, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 73 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                       () => plataform = "XBox One"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(126, " XBox One\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(127, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(128, "\r\n            ");
                __builder2.OpenElement(129, "div");
                __builder2.AddMarkupContent(130, "\r\n                ");
                __builder2.OpenElement(131, "label");
                __builder2.AddMarkupContent(132, "\r\n                    ");
                __builder2.OpenElement(133, "input");
                __builder2.AddAttribute(134, "type", "radio");
                __builder2.AddAttribute(135, "value", "PS5");
                __builder2.AddAttribute(136, "name", "plataform");
                __builder2.AddAttribute(137, "aria-label", "PS5");
                __builder2.AddAttribute(138, "id", "PS5");
                __builder2.AddAttribute(139, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 78 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                                           () => plataform = "PS5"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(140, " PS5\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(141, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(142, "\r\n            ");
                __builder2.OpenElement(143, "div");
                __builder2.AddMarkupContent(144, "\r\n                ");
                __builder2.OpenElement(145, "label");
                __builder2.AddMarkupContent(146, "\r\n                    ");
                __builder2.OpenElement(147, "input");
                __builder2.AddAttribute(148, "type", "radio");
                __builder2.AddAttribute(149, "value", "PS4");
                __builder2.AddAttribute(150, "name", "plataform");
                __builder2.AddAttribute(151, "aria-label", "PS4");
                __builder2.AddAttribute(152, "id", "PS4");
                __builder2.AddAttribute(153, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 83 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                                           () => plataform = "PS4"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(154, " PS4\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(155, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(156, "\r\n            ");
                __builder2.OpenElement(157, "div");
                __builder2.AddMarkupContent(158, "\r\n                ");
                __builder2.OpenElement(159, "label");
                __builder2.AddMarkupContent(160, "\r\n                    ");
                __builder2.OpenElement(161, "input");
                __builder2.AddAttribute(162, "type", "radio");
                __builder2.AddAttribute(163, "value", "Switch");
                __builder2.AddAttribute(164, "name", "plataform");
                __builder2.AddAttribute(165, "aria-label", "Switch");
                __builder2.AddAttribute(166, "id", "SWITCH");
                __builder2.AddAttribute(167, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 89 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                       () => plataform = "Nintendo Switch"

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(168, " Nintendo Switch\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(169, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(170, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(171, "\r\n        ");
                __builder2.OpenElement(172, "div");
                __builder2.AddAttribute(173, "class", "col-md-6");
                __builder2.AddMarkupContent(174, "\r\n            ");
                __builder2.AddMarkupContent(175, "<label for=\"inputQuantity\" class=\"form-label\"><b>Quantity</b></label>\r\n            ");
                __builder2.OpenElement(176, "input");
                __builder2.AddAttribute(177, "type", "number");
                __builder2.AddAttribute(178, "class", "form-control");
                __builder2.AddAttribute(179, "id", "inputQuantity");
                __builder2.AddAttribute(180, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 95 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                quantity

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(181, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => quantity = __value, quantity, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(182, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(183, "\r\n        ");
                __builder2.OpenElement(184, "div");
                __builder2.AddAttribute(185, "class", "col-md-6");
                __builder2.AddMarkupContent(186, "\r\n            ");
                __builder2.AddMarkupContent(187, "<label for=\"inputPrice\" class=\"form-label\"><b>Price</b></label>\r\n            ");
                __builder2.OpenElement(188, "input");
                __builder2.AddAttribute(189, "type", "number");
                __builder2.AddAttribute(190, "class", "form-control");
                __builder2.AddAttribute(191, "id", "inputPrice");
                __builder2.AddAttribute(192, "min", "0.00");
                __builder2.AddAttribute(193, "max", "10000.00");
                __builder2.AddAttribute(194, "step", "0.01");
                __builder2.AddAttribute(195, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 99 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                                                                   salestotal

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(196, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => salestotal = __value, salestotal, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(197, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(198, "\r\n        ");
                __builder2.AddMarkupContent(199, "<div class=\"col-md-6\">\r\n        </div>\r\n        <br>\r\n        ");
                __builder2.OpenElement(200, "div");
                __builder2.AddAttribute(201, "class", "col-12");
                __builder2.AddMarkupContent(202, "\r\n            ");
                __builder2.OpenElement(203, "button");
                __builder2.AddAttribute(204, "type", "submit");
                __builder2.AddAttribute(205, "class", "btn btn-primary");
                __builder2.AddAttribute(206, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 105 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
                                                                    SubmitData

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(207, "Add Sale");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(208, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(209, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(210, "\r\n    <br>\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 111 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddSales.razor"
       
    string name = "";
    string plataform = "";
    int quantity = 0;
    decimal salestotal = 0;
    string email = "";

    public List<Product> IGBDList = new List<Product>();

    public string Filter { get; set; }

    protected void Edit(Product pdt)
    {
        name = pdt.Name;
    }

    protected async Task LoadData()
    {
        IGBDList = await IGDBSrv.GetIGDB(Filter);
    }

    protected override void OnInitialized()
    {
        email = httpContextAccessor.HttpContext.User.Identity.Name;
    }

    protected async Task SubmitData()
    {
        await SaleSrv.InsertSaleAsync(name, plataform, quantity, salestotal, email);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.SalesService SaleSrv { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.IGDBService IGDBSrv { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor httpContextAccessor { get; set; }
    }
}
#pragma warning restore 1591
