Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports CoflexAPIExt

Namespace Controllers
    Public Class ItemsGroupController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities

        ' GET: api/ItemsGroup
        Function GetItemsGroupView() As IQueryable(Of ItemsGroupView)
            Return db.ItemsGroupView
        End Function

        ' GET: api/ItemsGroup/5
        <ResponseType(GetType(ItemsGroupView))>
        Async Function GetItemsGroupView(ByVal id As String) As Task(Of IHttpActionResult)
            Dim itemsGroupView As ItemsGroupView = Await db.ItemsGroupView.FindAsync(id)
            If IsNothing(itemsGroupView) Then
                Return NotFound()
            End If

            Return Ok(itemsGroupView)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ItemsGroupViewExists(ByVal id As String) As Boolean
            Return db.ItemsGroupView.Count(Function(e) e.ID = id) > 0
        End Function
    End Class
End Namespace