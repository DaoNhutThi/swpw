#pragma checksum "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a34a7f21b92c58f34af765915ff8667dbe1a6b03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProjectSWP392.Pages.AdminPage.Pages_AdminPage_DashBoard), @"mvc.1.0.razor-page", @"/Pages/AdminPage/DashBoard.cshtml")]
namespace ProjectSWP392.Pages.AdminPage
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
#line 1 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\_ViewImports.cshtml"
using ProjectSWP392;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a34a7f21b92c58f34af765915ff8667dbe1a6b03", @"/Pages/AdminPage/DashBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20664ce4a76778de9b7f12dbfe96df89a445c2dd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AdminPage_DashBoard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Pages/Shared/_Layout_Admin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body {
        margin: 0;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }

    .dashboard-container {
        display: flex;
        height: 100vh;
    }

    .sidebar {
        flex: 1;
        width: 20%;
        background-color: #333;
        color: #fff;
        margin-top: -20px;
        margin-left: -20px;
        padding: 10px;
        box-sizing: border-box;
    }

    .sidebar ul {
        list-style-type: none;
        padding: 0;
    }

    .sidebar li {
        margin-bottom: 10px;
    }

    .sidebar a {
        text-decoration: none;
        color: #fff;
        font-size: 16px;
        transition: color 0.3s;
        padding: 10px;
        display: block;
        border-radius: 5px;
    }

    .sidebar a:hover {
        color: #ffd700;
    }

    .sidebar a.active {
        background-color: #555;
    }

    .main-content {
        flex: 4;
        padding: 20px;
        box-sizing: border-box;
    }
");
            WriteLiteral(@"
    .section-title {
        font-size: 28px;
        font-weight: bold;
        margin-bottom: 15px;
        color: #333;
    }

    .card {
        background-color: #fff;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        padding: 20px;
        margin: 10px;
        text-align: center;
        border-radius: 8px;
        transition: box-shadow 0.3s;
    }

    .card:hover {
        box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
    }

    .card h2 {
        color: #333;
        margin-bottom: 10px;
    }

    .card p {
        font-size: 24px;
        color: #007bff;
        margin: 0;
    }
</style>

<div class=""dashboard-container"">
    <div class=""sidebar"">
        <ul>
            <li><a href=""/AdminPage/Dashboard"" class=""active"">Dashboard</a></li>
            <li><a href=""/AdminPage/AccountManagement"">Account Management</a></li>
            <li><a href=""/AdminPage/ProductManagement"">Product Management</a></li>
            <li><a href=""/AdminPage/CategoryMana");
            WriteLiteral(@"gement"">Category Management</a></li>
            <li><a href=""/AdminPage/OrderManagement"">Order Management</a></li>
        </ul>
    </div>
    <main class=""col-md-9 ms-sm-auto col-lg-10 px-md-4"">
        <div class=""card shadow"" style=""width: 1225px; margin-left:-17px"">
            <div class=""card-body p-4"">
                <h5 style=""    margin-bottom: 1rem;
    text-align: center;
    font-weight: 800;
    font-size: 33px;
    margin-top: 2rem;"">Dashboard</h5>

                <!-- Statistical Section -->
                <div class=""row mt-4"">
                    <!-- Account Statistics -->
                    <div class=""col-md-3 mb-3"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Account</h5>
                                <p class=""card-text"">Total Accounts: </br>");
#nullable restore
#line 121 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml"
                                                                     Write(Model.acc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                <a href=""/AdminPage/AccountManagement"" class=""btn btn-primary"">View Details</a>
                            </div>
                        </div>
                    </div>

                    <!-- Product Statistics -->
                    <div class=""col-md-3 mb-3"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Product</h5>
                                <p class=""card-text"">Total Products: </br>");
#nullable restore
#line 132 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml"
                                                                     Write(Model.pro);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                <a href=""/AdminPage/ProductManagement"" class=""btn btn-primary"">View Details</a>
                            </div>
                        </div>
                    </div>

                    <!-- Order Statistics -->
                    <div class=""col-md-3 mb-3"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Order</h5>
                                <p class=""card-text"">Total Orders: </br>");
#nullable restore
#line 143 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml"
                                                                   Write(Model.order);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                <a href=""/AdminPage/OrderManagement"" class=""btn btn-primary"">View Details</a>
                            </div>
                        </div>
                    </div>

                    <!-- Revenue Statistics -->
                    <div class=""col-md-3 mb-3"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Revenue</h5>
                                <p class=""card-text"">Total Revenue: $");
#nullable restore
#line 154 "C:\Users\Public\SWP391\ProjectSWP392 (2)\ProjectSWP392\ProjectSWP392\Pages\AdminPage\DashBoard.cshtml"
                                                                Write(Model.reven);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                <button class=""btn btn-primary"" data-toggle=""modal"" data-target=""#orderDetailModal"">
                                    View Details
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</div>
<style>
    .modal-lg {
        max-width: 70% !important;
    }

    .modal-dialog {
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>
<div class=""modal fade custom-modal"" id=""orderDetailModal"" tabindex=""-1"" role=""dialog""
    aria-labelledby=""orderDetailModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""orderDetailModalLabel"">Statistical</h5>
                <button type=""button"" class=""close"" data-dism");
            WriteLiteral(@"iss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <!-- This is where you can load the content of your OrderDetailAdmin page using AJAX or partial view -->
                <div id=""orderDetailContent"" style=""margin-left: 100px;""></div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>
<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
<script src=""https://code.jquery.com/jquery-3.6.4.min.js""></script>
<script>
    $(document).ready(function () {
        $('#orderDetailModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget);
            $.ajax({
                url: '/AdminPage/Chart',
                success: function (data) {
                 ");
            WriteLiteral("   $(\'#orderDetailContent\').html(data);\r\n                }\r\n            });\r\n        });\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectSWP392.Pages.AdminPage.DashBoard> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectSWP392.Pages.AdminPage.DashBoard> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectSWP392.Pages.AdminPage.DashBoard>)PageContext?.ViewData;
        public ProjectSWP392.Pages.AdminPage.DashBoard Model => ViewData.Model;
    }
}
#pragma warning restore 1591