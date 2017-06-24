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

    Public Class ItemsController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities


        ' GET: api/Items
        ''' <summary>
        ''' Obtiene la liste de articulos
        ''' </summary>
        ''' <returns></returns>
        Function GetItemsView() As IQueryable(Of ItemsView)
            Return db.ItemsView
        End Function

        ' GET: api/Items
        ''' <summary>
        ''' Obtiene la lista de articulos por cliente
        ''' </summary>
        ''' <param name="ClientId">Id del cliente</param>
        ''' <returns></returns>
        Function GetItemsView(ByVal ClientId As String) As IQueryable(Of ItemsView)
            Return db.ItemsView.Where(Function(x) x.Custnmbr = ClientId)
        End Function

        '' GET: api/Items/5
        '''' <summary>
        '''' 
        '''' </summary>
        '''' <param name="id"></param>
        '''' <param name="ClientId"></param>
        '''' <returns></returns>
        '<ResponseType(GetType(ItemsView))>
        'Async Function GetItemsView(ByVal id As String, ByVal ClientId As String) As Task(Of IHttpActionResult)
        '    Dim itemsView As ItemsView = Await db.ItemsView.FindAsync(id, ClientId)
        '    If IsNothing(itemsView) Then
        '        Return NotFound()
        '    End If

        '    Return Ok(itemsView)
        'End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ItemsViewExists(ByVal id As String) As Boolean
            Return db.ItemsView.Count(Function(e) e.ID = id) > 0
        End Function
    End Class
End Namespace