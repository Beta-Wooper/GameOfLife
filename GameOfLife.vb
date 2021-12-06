Imports System

Module Program
    Dim maxDim As Integer = 5

    Dim arrCellA(maxDim, maxDim) As String
    Dim arrCellB(maxDim, maxDim) As String

    Sub Main(args As String())
        Randomize()
        _Random()
        _Draw()
        For i = 0 To 10
            If i = 0 Then
                _Evolution()
                Console.WriteLine("[                ]")
            Else
                _Proceed()
                Console.WriteLine("[                ]")
            End If
        Next
    End Sub

    Sub _Draw()
        For intRow = 0 To maxDim
            For intCol = 0 To maxDim
                If arrCellA(intRow, intCol) = 1 Then
                    Console.Write(" x ")
                Else
                    Console.Write(" _ ")
                End If
            Next
            Console.WriteLine("")
        Next
    End Sub
    Sub _Random()
        For intRow = 0 To maxDim
            For intCol = 0 To maxDim
                If CInt(Rnd()) = 1 Then
                    arrCellA(intRow, intCol) = 1
                Else
                    arrCellA(intRow, intCol) = 0
                End If
            Next
        Next
    End Sub
    Function _GetCounts(intRow, intCol)
        'Gets presence of neighbours (bool data)
        Dim lclIntRow, lclIntcol As Integer
        Dim cntNbrs As Integer = 0

        For lclIntRow = intRow - 1 To intRow + 1
            For lclIntcol = intCol - 1 To intCol + 1
                If lclIntRow <> intRow And lclIntcol <> intCol Then
                    cntNbrs = cntNbrs + arrCellA(lclIntRow, lclIntcol)
                End If
            Next

        Next
        Return cntNbrs
    End Function
    Sub _GetNeighbours()
        'Call _GetCounts for each cell given that the cell is not on the edge
        For intCol = 1 To (maxDim - 1)
            For intRow = 1 To (maxDim - 1)
                arrCellB(intRow, intCol) = _GetCounts(intRow, intCol)
            Next
        Next
    End Sub
    Sub _Evolution()
        _GetNeighbours()
        'applies gamerules for next gen

        For intCol = 0 To maxDim
            For intRow = 0 To maxDim

                Select Case CInt(arrCellB(intRow, intCol))
                    Case 2
                        arrCellA(intRow, intCol) = arrCellA(intRow, intCol)
                    Case 3
                        arrCellA(intRow, intCol) = 1
                    Case Else
                        arrCellA(intRow, intCol) = 0
                End Select
            Next
        Next
    End Sub

    Sub _Proceed()
        _Draw()
        _Evolution()
    End Sub
End Module
