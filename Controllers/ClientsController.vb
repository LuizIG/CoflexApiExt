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

    Public Class ClientsController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities

        ' GET: api/Clients
        ''' <summary>
        ''' Obtiene el listado de clientes
        ''' </summary>
        ''' <returns></returns>
        Function GetClientsView() As IQueryable(Of ClientsView)
            Return db.ClientsView
        End Function

        ' GET: api/Clients/5
        ''' <summary>
        ''' Obtiene el detalle de un cliente por id
        ''' </summary>
        ''' <param name="id">Id del cliente</param>
        ''' <returns></returns>
        <ResponseType(GetType(ClientsView))>
        Async Function GetClientsView(ByVal id As String) As Task(Of IHttpActionResult)
            Dim clientsView As ClientsView = Await db.ClientsView.FindAsync(id)
            If IsNothing(clientsView) Then
                Return NotFound()
            End If

            Return Ok(clientsView)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ClientsViewExists(ByVal id As String) As Boolean
            Return db.ClientsView.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace