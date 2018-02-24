Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class Item
    Dim AccessVerify As New VerifyAccess
#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim iRec As Integer
    
#End Region
    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Public Sub GridRowSelect()
        iRec = DataGridView1.CurrentRow.Index
        Dim SLCode As String
        Try
            With ds.Tables("View_StockStatusLIVE")
                SLCode = .Rows(iRec).Item(0)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If SLCode <> "" Then
                conn()
                cmd.CommandText = "Select * From View_Master_Items Where ITEM_CODE = '" + SLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected Item"
                    txticode.ReadOnly = True
                    txticode.Text = CType(dr("ITEM_CODE"), String).Trim
                    txtiname.Text = CType(dr("ITEM_DESC"), String).Trim
                    If CType(dr("ITEM_Active"), String).Trim = "T" Then
                        chbactive.Checked = True
                    Else
                        chbactive.Checked = False
                    End If
                    If CType(dr("ITEM_HOLD"), String).Trim = "T" Then
                        chbhold.Checked = True
                    Else
                        chbhold.Checked = False
                    End If
                    cbdiv.SelectedValue = CType(dr("DIV_CODE"), String).Trim
                    If CType(dr("ITM_TYPE"), String).Trim = "R" Then
                        rbreg.Checked = True
                        rbpromo.Checked = False
                    Else
                        rbpromo.Checked = True
                        rbreg.Checked = False
                    End If
                    txtpack.Text = CType(dr("PACK"), String).Trim
                    txtwght.Text = CType(dr("WEIGHT"), String).Trim
                    cbuom.SelectedValue = CType(dr("ITEM_AUNIT"), String).Trim
                    txtuvalue.Text = CType(dr("ITEM_AUNIT_VALUE"), String).Trim
                    txtoqty.Text = CType(dr("ITEM_OPN_QTY"), String).Trim
                    cbcrncy.SelectedValue = CType(dr("CUR_CODE"), String).Trim
                    cbshiptrm.SelectedValue = CType(dr("ITM_TERMS"), String).Trim
                    txtcp.Text = CType(dr("OPNCOST"), String).Trim
                    txtpp.Text = CType(dr("ITEM_FR_PRICE"), String).Trim
                    txtcost.Text = CType(dr("COST"), String).Trim
                    txtsp.Text = CType(dr("ITEM_PRICE"), String).Trim
                End If
                dr.Close()
                con.Close()
                Label15.Text = "Selected Record " + CType(iRec + 1, String) + " Of " + CType(DataGridView1.RowCount, String) + " Row(s)."
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Public Sub ClearAll()
        Button1.Text = "Add New Item"
        txticode.ReadOnly = False
        txticode.Text = ""
        txtiname.Text = ""
        chbactive.Checked = True
        chbhold.Checked = True
        cbdiv.SelectedIndex = -1
        rbreg.Checked = True
        rbpromo.Checked = False
        txtpack.Text = "0"
        txtwght.Text = "0"
        cbuom.SelectedIndex = -1
        txtuvalue.Text = "0"
        txtoqty.Text = "0"
        cbcrncy.SelectedValue = "KD"
        cbshiptrm.SelectedIndex = -1
        txtcp.Text = "0"
        txtpp.Text = "0"
        txtcost.Text = "0"
        txtsp.Text = "0"
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select * from MASTER_DIVISION"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_DIVISION")
        cbdiv.DisplayMember = "DIV_DESC"
        cbdiv.ValueMember = "DIV_CODE"
        cbdiv.DataSource = ds.Tables("MASTER_DIVISION")

        cmd.CommandText = "Select CUR_CODE, '('+CUR_CODE+') '+CUR_DESC As CDesc from MASTER_CURRENCY"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_CURRENCY")
        cbcrncy.DisplayMember = "CDesc"
        cbcrncy.ValueMember = "CUR_CODE"
        cbcrncy.DataSource = ds.Tables("MASTER_CURRENCY")

        cmd.CommandText = "Select * from Master_Measuring_Units"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "Master_Measuring_Units")
        cbuom.DisplayMember = "MU_DESC"
        cbuom.ValueMember = "MU_CODE"
        cbuom.DataSource = ds.Tables("Master_Measuring_Units")

        cmd.CommandText = "Select * from MASTER_SHIPMENT_TERMS"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_SHIPMENT_TERMS")
        cbshiptrm.DisplayMember = "SHP_DESC"
        cbshiptrm.ValueMember = "SHP_CODE"
        cbshiptrm.DataSource = ds.Tables("MASTER_SHIPMENT_TERMS")
        cbshiptrm.DrawMode = DrawMode.OwnerDrawFixed
        AddHandler cbshiptrm.DrawItem, AddressOf CBDrawItem

        cmd.CommandText = "Select ITEM_CODE As ICode, ITEM_DESC, Cost As CostPrice, Item_Price as SellingPrice, OpeningStock As Opening, BalanceAll As BalQty from View_StockStatusLIVE Order By Item_Desc"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_StockStatusLIVE")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_StockStatusLIVE")
        DataGridView1.Columns("ICode").ReadOnly = True
        DataGridView1.Columns("BalQty").ReadOnly = True
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub CBDrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs)
        Dim myCB As ComboBox = CType(sender, ComboBox)

        Dim x, y As Integer
        x = 0
        If myCB.Tag = "" Then
            y = 0
        Else
            y = CType(myCB.Tag, Integer)
        End If
        ' Draw the default background
        e.DrawBackground()

        ' The ComboBox is bound to a DataTable,
        ' so the items are DataRowView objects.
        Dim drv As DataRowView = CType(myCB.Items(e.Index), DataRowView)

        For i As Integer = y To drv.Row.Table.Columns.Count - 1
            Dim r1 As Rectangle = e.Bounds
            If x = 0 Then
                r1.Width = r1.Width / (drv.Row.Table.Columns.Count - y)
            Else
                r1.X = e.Bounds.Width / ((drv.Row.Table.Columns.Count - y) / x)
                r1.Width = r1.Width / (drv.Row.Table.Columns.Count - y)
            End If

            ' Draw the text on the first column
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(drv(i).ToString(), e.Font, sb, r1)
            End Using

            ' Draw a line to isolate the columns 
            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using
            x = x + 1
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txticode.Text <> "" Then
            Try
                conn()
                Dim Actv, Hold, IType As String
                If chbactive.Checked = True Then
                    Actv = "T"
                Else
                    Actv = "F"
                End If
                If chbhold.Checked = True Then
                    Hold = "T"
                Else
                    Hold = "F"
                End If
                If rbreg.Checked = True Then
                    IType = "R"
                Else
                    IType = "P"
                End If
                If Button1.Text = "Add New Item" Then
                    cmd.CommandText = "Insert Into MASTER_ITEM Values ('" + txticode.Text + "', '', '" + txtiname.Text + "', '" + IType + "', '" + cbshiptrm.SelectedValue + "', '" + cbdiv.SelectedValue + "', " + txtsp.Text + ", " + txtcost.Text + ", " + txtcp.Text + ", 0, 0, '" + cbcrncy.SelectedValue + "', " + txtpp.Text + ", " + txtpack.Text + ", " + txtwght.Text + ", '" + cbuom.SelectedValue + "', " + txtuvalue.Text + ", " + txtoqty.Text + ", 0, 0, 0, 0, 0, 0, 0, 0, '" + Hold + "', '" + Actv + "', 'F', 'F')"
                    cmd.ExecuteNonQuery()
                    MsgBox("New Item Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                Else
                    cmd.CommandText = "Update MASTER_ITEM Set ITEM_DESC='" + txtiname.Text + "', ITM_TYPE='" + IType + "', ITM_TERMS='" + cbshiptrm.SelectedValue + "', DIV_CODE='" + cbdiv.SelectedValue + "', ITEM_PRICE=" + txtsp.Text + ", COST=" + txtcost.Text + ", OPNCOST=" + txtcp.Text + ", CUR_CODE='" + cbcrncy.SelectedValue + "', ITEM_FR_PRICE=" + txtpp.Text + ", PACK=" + txtpack.Text + ",WEIGHT= " + txtwght.Text + ", ITEM_AUNIT='" + cbuom.SelectedValue + "', ITEM_AUNIT_VALUE=" + txtuvalue.Text + ", ITEM_OPN_QTY=" + txtoqty.Text + ", ITEM_HOLD='" + Hold + "', ITEM_ACTIVE='" + Actv + "' Where ITEM_CODE='" + txticode.Text + "'"
                    cmd.ExecuteNonQuery()
                    MsgBox("Selected Item Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                End If
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(ITEM_OPN_QTY*COST) From MASTER_ITEM) Where GL_CODE = '200-000'"
                cmd.ExecuteNonQuery()

                ClearAll()

                If TextBox12.Text = "T" Or TextBox12.Text = "F" Then
                    cmd.CommandText = "Select ITEM_CODE As ICode, ITEM_DESC, Cost As CostPrice, Item_Price as SellingPrice, OpeningStock As Opening, BalanceAll As BalQty from View_StockStatusLIVE Where (ITEM_ACTIVE = '" + TextBox12.Text + "' OR ITEM_HOLD = '" + TextBox12.Text + "')  Order By Item_Desc"
                Else
                    cmd.CommandText = "Select ITEM_CODE As ICode, ITEM_DESC, Cost As CostPrice, Item_Price as SellingPrice, OpeningStock As Opening, BalanceAll As BalQty from View_StockStatusLIVE Where ITEM_CODE Like '%" + TextBox12.Text + "%' OR ITEM_DESC Like '%" + TextBox12.Text + "%' Order By Item_Desc "
                End If
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "View_StockStatusLIVE")
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = ds.Tables("View_StockStatusLIVE")
                DataGridView1.Columns("ICode").ReadOnly = True
                DataGridView1.Columns("BalQty").ReadOnly = True
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
        Else
            MsgBox("Enter Proper Details to Add \ Update Item.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        GridRowSelect()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn()
        For Each row As DataGridViewRow In DataGridView1.Rows
            cmd.CommandText = "Update MASTER_ITEM Set ITEM_DESC='" + row.Cells("ITEM_DESC").Value.ToString + "', ITEM_PRICE=" + row.Cells("SellingPrice").Value.ToString + ", COST=" + row.Cells("CostPrice").Value.ToString + ", ITEM_OPN_QTY=" + row.Cells("Opening").Value.ToString + " Where ITEM_CODE='" + row.Cells("ICode").Value.ToString + "'"
            cmd.ExecuteNonQuery()
        Next
        con.Close()
        AccessVerify.DGVPrinting(Label1.Text, "", True, DataGridView1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        ClearAll()

        If TextBox12.Text = "T" Or TextBox12.Text = "F" Then
            cmd.CommandText = "Select ITEM_CODE As ICode, ITEM_DESC, Cost As CostPrice, Item_Price as SellingPrice, OpeningStock As Opening, BalanceAll As BalQty from View_StockStatusLIVE Where (ITEM_ACTIVE = '" + TextBox12.Text + "' OR ITEM_HOLD = '" + TextBox12.Text + "')  Order By Item_Desc"
        Else
            cmd.CommandText = "Select ITEM_CODE As ICode, ITEM_DESC, Cost As CostPrice, Item_Price as SellingPrice, OpeningStock As Opening, BalanceAll As BalQty from View_StockStatusLIVE Where ITEM_CODE Like '%" + TextBox12.Text + "%' OR ITEM_DESC Like '%" + TextBox12.Text + "%' Order By Item_Desc "
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_StockStatusLIVE")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_StockStatusLIVE")
        DataGridView1.Columns("ICode").ReadOnly = True
        DataGridView1.Columns("BalQty").ReadOnly = True
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected Item" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub

End Class