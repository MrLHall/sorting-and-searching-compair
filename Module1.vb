
Imports System
Module Module1
    Function MergeSortRecursive(ByRef a As Integer(), low As Integer, high As Integer)
        If low < high Then
            Dim m As Integer = low + (high - low) \ 2
            MergeSortRecursive(a, low, m)
            MergeSortRecursive(a, m + 1, high)
            Merge(a, low, m, high)
        End If
        Return a
    End Function

    Sub Merge(ByRef a As Integer(), low As Integer, mid As Integer, high As Integer)
        Dim i As Integer, j As Integer, k As Integer
        Dim num1 As Integer = mid - low + 1
        Dim num2 As Integer = high - mid

        Dim L(num1 - 1) As Integer
        Dim R(num2 - 1) As Integer
        For i = 0 To num1 - 1
            L(i) = a(low + i)
        Next

        For j = 0 To num2 - 1
            R(j) = a(mid + 1 + j)
        Next

        i = 0
        j = 0
        k = low

        While i < num1 And j < num2
            If L(i) <= R(j) Then
                a(k) = L(i)
                i += 1
            Else
                a(k) = R(j)
                j += 1
            End If

            k += 1
        End While

        While i < num1
            a(k) = L(i)
            i += 1
            k += 1
        End While

        While j < num2
            a(k) = R(j)
            j += 1
            k += 1
        End While
    End Sub
    Function BinarySearch(a As Integer(), looking As Integer)
        Dim first As Integer = 0
        Dim last As Integer = a.Length - 1
        Dim mid As Integer = (last \ 2) + first
        Dim ans As String
        Do
            If a(mid) = looking Then
                ans = ($"we found {looking} at index {mid}")
                Return ans
            ElseIf a(mid) < looking Then
                first = mid + 1
            ElseIf a(mid) > looking Then
                last = mid - 1
            End If
        Loop Until last < first
        ans = ("num not found")
        Return ans

    End Function
    Function LinearSearch(a As Integer(), looking As Integer)
        Dim ans As String
        Console.WriteLine("what item are you looking for")
        For i = 0 To a.Length - 1
            If a(i) = looking Then
                ans = ($"we found {looking} at index {i}")
                Return ans
            End If
        Next
        ans = ("num not found")
        Return ans
    End Function
    Function BubbleSort(a As Integer())
        Dim n = a.Length
        Dim swaps As Boolean = False
        Do
            swaps = False
            For i = 1 To n - 1
                If a(i) < a(i - 1) Then
                    Dim temp = a(i)
                    a(i) = a(i - 1)
                    a(i - 1) = temp
                    swaps = True
                End If
            Next
        Loop Until swaps = False
        Return a
    End Function
    Sub Main()
        Dim sw As New Stopwatch
        Dim numVals As Integer
        Dim n As New Random
        Dim Search As String
        Dim looking As Integer

        sw.Reset()
        Console.Write("Enter the number of values: ")
        numVals = Console.ReadLine
        Dim nums(numVals) As Integer
        For i = 0 To numVals
            nums(i) = n.Next(1, Integer.MaxValue)
        Next
        For i = 0 To (numVals)
            Console.WriteLine(nums(i))
        Next

        Dim choice As Integer
        Do
            Console.WriteLine("pick a number for the function, 1 for bubble sort, 2 for merge sort, 3 for linear search, 4 for Binary search")
            choice = Convert.ToInt32(Console.ReadLine())
            If choice = 1 Then
                Console.WriteLine("we will now sort this array")
                sw.Start()
                nums = BubbleSort(nums)
                sw.Stop()
                For i = 0 To (numVals - 1)
                    Console.WriteLine(nums(i))
                Next
                Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds to sort (bubble)")
                sw.Reset()
            ElseIf choice = 2 Then
                sw.Start()
                nums = MergeSortRecursive(nums, 0, numVals)
                sw.Stop()
                For i = 0 To numVals - 1
                    Console.WriteLine(nums(i))
                Next
                Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds to sort (merge)")
                sw.Reset()
            ElseIf choice = 3 Then
                Console.WriteLine("What number are you looking for?")
                looking = Convert.ToInt64(Console.ReadLine())
                nums = BubbleSort(nums)
                sw.Start()
                Search = LinearSearch(nums, looking)
                sw.Stop()
                Console.WriteLine(Search)
                Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds (Linear)")
                sw.Reset()
            ElseIf choice = 4 Then
                Console.WriteLine("What number are you looking for?")
                looking = Convert.ToInt64(Console.ReadLine())
                nums = BubbleSort(nums)
                sw.Start()
                Search = BinarySearch(nums, looking)
                sw.Stop()
                Console.WriteLine(Search)
                Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds (Binary)")
                sw.Reset()
            Else
                Console.WriteLine("invalid input")
            End If
        Loop Until choice = 1 Or 2 Or 3 Or 4

    End Sub

End Module
