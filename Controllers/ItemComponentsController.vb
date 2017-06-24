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

    Public Class ItemComponentsController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities

        ' GET: api/ItemComponents/5
        ''' <summary>
        ''' Obtiene el detalle de item con sus componentes
        ''' </summary>
        ''' <param name="id">Sku</param>
        ''' <returns></returns>
        <ResponseType(GetType(ItemComponentsView))>
        Async Function GetItemComponentsView(ByVal id As String) As Task(Of IHttpActionResult)
            Dim v = Await db.ItemComponentsView.Where(Function(x) x.SkuArticulo.Equals(id)).OrderBy(Function(x) x.Nivel1).ThenBy(Function(x) x.Nivel2).ThenBy(Function(x) x.Nivel3).ToListAsync
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

        Private Function ItemComponentsViewExists(ByVal id As Long) As Boolean
            Return db.ItemComponentsView.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace