Imports Fujitsu.Symfoware.Client

Public Structure COLUMN_TYPE
    Public Shared ReadOnly P_IN As String = "1"
    Public Shared ReadOnly P_OUT As String = "4"
End Structure

Public Structure DATA_TYPE
    Public Shared ReadOnly P_CHAR As String = "1"
End Structure

Public Class ProcedureParameter

    Private colName As String = String.Empty
    Private colType As String = String.Empty
    Private dataType As String = String.Empty
    Private max As Integer = 0

    Public Sub SetColType(ByVal colType As String)
        Me.colType = colType
    End Sub

    Public Function GetColType() As Integer
        If colType = COLUMN_TYPE.P_IN Then
            Return ParameterDirection.Input
        ElseIf colType = COLUMN_TYPE.P_OUT Then
            Return ParameterDirection.Output
        End If
    End Function

    Public Sub SetDataType(ByVal dataType As String)
        Me.dataType = dataType
    End Sub

    Public Function GetDataType() As Integer
        If dataType = DATA_TYPE.P_CHAR Then
            Return SymfowareDbType.Char
        End If
    End Function

    Public Sub SetMax(ByVal maxValue As Integer)
        Me.max = maxValue
    End Sub
    Public Function GetMax() As Integer
        Return max
    End Function

    Public Sub SetColName(ByVal name As String)
        Me.colName = name
    End Sub
    Public Function GetColName() As String
        Return colName
    End Function
End Class
