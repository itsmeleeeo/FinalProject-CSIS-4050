// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 3 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewSales.razor"
using FPProjectStudentSuccess.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/viewsales")]
    public partial class ViewSales : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\ViewSales.razor"
       
    public List<Sales> salesList = new List<Sales>();
    public string Filter { get; set; }
    public string Salesperson { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected async Task LoadData()
    {
        salesList = await SaleSrv.GetSalesAsync();
    }

    public bool IsVisible(Sales sale)
    {
        if (string.IsNullOrEmpty(Filter)) { return true; }
        else if (sale.ProductName.Contains(Filter, StringComparison.OrdinalIgnoreCase)) { return true; }
        else if (Salesperson.Contains(Filter, StringComparison.OrdinalIgnoreCase)) { return true; }
        else if (sale.Quantity.ToString().StartsWith(Filter) || sale.SalesTotal.ToString().StartsWith(Filter)) { return true; }
        else { return false; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.SalesService SaleSrv { get; set; }
    }
}
#pragma warning restore 1591
