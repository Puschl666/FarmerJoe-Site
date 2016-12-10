@ModelType List(Of Model.Backend.Helper.Accordion)

@Code
    Layout = "~/Views/Layout/_Layout.vbhtml"
End Code

<section class="section" id="head">
	<div class="container">
		<div class="row">
            @Html.ActionLink("Abmelden", "Logout", "Backend") - @Html.ActionLink("Zur Übersicht", "Overview", "Backend")
            <h1>UMA-Accordion</h1>
            <ul>
                @Code
                    For Each item As Model.Backend.Helper.Accordion In Model
                End Code
                      <li>
                          @item.Name (<a href="@Url.Action("EditAccordion", "Backend")/@Session("Object").Secure/@item.ID">Accordion bearbeiten</a> - <a href="@Url.Action("DeleteAccordion", "Backend")/@Session("Object").Secure/@item.ID">Accordion löschen</a>)
                          <ul>
                              @Code
                                  If item.Items.Count > 0 Then
                              End Code
                              @Code
                                  For Each subitem As Model.Backend.Helper.AccordionElement In item.Items
                              End Code
                              <li>
                                  @subitem.Name (<a href="@Url.Action("EditAccordionElement", "Backend")/@Session("Object").Secure/@subitem.ID">Accordion-Element bearbeiten</a> - <a href="@Url.Action("DeleteAccordionElement", "Backend")/@subitem.ID">Accordion-Element löschen</a>)
                                  @Code
                                      If Not subitem.Subitem Is Nothing Then
                                  End Code
                                  <ul>
                                      <li>@subitem.Subitem.Name</li>
                                  </ul>
                                  @Code
                                      End If
                                  End Code
                              </li>
                              @Code
                                  Next
                              End Code
                              @Code
                                  End If
                              End Code
                              <li>
                                  @Html.ActionLink("Neues Accordion-Element", "NewAccordionElement", "Backend")
                              </li>
                          </ul>
                      </li>  
                @Code
                    Next
                End Code
                <li>
                    @Html.ActionLink("Neues Accordion", "NewAccordion", "Backend")
                </li>
            </ul>
        </div>
    </div>
</section>