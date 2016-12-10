@Code
    Layout = "~/Views/Layout/_Layout.vbhtml"
End Code

<section class="section" id="head">
	<div class="container">
		<div class="row">
            @Html.ActionLink("Abmelden", "Logout", "Backend")
            <h1>Übersicht</h1>
            <ul>
                <li>@Html.ActionLink("UMA-Accordion", "UmaAccordion", "Backend")</li>
            </ul>
        </div>
    </div>
</section>