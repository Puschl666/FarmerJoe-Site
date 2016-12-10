Imports System.Web.Mvc

Public Class ErrorController
    Inherits Controller

    ' GET: /Home
    Function Index() As ActionResult
        Return View("Index")
    End Function

    Function NotFound() As ActionResult
        Response.StatusCode = 404

        Return View("NotFound")
    End Function

    Function ServerError() As ActionResult
        Response.StatusCode = 500

        Return View("ServerError")
    End Function
End Class