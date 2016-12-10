Imports System.Web.Mvc

Namespace Controllers
    Public Class BackendController
        Inherits Controller

        ' GET: Backend
        Function Index() As ActionResult
            Return View()
        End Function

        Function Login() As ActionResult
            Return View("Login")
        End Function

        ''' <summary>
        ''' Prüft ob der Benutzer existiert und meldet diesen in der Session an
        ''' </summary>
        ''' <param name="Username">Anmeldename</param>
        ''' <param name="Password"></param>
        ''' <remarks></remarks>
        <HttpPost>
        Function CheckLogin(ByVal Username As String, Password As String) As ActionResult
            Try
                Dim user As Model.Backend.User.UserModel = Model.Cache.BeUser.GetByEmail(Username)
                If Not user Is Nothing Then
                    If Helper.User.CheckPassword(user, Password, user.IsPasswordEncrypted) Then
                        Helper.User.EncryptPassword(user)
                        Session("Object").Login = user.Email
                        Session("Object").Secure = Guid.NewGuid.ToString()
                        Return RedirectToAction("Overview")
                    Else
                        ViewData("ErrorMessage") = "Anmeldung nicht möglich, Nutzerdaten sind falsch."
                    End If
                End If
            Catch ex As Exception
                ViewData("ErrorMessage") = "Anmeldung nicht möglich, bitte versuchen sie es später erneut."
            End Try

            Return View("Login")
        End Function

        Function Logout() As ActionResult
            Session("Object").Login = ""
            Session("Object").Secure = ""

            Return View("Login")
        End Function

        Function Overview() As ActionResult
            If Session("Object").Secure Is Nothing Then
                Return Logout()
            End If
            Return View("Overview")
        End Function

        Function UmaAccordion() As ActionResult
            If Session("Object").Secure Is Nothing Then
                Return Logout()
            End If
            Dim Accordions As List(Of Model.Backend.Helper.Accordion) = Model.Cache.Accordion.GetAll()

            Return View("UmaAccordion", Accordions)
        End Function

        Function NewAccordion() As ActionResult
            If Session("Object").Secure Is Nothing Then
                Return Logout()
            End If
            Return View("NewAccordion")
        End Function

        <HttpPost>
        Function NewAccordion(ByVal Hash As String, ByVal Name As String, ByVal Male As Boolean, ByVal Female As Boolean, ByVal SlotNr As Integer) As ActionResult
            If Session("Object").Secure Is Nothing Then
                Return Logout()
            End If
            Dim Accordion As Model.Backend.Uma.AccordionModel = Model.Backend.Uma.AccordionModel.Objects.GetOrCreate(0)

            If Not Accordion Is Nothing Then
                Accordion.Name = Name
                Accordion.Male = Male
                Accordion.Female = Female
                Accordion.SlotNr = SlotNr
                Accordion.Save()
            End If

            Return UmaAccordion()
        End Function

        Function EditAccordion(ByVal Hash As String, Optional ByVal ID As Integer = 0) As ActionResult
            If Not Hash Is Nothing AndAlso Hash = Session("Object").Secure AndAlso ID > 0 Then
                Dim Accordion As Model.Backend.Uma.AccordionModel = Model.Cache.Accordion.GetByID(ID)
                If Not Accordion Is Nothing Then
                    Return View("EditAccordion", Accordion)
                Else
                    Return Logout()
                End If
            Else
                Return Logout()
            End If
        End Function

        <HttpPost>
        Function EditAccordion(ByVal Hash As String, ByVal ID As Integer, ByVal Name As String, ByVal Male As Boolean, ByVal Female As Boolean, ByVal SlotNr As Integer) As ActionResult
            If Session("Object").Secure Is Nothing Then
                Return Logout()
            End If
            Dim Accordion As Model.Backend.Uma.AccordionModel = Model.Cache.Accordion.GetByID(ID)

            If Not Accordion Is Nothing Then
                Accordion.Name = Name
                Accordion.Male = Male
                Accordion.Female = Female
                Accordion.SlotNr = SlotNr
                Accordion.Save()
            End If

            Return EditAccordion(Session("Object").Secure, ID)
        End Function
    End Class
End Namespace