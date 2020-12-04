Namespace Vb.Code
    Public Class Day3
        Public Shared Function Part1(forest as List(Of String)) As Int32
            Return Traverse(forest, 3, 1)
        End Function

        Public Shared Function Part2(forest as List(Of String)) As Int32
            Dim slopes = New List(Of ValueTuple(Of Int32, Int32)) From {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)}
            Return slopes.Aggregate(1, Function(current, slope) current * Traverse(forest, slope.Item1, slope.Item2))
        End Function

        Private Shared Function Traverse(forest as List(Of String), horizontalMove As Int32, verticalMove As Int32) As Int32
            Dim treeCount = 0
            Dim column = horizontalMove
            For index as Int32 = verticalMove To forest.Count - 1 Step verticalMove
                Dim line = forest.ElementAt(index)
                If column >= line.Length Then
                    column = column - line.Length
                End If
                If line.ElementAt(column) = "#" Then
                    treeCount += 1
                End If
                column += horizontalMove
            Next
            Return treeCount
        End Function
    End Class
End Namespace
