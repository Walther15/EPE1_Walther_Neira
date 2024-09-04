Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        'Crear una aplicación Excel
        Dim ExcelApp As New Excel.Application()

        'Abril el archivo Excel
        Dim excelWorkbook As Excel.Workbook = ExcelApp.Workbooks.Open("C:\Users\walth\source\repos\EPE1WaltherNeira\Lista.xls")
        Dim excelWorksheet As Excel.Worksheet = excelWorkbook.Sheets(1)
        Dim excelRange As Excel.Range = excelWorksheet.UsedRange

        'Limpiar el ComboBox antes de llenarlo
        cmbProductos.Items.Clear()

        'Iterar soble las filas del archivo Excel
        For i As Integer = 2 To excelRange.Rows.Count
            Dim nombreProducto As String = excelRange.Cells(i, 1).Value
            cmbProductos.Items.Add(nombreProducto)
        Next

        'Cerrar el archivo Excel
        excelWorkbook.Close()
        ExcelApp.Quit()
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged
        'Crear una aplicación Excel
        Dim excelApp As New Excel.Application()
        Dim excelWorkbook As Excel.Workbook = Nothing
        Try
            'Abrir el archo Excel
            excelWorkbook = excelApp.Workbooks.Open("C:\Users\walth\source\repos\EPE1-Walther_Neira\Lista.xls")
            Dim excelWorksheet As Excel.Worksheet = excelWorkbook.Sheets(1)
            Dim excelRange As Excel.Range = excelWorksheet.UsedRange

            'Buscar el producto seleccionado
            For i As Integer = 2 To excelRange.Rows.Count
                If cmbProductos.SelectedItem.ToString() = excelRange.Cells(i, 1).Value Then
                    txtDescripcion.Text = excelRange.Cells(i, 2).Value.ToString()
                    txtPrecio.Text = excelRange.Cells(i, 6).Value.ToString()
                    txtStock.Text = excelRange.Cells(i, 7).Value.ToString()
                    ' Mostrar mensaje de confirmación
                    MessageBox.Show("Datos ingresados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al abrir el archivo Excel: " & ex.Message)
        Finally
            'Cerrar el archivo Excel si fue abierto correctamente
            If excelWorkbook IsNot Nothing Then
                excelWorkbook.Close()
            End If
            excelApp.Quit()
        End Try
    End Sub
End Class
