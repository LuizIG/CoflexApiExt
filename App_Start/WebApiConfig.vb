Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports CoflexAPIExt.Areas.HelpPage

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Configuración y servicios de API web

        ' Rutas de API web
        config.MapHttpAttributeRoutes()
        config.SetDocumentationProvider(New XmlDocumentationProvider(HttpContext.Current.Server.MapPath("bin/CoflexAPIExt.xml")))
        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
