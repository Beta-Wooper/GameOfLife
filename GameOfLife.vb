Imports System
Imports System.Console

' index i represents the columns, or x axis
' index j represents the rows, or y axis

Module GameOfLife
    Dim Height As Integer = 10
    Dim Width As Integer = 30
    Dim cells As Boolean(,)


    Public Sub Main()
        cells = New Boolean(Height - 1, Width - 1) {}
        _GenerateField()
    End Sub
    Sub _DrawAndGrow()
        _DrawGame()
        _Grow()
    End Sub
    Sub _Grow()
        For i As Integer = 0 To Height - 1
            For j As Integer = 0 To Width - 1
                Dim numOfAliveNeighbors As Integer = _GetNeighbors(i, j)

                If cells(i, j) Then
                    If numOfAliveNeighbors < 2 Then
                        cells(i, j) = False
                    End If
                    If numOfAliveNeighbors > 3 Then
                        cells(i, j) = False
                    End If
                Else
                    If numOfAliveNeighbors = 3 Then
                        cells(i, j) = True
                    End If
                End If
            Next
        Next
    End Sub
    Function _GetNeighbors(x As Integer, y As Integer)
        Dim numOfAliveNeighbors As Integer = 0

        For i As Integer = x - 1 To x + 1
            For j As Integer = y - 1 To y + 1
                If Not ((i < 0 OrElse j < 0) OrElse (i >= Height OrElse j >= Width)) Then
                    If cells(i, j) = True Then numOfAliveNeighbors += 1
                End If
            Next
        Next

        Dim returnVal As String = Val(numOfAliveNeighbors)
    End Function
    Sub _DrawGame()
        For i As Integer = 0 To Width - 1
            For j As Integer = 0 To Height - 1
                Console.WriteLine(If(cells(i, j), "x", " "))
                If j = Width - 1 Then Console.WriteLine("")
            Next
        Next

        Console.SetCursorPosition(0, Console.WindowTop)
    End Sub
    Sub _GenerateField()
        Dim generator As Random = New Random()
        Dim number As Integer

        For i As Integer = 0 To Height - 1
            For j As Integer = 0 To Width - 1
                number = generator.Next(2)
                cells(i, j) = (If((number = 0), False, True))
            Next
        Next
    End Sub
End Module
