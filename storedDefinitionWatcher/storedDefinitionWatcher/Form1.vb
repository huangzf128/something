Imports Fujitsu.Symfoware.Client

Public Class Form1

    Dim conn As SymfowareConnection

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        conn.Close()
        conn.Dispose()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ListBox1.DisplayMember = "Value"
        ListBox1.ValueMember = "Key"

        Dim myReader As SymfowareDataReader = GetProcedureNameList()

        Do While myReader.Read()
            Dim key As String = GetValue(myReader, "PROCEDURE_NAME")
            Dim value As String = GetValue(myReader, "PROCEDURE_CODE")
            ListBox1.Items.Add(New DictionaryEntry(value, key))
        Loop

        myReader.Close()

    End Sub

    Function GetValue(ByVal myReader As SymfowareDataReader,
        ByVal strName As String) As String

        Dim ret As String = ""
        Dim fld As Integer = 0

        fld = myReader.GetOrdinal(strName)
        If myReader.IsDBNull(fld) Then
            ret = ""
        Else
            ret = myReader.GetValue(fld).ToString().Trim
        End If
        Return ret
    End Function

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim Item As DictionaryEntry = ListBox1.SelectedItem
        Dim myReader As SymfowareDataReader = Nothing

        Try
            myReader = GetProcedureDefinition(Item.Key)
            myReader.Read()
            Dim strText As String = GetValue(myReader, "DESC_VALUE")

            Me.RichTextBox1.Text = Replace(strText, vbCr, vbCrLf)
            myReader.Close()

            ShowStoredInfo(Item.Key)

        Catch ex As Exception
            If myReader IsNot Nothing Then
                myReader.Close()
            End If
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.ListBox1.Items.Clear()
        Me.RichTextBox1.Text = String.Empty

        Dim myReader As SymfowareDataReader = Nothing
        Try
            myReader = GetProcedureNameList()

            ListBox1.DisplayMember = "Value"
            ListBox1.ValueMember = "Key"

            Do While myReader.Read()
                Dim key As String = GetValue(myReader, "PROCEDURE_NAME")
                Dim value As String = GetValue(myReader, "PROCEDURE_CODE")
                ListBox1.Items.Add(New DictionaryEntry(value, key))
            Loop

            myReader.Close()

        Catch ex As Exception

            If myReader IsNot Nothing Then
                myReader.Close()
            End If
        End Try

    End Sub

    Private Sub btnExeProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExeProc.Click
        Try

            Dim Item As DictionaryEntry = ListBox1.SelectedItem
            Dim myReader As SymfowareDataReader = GetProcedureParameterInfo(Item.Key)

            Dim strCommand As String = "CALL CRMSC." & Item.Value & "("
            Dim paramInfos As New List(Of ProcedureParameter)

            Dim i As Integer = 0

            Do While myReader.Read()
                strCommand &= "?,"

                Dim paramInfo As New ProcedureParameter
                paramInfo.SetColType(GetValue(myReader, "COLUMN_TYPE"))
                paramInfo.SetDataType(GetValue(myReader, "DATA_TYPE"))
                paramInfo.SetMax(GetValue(myReader, "CHAR_MAX_LENGTH"))
                paramInfo.SetColName(GetValue(myReader, "COLUMN_NAME"))
                i += 1
                paramInfos.Add(paramInfo)
            Loop
            strCommand = strCommand.TrimEnd(", ") & ")"

            myReader.Close()

            Dim command As New SymfowareCommand(strCommand, conn)

            For Each paramInfo As ProcedureParameter In paramInfos
                Dim param As New SymfowareParameter()
                param.ParameterName = paramInfo.GetColName
                param.SymfowareDbType = paramInfo.GetDataType()
                param.Direction = paramInfo.GetColType()

                If param.Direction = ParameterDirection.Input Then
                    param.Value = GetUserInput(paramInfo.GetColName())
                ElseIf param.Direction = ParameterDirection.Output Then
                    param.Size = paramInfo.GetMax()
                End If
                command.Parameters.Add(param)
            Next
            command.ExecuteNonQuery()

            Dim text1 As String = ("result:  " & command.Parameters.Item("oERRMSG").Value)
            command.Dispose()

            'MsgBox(text1)

        Catch exception1 As Exception
            'エラー処理ルーチンを記述
            MsgBox(exception1.Message)
        End Try
    End Sub

