Imports ProComp.Models.Visitors.SqlServer

Namespace Model
    Public Class Cache
        Private Sub New()
            ' Singleton
        End Sub

        Private Shared _instance As Cache = New Cache()
        Public Shared ReadOnly Property Instance() As Cache
            Get
                Return _instance
            End Get
        End Property

        Public Shared FeUser As Frontend.User.UserBusiness
        Public Shared BeUser As Backend.User.UserBusiness
        Public Shared Accordion As Backend.Uma.AccordionBusiness
        Public Shared AccordionItem As Backend.Uma.ItemBusiness

        Private InitializingStarted As Boolean = False
        Public Shared InitializingComplete As Boolean = False

        Private RefreshVisitorFeUser As RefreshVisitor
        Private RefreshVisitorBeUser As RefreshVisitor
        Private RefreshVisitorAccordion As RefreshVisitor
        Private RefreshVisitorAccordionItem As RefreshVisitor

        Private Config As ConfigData.Data

        Public Sub Initialize(ConnectionString As String, RefreshPeriod As Integer, Config As ConfigData.Data)
            InitializingStarted = True
            Me.ConnectionString = ConnectionString
            Me.RefreshVisitorInterval = RefreshPeriod
            Me.Config = Config

            'User
            RefreshVisitorFeUser = New RefreshVisitor(Mappings:=Frontend.User.UserModel.GetMappings, ConnectionString:=Cache.Instance.ConnectionString)
            FeUser = New Frontend.User.UserBusiness
            Frontend.User.UserModel.Objects.Accept(RefreshVisitorFeUser, FeUser.GetRefreshPeriod)

            RefreshVisitorBeUser = New RefreshVisitor(Mappings:=Backend.User.UserModel.GetMappings, ConnectionString:=Cache.Instance.ConnectionString)
            BeUser = New Backend.User.UserBusiness
            Backend.User.UserModel.Objects.Accept(RefreshVisitorBeUser, BeUser.GetRefreshPeriod)

            'Accordion
            RefreshVisitorAccordion = New RefreshVisitor(Mappings:=Backend.Uma.AccordionModel.GetMappings, ConnectionString:=Cache.Instance.ConnectionString)
            Accordion = New Backend.Uma.AccordionBusiness
            Backend.Uma.AccordionModel.Objects.Accept(RefreshVisitorAccordion, Accordion.GetRefreshPeriod)

            RefreshVisitorAccordionItem = New RefreshVisitor(Mappings:=Backend.Uma.ItemModel.GetMappings, ConnectionString:=Cache.Instance.ConnectionString)
            AccordionItem = New Backend.Uma.ItemBusiness
            Backend.Uma.ItemModel.Objects.Accept(RefreshVisitorAccordionItem, AccordionItem.GetRefreshPeriod)

            InitializingComplete = True
        End Sub

        Public ReadOnly Property InitializeState As String
            Get
                Dim Result As String = ""

                If InitializingStarted Then
                    If InitializingComplete Then
                        Result = "<br /><br />Initializing completed.<br />" & vbCrLf
                    Else
                        Result = "<br /><br />Initializing...<br />" & vbCrLf
                    End If
                Else
                    Result = "<br /><br />Not Initialized.<br />" & vbCrLf
                End If
                Result &= "<ul>" & vbCrLf
                Result &= "<li>FeUser (Already Cached: " & GetCount(Instance.FeUser) & ")</li>" & vbCrLf
                Result &= "<li>BeUser (Already Cached: " & GetCount(Instance.BeUser) & ")</li>" & vbCrLf
                Result &= "<li>Accordion (Already Cached: " & GetCount(Instance.Accordion) & ")</li>" & vbCrLf
                Result &= "<li>AccordionItem (Already Cached: " & GetCount(Instance.AccordionItem) & ")</li>" & vbCrLf
                Result &= "</ul>"

                Return Result
            End Get
        End Property

        Private Function GetCount(ByRef Objekt As Object) As Integer
            If Not Objekt Is Nothing Then
                Return Objekt.count
            Else
                Return 0
            End If
        End Function

        Public ReadOnly Property GetBusiness(Name As String) As Base.Business
            Get
                Dim Value As Object = Nothing
                Dim FieldInfo = [GetType]().GetField(Name)
                If Not IsNothing(FieldInfo) Then
                    Return FieldInfo.GetValue(Me)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ConnectionString As String
        Public RefreshVisitorInterval As Integer

    End Class
End Namespace