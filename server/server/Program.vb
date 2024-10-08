Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection
Imports System
Imports System.Dynamic
Imports System.Data.SqlClient

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddCors(Function(options)
                                     options.AddPolicy("AllowAllOrigins", Sub(policy)
                                                                              policy.AllowAnyOrigin() _
                                                                          .AllowAnyMethod() _
                                                                          .AllowAnyHeader()
                                                                          End Sub)
                                 End Function)

        Dim app = builder.Build()

        app.UseCors("AllowAllOrigins")

        app.MapGet("/getEmpInfo", Function()
                                      Dim SQL As New SQLControl()
                                      Return SQL.GETquery()
                                  End Function)
        app.Run()
    End Sub
End Module
