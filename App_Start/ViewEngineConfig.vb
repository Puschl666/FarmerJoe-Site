Imports System.Web.Mvc

Namespace Farmerjoe.App_Start
    Public Module ViewEngineConfig
        Public Sub RegisterViewEngine()
            ' Remove all view Engines
            ViewEngines.Engines.Clear()
            Dim Engine As New RazorViewEngine

            ' Add Customized ViewEngine
            ViewEngines.Engines.Add(Engine)
        End Sub
    End Module
End Namespace