Imports Microsoft.VisualBasic
'Imports WSIdentitySystem
Imports Danone.MilkSystem.Business
Imports System.Data


Public Class MenuTools

    Public Shared Sub errorHandler(ByVal customPage As Page, ByVal ex As Exception)

        customPage.Session("Exception") = ex
        redirectTo(customPage, "errorPage.aspx")

    End Sub

    Public Shared Sub redirectTo(ByVal customPage As Page, ByVal url As String)

        customPage.ClientScript.RegisterStartupScript(customPage.GetType(), "EFFICACY__URLSYSTEMSREDIRECT", "<script>window.top.location.href='" + url + "';</script>")

    End Sub

    Public Shared Sub rigthClickDenied(ByVal customPage As Page)

        Dim js As New System.Text.StringBuilder()

        js.Append("<script> \n")

        js.Append("\n")

        js.Append(" function efficacy_rigthClickBlocked() { \n")
        js.Append("     if (event.button==2||event.button==3) { \n")
        js.Append("         oncontextmenu='return false'; \n")
        js.Append("     } \n")
        js.Append(" } \n")

        js.Append("\n")

        js.Append(" document.onmousedown=efficacy_rigthClickBlocked \n")
        js.Append(" document.oncontextmenu = new Function(""return false;"") \n")


        js.Append("\n")

        js.Append("</script> \n")

        If Not (customPage.ClientScript.IsStartupScriptRegistered("efficacy__rigthClickDenied")) Then
            customPage.ClientScript.RegisterStartupScript(customPage.GetType(), "efficacy__rigthClickDenied", js.ToString())
        End If

    End Sub

    ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - i
    'Public Shared Function getIdentitySystemServices() As WSIdentitySystem.IdentitySystemServices


    '    Dim userName As String = RK.GlobalTools.Tools.getConfigTagByName("IdentitySystemServicesUserName")
    '    Dim userPassword As String = RK.GlobalTools.Tools.getConfigTagByName("IdentitySystemServicesPassword")
    '    userPassword = RK.GlobalTools.Tools.DecryptString(userPassword)

    '    Dim identityServices As New IdentitySystemServices()
    '    identityServices.PreAuthenticate = True
    '    Dim cache As New System.Net.CredentialCache()
    '    cache.Add(New Uri(identityServices.Url), "Basic", New System.Net.NetworkCredential(userName, userPassword))
    '    identityServices.Credentials = cache

    '    Return identityServices

    'End Function
    ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - f


    Public Shared Function getInitialContext(ByVal context As HttpContext, ByVal pageName As String) As RK.PageTools.CustomPage


        Dim cp As Object
        'Dim iss As IdentitySystemServices ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - f
        Dim menuitem As New MenuItem

        ' 31/10/2008 - i
        If context.Session("id_login") = "" Then
            context.Response.Redirect("AcessoNegado.htm")
            'Else
            '    menuitem.id_usuario = context.Session("id_login")
            '    menuitem.ds_navigateurl = pageName
            '    Dim dsAcessoPagina As DataSet = menuitem.getMenuItemByFilters
            '    If (dsAcessoPagina.Tables(0).Rows.Count > 0) Then  ' Se tem acesso a página

            '    End If
        End If
        ' 31/10/2008 - f

        If (RK.GlobalTools.Tools.getConfigTagByName("IsSecurityEnable").Trim().ToLower().Equals("true")) Then

            ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - i
            'cp = New RK.PageTools.CustomPage(context)
            'iss = MenuTools.getIdentitySystemServices()

            'If Not (iss.userAccessUrl(cp.userId, pageName)) Then
            '    context.Response.Redirect("AcessoNegado.htm")
            'End If

            ''context.Session("id_login") = cp.userId
            ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - f

        Else

            cp = New RK.PageTools.CustomPage(context, False)
            'context.Session("id_login") = cp.userId = 1
        End If


        Return cp


    End Function


    Public Shared Function getUserFullName(ByVal __userId As Int32) As String

        Dim name As String = String.Empty

        ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - i
        'Dim iss As IdentitySystemServices = MenuTools.getIdentitySystemServices()
        'Dim usr As New Users()
        'usr.userId = __userId

        'Dim dsUsers As System.Data.DataSet = iss.getUsersByFilters(usr)

        'If (dsUsers.Tables(0).Rows.Count > 0) Then
        '    name = dsUsers.Tables(0).Rows(0)("userName").ToString()
        'End If
        ' adri 21/03/2012 - retirada do webservice de segurança do Fábio - f

        Return name

    End Function

End Class
