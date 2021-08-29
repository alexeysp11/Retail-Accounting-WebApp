#pragma checksum "C:\Users\User\Desktop\projects\Retail-Accounting-WebApp\Retail.Accounting\Pages\InputData\InventaryItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d15a960c1fe8684a28781999664cd87427ce725"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Retail.Accounting.Pages.InputData.Pages_InputData_InventaryItem), @"mvc.1.0.razor-page", @"/Pages/InputData/InventaryItem.cshtml")]
namespace Retail.Accounting.Pages.InputData
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
#line 1 "C:\Users\User\Desktop\projects\Retail-Accounting-WebApp\Retail.Accounting\Pages\_ViewImports.cshtml"
using Retail.Accounting;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d15a960c1fe8684a28781999664cd87427ce725", @"/Pages/InputData/InventaryItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a58fce35add18af638dd464efb7c18337392ac37", @"/Pages/_ViewImports.cshtml")]
    public class Pages_InputData_InventaryItem : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\User\Desktop\projects\Retail-Accounting-WebApp\Retail.Accounting\Pages\InputData\InventaryItem.cshtml"
  
    ViewData["Title"] = "InventaryItem";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.11.0/css/jquery.dataTables.min.css"" />

<h1>InventaryItem</h1> 

<table id=""inventary_item_table"" class=""stripe row-border order-column"" style=""width:80%"">
    <thead>
        <tr>
            <th>Product title</th>
            <th>Quantity</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Product title</td>
            <td>Quantity</td>
        </tr>
        <tr>
            <td>Product title</td>
            <td>Quantity</td>
        </tr>
        <tr>
            <td>Product title</td>
            <td>Quantity</td>
        </tr>
        <tr>
            <td>Product title</td>
            <td>Quantity</td>
        </tr>
        <tr>
            <td>Product title</td>
            <td>Quantity</td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <th>Product title</th>
            <th>Quantity</th>
        </tr>
    </tfoot>
</table>

<div id=""sticky_buttons"" style=""border");
            WriteLiteral(@": thin solid black; background: white; visibility: hidden;"">
    <div style=""margin-top: 10px; margin-left: 200px; margin-bottom: 10px;"">
        <input type=""text"" name=""product_title"" id=""product_title"" placeholder=""Product title"" style=""width: 300px;"">
        <input type=""number"" name=""quantity"" id=""quantity"" placeholder=""Quantity""  style=""width: 200px;"">
    </div>

    <div style=""margin-top: 10px; margin-left: 250px; margin-bottom: 10px;"">
        <input class=""home-btn"" type=""button"" value=""Add"">
        <input class=""home-btn"" type=""button"" value=""Edit"">
        <input class=""home-btn"" type=""button"" value=""Delete"">
    </div>
</div>

<script src=""//code.jquery.com/jquery-1.11.0.min.js""></script>
<script src=""//cdn.datatables.net/1.11.0/js/jquery.dataTables.min.js""></script>
<script language=""JavaScript"" type=""text/javascript"">
    $.noConflict();
    jQuery( document ).ready(function( $ ) {
        let isRowSelected = false; 
        
        $(document).ready(function() {
      ");
            WriteLiteral(@"      var table = $('#inventary_item_table').DataTable();

            $('#inventary_item_table tbody').on( 'click', 'tr', function () {
                if ( $(this).hasClass('selected') ) {
                    $(this).removeClass('selected');
                    document.getElementById('sticky_buttons').style.visibility = ""hidden"";
                }
                else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                    document.getElementById('sticky_buttons').style.visibility = ""visible"";
                }
            } );
        } ); 

        if ( $(window).height() >= $(document).find('#main_footer').prop('disabled', true).offset().top - 10 )
        {
            let topPosition = $(document).find('#main_footer').prop('disabled', true).offset().top + document.getElementById('sticky_buttons').offsetHeight; 
            $('#sticky_buttons').css({'position':'fixed','top':'335px'});
        }

   ");
            WriteLiteral(@"     var initTopPosition= $('#sticky_buttons').offset().top; 

        $(window).scroll(function() {
            if($(window).scrollTop() > 0)
            {
                $('#sticky_buttons').css({'position':'fixed','top':'390px'});

                if ( $(window).scrollTop() + $(window).height() >= $(document).find('#main_footer').prop('disabled', true).offset().top - 10 ||
                    $(window).height() >= $(document).height() - 100 )
                {
                    let topPosition = $(document).find('#main_footer').prop('disabled', true).offset().top + document.getElementById('sticky_buttons').offsetHeight; 
                    $('#sticky_buttons').css({'position':'fixed','top':'335px'});
                }
            }
            else
            {
                $('#sticky_buttons').css({'position':'absolute','top':initTopPosition+'px'});
            }
        });
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InventaryItemModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<InventaryItemModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<InventaryItemModel>)PageContext?.ViewData;
        public InventaryItemModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