#Region "Method"

    ''' <summary>
    ''' 接続を取得する
    ''' </summary>
    Private Sub GetConnection()

        Try
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        Catch ex As Exception

        End Try

        Try
            conn = New SymfowareConnection("DATA SOURCE=10.83.240.210;PORT=2050;" & "INITIAL CATALOG=CRMDB;USER ID=crmate;PASSWORD=7QXb7ytgb9")
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
        End Try

    End Sub

    ''' <summary>
    ''' ストアド名リストを取得する
    ''' </summary>
    ''' <returns></returns>
    Private Function GetProcedureNameList() As SymfowareDataReader

        GetConnection()

        Dim str As String = "SELECT " &
                            " PROCEDURE_NAME, PROCEDURE_CODE " &
                            "FROM " &
                                " RDBII_SYSTEM.RDBII_PROC " &
                            "WHERE SCHEMA_NAME = 'CRMSC'" &
                            "ORDER BY PROCEDURE_NAME "

        Dim command As New SymfowareCommand(str, conn)
        Dim myReader As SymfowareDataReader = command.ExecuteReader()

        Return myReader

    End Function

    ''' <summary>
    ''' ストアドの定義を取得する
    ''' </summary>
    ''' <returns></returns>
    Private Function GetProcedureDefinition(ByVal storedCode As String) As SymfowareDataReader
        Dim str As String = "SELECT " &
                    "  DESC_VALUE " &
                    "FROM " &
                        " RDBII_SYSTEM.RDBII_DESCRIPTION " &
                    "WHERE OBJECT_CODE = " & storedCode

        Dim command As New SymfowareCommand(str, conn)
        Dim myReader As SymfowareDataReader = command.ExecuteReader()

        Return myReader
    End Function

    ''' <summary>
    ''' ストアドのパラメータ定義を取得する
    ''' </summary>
    ''' <param name="storedCode"></param>
    ''' <returns></returns>
    Private Function GetProcedureParameterInfo(ByVal storedCode As String) As SymfowareDataReader
        Dim str As String = "SELECT " &
                    "  COLUMN_NAME, COLUMN_CODE, COLUMN_TYPE, DATA_TYPE, CHAR_MAX_LENGTH " &
                    " FROM " &
                        " RDBII_SYSTEM.RDBII_PROC_COL " &
                    " WHERE PROCEDURE_CODE = " & storedCode &
                    " ORDER BY COLUMN_CODE "

        Dim command As New SymfowareCommand(str, conn)
        Dim myReader As SymfowareDataReader = command.ExecuteReader()

        Return myReader

    End Function

    Private Sub ShowStoredInfo(ByVal storedCode)

        txtStoredInfo.Text = "StoredCode : " & storedCode

    End Sub

    Private Function GetUserInput(ByVal prompt As String) As String
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty

        Dim answer As Object

        title = "パラメータを入力してください。"
        defaultResponse = ""

        answer = InputBox(prompt, title, defaultResponse)

        Return answer
    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim tableNames As String() = New String() {"CO_GENERAL_ENTITY_TBT_01", "CO_GENERAL_ENTITY_TBT_02", "CO_GENERAL_ENTITY_TBT_03",
                                                    "CO_GENERAL_ENTITY_TBT_04", "CO_GENERAL_ENTITY_TBT_05", "CO_GENERAL_ENTITY_TBT_06",
                                                    "CO_GENERAL_ENTITY_TBT_07"}


        Dim storedNames As String() = New String() {"CO30F02_INS", "CO31F02_INS", "CO32F02_INS",
                                               "CO33F02_INS", "CO34F02_INS", "CO35F02_INS",
                                               "CO36F02_INS"}

        Dim cnt As Integer = 0

        For Each tableName As String In tableNames

            Dim str As String = "SELECT " &
                    "  TENANT_ID, GYOMU_BLOCK_ID, ENTITY_ID " &
                    " FROM CRMSC." & tableName &
                    " ORDER BY ENTITY_ID "

            Dim command As New SymfowareCommand(str, conn)
            Dim myReader As SymfowareDataReader = command.ExecuteReader()
            Dim records As New List(Of Dictionary(Of String, String))

            Try
                Do While myReader.Read()
                    Dim record As New Dictionary(Of String, String)
                    record.Add("TENANT_ID", GetValue(myReader, "TENANT_ID"))
                    record.Add("GYOMU_BLOCK_ID", GetValue(myReader, "GYOMU_BLOCK_ID"))
                    record.Add("ENTITY_ID", GetValue(myReader, "ENTITY_ID"))
                    records.Add(record)
                Loop

                myReader.Close()
            Catch ex As Exception

                If myReader IsNot Nothing Then
                    myReader.Close()
                End If

            End Try

            For Each row As Dictionary(Of String, String) In records

                For Each item As DictionaryEntry In ListBox1.Items
                    If item.Value = storedNames(cnt) Then
                        CallStoredWithParameter(item, row("TENANT_ID"), row("GYOMU_BLOCK_ID"), row("ENTITY_ID"))
                        Exit For
                    End If
                Next
            Next

            cnt += 1
            command.Dispose()
        Next


    End Sub


    ''' <summary>
    ''' for test
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <param name="tenantId"></param>
    ''' <param name="gyomuId"></param>
    ''' <param name="entityId"></param>
    Private Sub CallStoredWithParameter(ByVal Item As DictionaryEntry, ByVal tenantId As String, ByVal gyomuId As String, ByVal entityId As String)

        Dim myReader As SymfowareDataReader = GetProcedureParameterInfo(Item.Key)

        Dim strCommand As String = "CALL CRMSC." & Item.Value & "("
        Dim paramInfos As New List(Of ProcedureParameter)

        Dim colNames As String() = {"pTENANT_ID", "pGYOMU_BLOCK_ID", "pENTITY_ID", "oRESULT_CD", "oERRSTATE", "oERRMSG", "oERRADDR"}
        Dim i As Integer = 0

        Do While myReader.Read()
            strCommand &= "?,"

            Dim paramInfo As New ProcedureParameter
            paramInfo.SetColType(GetValue(myReader, "COLUMN_TYPE"))
            paramInfo.SetDataType(GetValue(myReader, "DATA_TYPE"))
            paramInfo.SetMax(GetValue(myReader, "CHAR_MAX_LENGTH"))
            paramInfo.SetColName(colNames(i))
            i += 1
            paramInfos.Add(paramInfo)
        Loop
        strCommand = strCommand.TrimEnd(", ") & ")"

        myReader.Close()

        Dim command As New SymfowareCommand(strCommand, conn)

        For Each paramInfo As ProcedureParameter In paramInfos
            Dim param As New SymfowareParameter()
            param.ParameterName = paramInfo.GetColName
            param.SymfowareDbType = paramInfo.GetDataType()
            param.Direction = paramInfo.GetColType()

            If param.Direction = ParameterDirection.Input Then

                If paramInfo.GetColName() = "pTENANT_ID" Then
                    param.Value = tenantId
                ElseIf paramInfo.GetColName() = "pGYOMU_BLOCK_ID" Then
                    param.Value = gyomuId
                ElseIf paramInfo.GetColName() = "pENTITY_ID" Then
                    param.Value = entityId
                End If

            ElseIf param.Direction = ParameterDirection.Output Then
                param.Size = paramInfo.GetMax()
            End If
            command.Parameters.Add(param)
        Next
        command.ExecuteNonQuery()
        command.Dispose()

    End Sub

#End Region



End Class
