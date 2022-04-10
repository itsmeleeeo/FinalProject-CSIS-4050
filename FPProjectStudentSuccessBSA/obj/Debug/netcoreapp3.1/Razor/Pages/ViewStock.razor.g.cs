#pragma checksum "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2a4603367b3ebe32a0e6e506ddf146f7c9b0cd0"
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
#line 3 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
using FPProjectStudentSuccess.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/viewstock")]
    public partial class ViewStock : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n");
                __builder2.AddMarkupContent(3, "\r\n\r\n        ");
                __builder2.AddMarkupContent(4, "<h3>View Stock</h3>\r\n        ");
                __builder2.OpenElement(5, "table");
                __builder2.AddAttribute(6, "class", "table");
                __builder2.AddMarkupContent(7, "\r\n            ");
                __builder2.AddMarkupContent(8, @"<thead class=""thead"">
                <tr>
                    <th>Name</th>
                    <th>Publisher</th>
                    <th>Platform</th>
                    <th>Year</th>
                    <th>Price</th>
                    <th>Shelf</th>
                    <th>Quantity</th>
                </tr>
            </thead>
            ");
                __builder2.OpenElement(9, "tbody");
                __builder2.AddMarkupContent(10, "\r\n");
#nullable restore
#line 21 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                 if (productList != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                     foreach (var pdt in productList)
                    {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(11, "                        ");
                __builder2.OpenElement(12, "tr");
                __builder2.AddMarkupContent(13, "\r\n                            ");
                __builder2.OpenElement(14, "td");
                __builder2.AddContent(15, 
#nullable restore
#line 26 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(16, "\r\n                            ");
                __builder2.OpenElement(17, "td");
                __builder2.AddContent(18, 
#nullable restore
#line 27 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.Publisher

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(19, "\r\n                            ");
                __builder2.OpenElement(20, "td");
                __builder2.AddContent(21, 
#nullable restore
#line 28 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.PlataformId

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n                            ");
                __builder2.OpenElement(23, "td");
                __builder2.AddContent(24, 
#nullable restore
#line 29 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.Year

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n                            ");
                __builder2.OpenElement(26, "td");
                __builder2.AddContent(27, 
#nullable restore
#line 30 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.Price

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n                            ");
                __builder2.OpenElement(29, "td");
                __builder2.AddContent(30, 
#nullable restore
#line 31 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.ShelfId

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n                            ");
                __builder2.OpenElement(32, "td");
                __builder2.AddContent(33, 
#nullable restore
#line 32 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                                 pdt.Quantity

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(35, "\r\n");
#nullable restore
#line 34 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(36, "                    ");
                __builder2.AddMarkupContent(37, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 39 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(38, "            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewStock.razor"
       
    public List<Product> productList = new List<Product>();

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected async Task LoadData()
    {
        productList = await PdtSrv.GetProductsAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.ProductService PdtSrv { get; set; }
    }
}
#pragma warning restore 1591
