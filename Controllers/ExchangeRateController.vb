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


    Public Class ExchangeRateController
        Inherits System.Web.Http.ApiController

        Private db As New GP_desarrolloEntities


        ' GET: api/ExchangeRate/5
        ''' <summary>
        ''' Obtiene el tipo de cambio
        ''' </summary>
        ''' <returns></returns>
        <ResponseType(GetType(ExchangeRateView))>
        Async Function GetExchangeRateView() As Task(Of IHttpActionResult)
            Dim exchangeRateView As ExchangeRateView = Await db.ExchangeRateView.FirstAsync
            If IsNothing(exchangeRateView) Then
                Return NotFound()
            End If

            Return Ok(exchangeRateView)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ExchangeRateViewExists(ByVal id As String) As Boolean
            Return db.ExchangeRateView.Count(Function(e) e.MXN_to_DLLS = id) > 0
        End Function
    End Class
End Namespace