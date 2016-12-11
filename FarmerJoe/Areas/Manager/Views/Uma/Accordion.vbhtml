﻿@ModelType List(Of FarmerJoe.Model.Backend.Helper.Accordion)
@Code
    ViewData("Title") = "UMA Accordion"
    Layout = "~/Areas/Manager/Views/Layout/Default.vbhtml"
End Code

<div class="row">
    <div class="col-lg-12">
        <p>
            <a href="/manager/uma/newaccordion">Neues Accordion</a>
        </p>
        <table class="table">
            <tr>
                <th>Name</th>
                <th>Male</th>
                <th>Female</th>
                <th>SlotNr</th>
                <th></th>
            </tr>
            @For Each item As FarmerJoe.Model.Backend.Helper.Accordion In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Name)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Male)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Female)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.SlotNr)
                    </td>
                    <td>
                        <a href="/manager/uma/editaccordion/@Session("Object").Secure/@item.Id">bearbeiten</a> |
                        <a href="/manager/uma/deleteaccordion/@Session("Object").Secure/@item.Id">löschen</a> |
                        <a href="/manager/uma/newaccordionelement/@Session("Object").Secure/@item.Id">Neues Element</a>
                    </td>
                </tr>
                @If item.Items.Count > 0 Then
                    @<tr>
                        <td></td>
                        <td colspan="4">
                            <table class="table">
                                @For Each subitem As FarmerJoe.Model.Backend.Helper.AccordionElement In item.Items
                                    @<tr>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) subitem.Name)
                                        </td>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) subitem.Male)
                                        </td>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) subitem.Female)
                                        </td>
                                        <td>
                                            @Html.DisplayFor(Function(modelItem) subitem.SlotNr)
                                        </td>
                                        <td>
                                            <a href="/manager/uma/editaccordionelement/@Session("Object").Secure/@subitem.Id">bearbeiten</a> |
                                            <a href="/manager/uma/deleteaccordionelement/@Session("Object").Secure/@subitem.Id">löschen</a>
                                        </td>
                                    </tr>
                                Next
                            </table>
                        </td>
                    </tr>
                End If
            Next
        </table>
</div>
</div>