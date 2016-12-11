Imports ProComp.Models
Imports ProComp.Models.Visitors.SqlServer
Imports ProComp.Models.Utils

Namespace Model.Frontend.User
    Public Class UserModel
        Inherits Base.Model

        ''' <summary>
        ''' Die Metadaten für die Modelstruktur.
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Meta
            Inherits Base.Meta

            ' Alle Datenbank-Felder (ID, Deleted und ModifiedOn werden in den Basisklassen abgewickelt)
            Public Shared Email As Field = New StringField()
            Public Shared Username As Field = New StringField()
            Public Shared Password As Field = New StringField()
            Public Shared IsPasswordEncrypted As Field = New BooleanField()
            Public Shared Energy As Field = New IntegerField()
            Public Shared MaxEnergy As Field = New IntegerField()
            Public Shared Asset As Field = New StringField()

            ' Indizes
            Public Shared IdxEmail As IdxField = New IdxField(FieldNames:={"Email"})

            ''' <summary>
            ''' Wir verwenden die SQL-Metas.
            ''' </summary>
            ''' <remarks></remarks>
            Public Class Sql
                ''' <summary>
                ''' Gibt an welche SQL-Tabelle die Daten für dieses Model enthält.
                ''' </summary>
                ''' <value></value>
                ''' <returns></returns>
                ''' <remarks></remarks>
                Public Shared Property Name = "fe_user"
            End Class
        End Class

        ' Properties für den Zugriff auf das Model. DB-Feler (ID, Deleted und ModifiedOn werden in den Basisklassen abgewickelt)
        Public Property Email As String
        Public Property Username As String
        Public Property IsPasswordEncrypted As Boolean
        Public Property Password As String
        Public Property Energy As Integer
        Public Property MaxEnergy As Integer
        Public Property Asset As String

        Public Shared Function GetMappings() As Base.Mappings
            ' Mapping der DB-Felder (ID, Deleted und ModifiedOn werden in den Basisklassen abgewickelt)
            Dim Mappings As Base.Mappings = New Base.Mappings
            Mappings.Add("Email", "Email")
            Mappings.Add("Username", "Username")
            Mappings.Add("Password", "Password")
            Mappings.Add("IsPasswordEncrypted", "IsPasswordEncrypted")
            Mappings.Add("Energy", "Energy")
            Mappings.Add("MaxEnergy", "MaxEnergy")
            Mappings.Add("Asset", "Asset")
            Return Mappings
        End Function

        ''' <summary>
        '''Setzt den globalen Manager für die Verwaltung der Daten.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Property Objects() As Base.Manager(Of UserModel) = New Base.Manager(Of UserModel)
    End Class
End Namespace
