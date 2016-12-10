@ModelType Model.Backend.Uma.AccordionModel

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
        <input type="hidden" id="id" name="id" value="@Model.ID" />
    <div class="form-group">
        <label for="Name" class="col-sm-4">Name</label>
        <div class="col-sm-8">
            <input type="text" name="name" id="name" value="@Model.Name" class="form-control" placeholder="Name" required="required" />
        </div>
    </div>
    <div class="form-group">
        <label for="Male" class="col-sm-4">Male</label>
        <div class="col-sm-8">
            <input type="checkbox" name="male" id="male" @(If(Model.Male, "checked", "")) class="form-control" required="required" />
        </div>
    </div>
    <div class="form-group">
        <label for="Female" class="col-sm-4">Female</label>
        <div class="col-sm-8">
            <input type="checkbox" name="female" id="female" @(If(Model.Female, "checked", "")) class="form-control" required="required" />
        </div>
    </div>
    <div class="form-group">
        <label for="Slot" class="col-sm-4">Slot</label>
        <div class="col-sm-8">
            <select id="slot" class="form-control" required="required">
                <option value="">Bitte wählen</option>
                @If Model.SlotNr = 0 Then
                @<option value="0" selected="selected">Augen</option>
                Else
                  @<option value="0">Augen</option>
                End If
                @If Model.SlotNr = 1 Then
                @<option value="1" selected="selected">Mund</option>
                Else
                  @<option value="1">Mund</option>
                End If
                @If Model.SlotNr = 2 Then
                @<option value="2" selected="selected">Kopf</option>
                Else
                  @<option value="2">Kopf</option>
                End If
                @If Model.SlotNr = 3 Then
                @<option value="3" selected="selected">Oberkörper</option>
                Else
                  @<option value="3">Oberkörper</option>
                End If
                @If Model.SlotNr = 4 Then
                @<option value="4" selected="selected">Hände</option>
                Else
                  @<option value="4">Hände</option>
                End If
                @If Model.SlotNr = 5 Then
                @<option value="5" selected="selected">Unterkörper</option>
                Else
                  @<option value="5">Unterkörper</option>
                End If
                @If Model.SlotNr = 6 Then
                @<option value="6" selected="selected">Füße</option>
                Else
                  @<option value="6">Füße</option>
                End If
                @If Model.SlotNr = 7 Then
                @<option value="7" selected="selected">Haare</option>
                Else
                  @<option value="7">Haare</option>
                End If
                @If Model.SlotNr = 8 Then
                @<option value="8" selected="selected">Haare Modul</option>
                Else
                  @<option value="8">Haare Modul</option>
                End If
            </select>
        </div>
    </div>
    <div class="clearer"></div>
    <input type="submit" class="btn btn-default" id="Save" value="Speichern">
    </form>
            </div>
        </div>
    </section>