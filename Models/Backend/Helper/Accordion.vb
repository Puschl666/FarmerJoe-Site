Namespace Model.Backend.Helper
    Public Class Accordion
        Public ID As Integer
        Public Name As String
        Public Male As Boolean
        Public Female As Boolean
        Public SlotNr As Integer
        Public AccordionItem As Object = Nothing
        Public Items As List(Of AccordionElement)
    End Class
End Namespace