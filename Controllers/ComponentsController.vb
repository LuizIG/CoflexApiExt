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

    Public Class ComponentsController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities

        ' GET: api/Components
        ''' <summary>
        ''' Obtiene la lista de los componentes
        ''' </summary>
        ''' <returns></returns>
        Function GetComponentsView() As IQueryable(Of ComponentsView)
            Return db.ComponentsView
        End Function

        ' GET: api/Components/5
        ''' <summary>
        ''' Obtiene el detalle del componente por id
        ''' </summary>
        ''' <param name="id">Id del componente</param>
        ''' <returns></returns>
        <ResponseType(GetType(ComponentsView))>
        Async Function GetComponentsView(ByVal id As String) As Task(Of IHttpActionResult)
            Dim componentsView As ComponentsView = Await db.ComponentsView.FindAsync(id)
            If IsNothing(componentsView) Then
                Return NotFound()
            End If

            Return Ok(componentsView)
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ComponentsViewExists(ByVal id As String) As Boolean
            Return db.ComponentsView.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace