<!DOCTYPE html>

<html lang="de">
	@Html.Partial("~/Views/Partial/_Head.vbhtml")
    <body class="theme-invert">
	    @Html.Partial("~/Views/Partial/_Nav.vbhtml")
        @RenderBody()
	    @Html.Partial("~/Views/Partial/_Footer.vbhtml")
    </body>
</html>
