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
#line 3 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddStock.razor"
using FPProjectStudentSuccess.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addstock")]
    public partial class AddStock : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 114 "C:\Temp\FPProjectStudentSuccess\FinalProject-CSIS-4050\FPProjectStudentSuccessBSA\Pages\AddStock.razor"
       
    string name = "";
    string publisher = "";
    int quantity = 0;
    int year = 2022;
    decimal price = 0;

    public List<Product> IGBDList = new List<Product>();

    public string Filter { get; set; }
    public string Plataform { get; set; }

    protected void Edit(Product pdt)
    {
        name = pdt.Name;
        publisher = pdt.Publisher;
        using (var ctx = new FPProjectStudentSuccessDBContext())
        {
            var getPlataform = ctx.Plataform.Where(x => x.Id == pdt.PlataformId).First();
            Plataform = getPlataform.Name;
        }
        year = pdt.Year;
    }

    protected async Task LoadData()
    {
        IGBDList = await IGDBSrv.GetIGDB(Filter);
    }

    protected async Task SubmitData()
    {
        await PdtSrv.InsertProductAsync(name, publisher, Plataform, quantity, year, price);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.ProductService PdtSrv { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FPProjectStudentSuccessBSA.Service.IGDBService IGDBSrv { get; set; }
    }
}
#pragma warning restore 1591
