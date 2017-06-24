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

    Public Class DetailComponetsController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities

        ' GET: api/DetailComponets
        ''' <summary>
        ''' Obtiene la lista de componentes con detalles
        ''' </summary>
        ''' <returns></returns>
        Function GetDetailComponetsView() As IQueryable(Of DetailComponetsView)
            Return db.DetailComponetsView
        End Function

        ' GET: api/DetailComponets/5
        ''' <summary>
        ''' Obtiene el detalle de componente 
        ''' </summary>
        ''' <param name="id">Id del componente</param>
        ''' <returns></returns>
        <ResponseType(GetType(DetailComponetsView))>
        Async Function GetDetailComponetsView(ByVal id As String) As Task(Of IHttpActionResult)
            Dim v = Await db.DetailComponetsView.Where(Function(x) x.SkuArticulo.Equals(id)).ToListAsync
            If IsNothing(v) Then
                Return NotFound()
            End If
            Return Ok(v)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function DetailComponetsViewExists(ByVal id As Long) As Boolean
            Return db.DetailComponetsView.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace