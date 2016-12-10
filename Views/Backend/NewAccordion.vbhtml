@Code
    Layout = "~/Views/Layout/_Layout.vbhtml"
End Code

<section class="section" id="head">
	<div class="container">
		<div class="row">
            @Html.ActionLink("Abmelden", "Logout", "Backend") - @Html.ActionLink("Zur Übersicht", "Overview", "Backend") - @Html.ActionLink("Zu UMA-Accordion", "UmaAccordion", "Backend")
            <h1>Login</h1>
            @code
                If Not ViewData("ErrorMessage") Is Nothing Then
            End Code
            <div class="alert alert-danger" role="alert">
                <i class="fa fa-exclamation-triangle"></i>
                @ViewData("ErrorMessage")
            </div>
            @code
                End If
            End Code
            <form action="/Backend/SaveAccordion" method="post">
                <div class="form-group">
                    <label for="Name" class="col-sm-4">Name</label>
                    <div class="col-sm-8">
                        <input type="text" name="name" id="name" class="form-control" placeholder="Name" required="required" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="Male" class="col-sm-4">Male</label>
                    <div class="col-sm-8">
                        <input type="checkbox" name="male" id="male" class="form-control" required="required" /> Male
                    </div>
                </div>
                <div class="form-group">
                    <label for="Female" class="col-sm-4">Female</label>
                    <div class="col-sm-8">
                        <input type="checkbox" name="female" id="female" class="form-control" required="required" /> Female
                    </div>
                </div>
                <div class="form-group">
                    <label for="Slot" class="col-sm-4">Slot</label>
                    <div class="col-sm-8">
                        <select id="slot" class="form-control" required="required">
                            <option value="">Bitte wählen</option>
                            <option value="0">Augen</option>
                            <option value="1">Mund</option>
                            <option value="2">Kopf</option>
                            <option value="3">Oberkörper</option>
                            <option value="4">Hände</option>
                            <option value="5">Unterkörper</option>
                            <option value="6">Füße</option>
                            <option value="7">Haare</option>
                            <option value="8">Haare Modul</option>
                        </select>
                    </div>
                </div>
                <div class="clearer"></div>
                <input type="submit" class="btn btn-default" id="Save" value="Speichern">
            </form>
        </div>
    </div>
</section>