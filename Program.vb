Imports System
' Code written by AligProgrammer
' Implementation of Linked-list
Module Program
    Class LinkedList
        Private Structure node
            Dim data As Integer
            Dim pointer As Integer
        End Structure

        Private NullPointer As Integer = -1
        Private StartPointer As Integer
        Private FreeListPtr As Integer
        Private List(10) As node

        Public Sub New()
            StartPointer = NullPointer
            FreeListPtr = 0
            For counter = 0 To 9
                List(counter).pointer = counter + 1
            Next counter
            List(10).pointer = NullPointer
        End Sub

        Public Sub InsertItem(item As Integer)
            Dim NewNodePtr As Integer
            Dim ThisNodePtr As Integer
            Dim PreviousPtr As Integer
            If FreeListPtr <> NullPointer Then

                NewNodePtr = FreeListPtr
                List(NewNodePtr).data = item
                FreeListPtr = List(FreeListPtr).pointer



                If StartPointer = NullPointer Then
                    List(NewNodePtr).pointer = NullPointer
                    StartPointer = NewNodePtr
                    Console.WriteLine("Item inserted!")
                Else

                    ThisNodePtr = StartPointer
                    While (ThisNodePtr <> NullPointer) AndAlso (List(ThisNodePtr).data < item)
                        PreviousPtr = ThisNodePtr
                        ThisNodePtr = List(ThisNodePtr).pointer
                    End While


                    If ThisNodePtr = StartPointer Then
                        List(NewNodePtr).pointer = ThisNodePtr
                        StartPointer = NewNodePtr
                    Else
                        List(NewNodePtr).pointer = List(PreviousPtr).pointer
                        List(PreviousPtr).pointer = NewNodePtr
                    End If

                    Console.WriteLine("Item inserted!")
                End If
            Else
                Console.WriteLine("List full!")
            End If
        End Sub


        Public Sub DeleteItem(item As Integer)
            Dim ThisNodePtr As Integer
            Dim PreviousNodePtr As Integer

            ThisNodePtr = StartPointer

            While (ThisNodePtr <> NullPointer) AndAlso (List(ThisNodePtr).data <> item)
                PreviousNodePtr = ThisNodePtr
                ThisNodePtr = List(ThisNodePtr).pointer
            End While

            If ThisNodePtr <> NullPointer Then
                If ThisNodePtr = StartPointer Then
                    StartPointer = List(StartPointer).pointer
                Else
                    List(PreviousNodePtr).pointer = List(ThisNodePtr).pointer
                End If
                List(ThisNodePtr).pointer = FreeListPtr
                FreeListPtr = ThisNodePtr
            Else
                Console.WriteLine("Item could not be deleted as it does not exist")
            End If
        End Sub


        Public Sub OutputAllNodes()
            Dim StartPtr As Integer = StartPointer
            While StartPtr <> NullPointer
                Console.WriteLine(List(StartPtr).data)
                StartPtr = List(StartPtr).pointer
            End While
        End Sub


        Public Function SearchForItem(item As Integer) As Integer
            Dim ThisNodePtr As Integer

            ThisNodePtr = StartPointer
            While (ThisNodePtr <> NullPointer) AndAlso (List(ThisNodePtr).data <> item)
                ThisNodePtr = List(ThisNodePtr).pointer
            End While

            Return ThisNodePtr
        End Function





    End Class
    Sub Main()
        Dim myList As New LinkedList()
        myList.InsertItem(100)
        myList.InsertItem(2)
        myList.InsertItem(1001)
        myList.InsertItem(4)
        myList.InsertItem(3)
        myList.InsertItem(5)
        myList.InsertItem(99)
        myList.InsertItem(1000)
        myList.InsertItem(9)
        myList.InsertItem(67)
        myList.InsertItem(4)
        myList.InsertItem(8)
        myList.InsertItem(8)

        Console.WriteLine("-----------------------")


        myList.OutputAllNodes()


        Console.WriteLine("-----------------------")


        myList.DeleteItem(100)
        myList.DeleteItem(2)
        myList.DeleteItem(1001)
        myList.DeleteItem(4)
        myList.DeleteItem(3)

        Console.WriteLine("-----------------------")

        myList.OutputAllNodes()

        Console.WriteLine("-----------------------")

        Console.WriteLine(myList.SearchForItem(1001))
        Console.WriteLine(myList.SearchForItem(5))

    End Sub
End Module
