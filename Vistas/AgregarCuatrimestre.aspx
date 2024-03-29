﻿<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarCuatrimestre.aspx.cs" Inherits="Vistas.AgregarCuatrimestre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label2" CssClass="text-center" Style="display: block" runat="server" Font-Size="XX-Large" Text="ALTA BAJA Y MODIFICACION DE CUATRIMESTRES"></asp:Label>
        <br />
        <asp:Label ID="lbl_res" CssClass="text-center text-success" Style="display: block" runat="server" Font-Size="X-Large"></asp:Label>
        <br />
        <br />


        <div class="menu-btn">
            <asp:Button ID="btn_add" CssClass="btn btn-primary" runat="server" OnClick="btn_add_Click" Text="Añadir Cuatrimestre" />
            <asp:Button ID="btn_mod" CssClass="btn btn-primary" runat="server" OnClick="btn_mod_Click" Text="Ver/Editar/Eliminar Cuatrimestre" />

        </div>
        <br />
        &nbsp;&nbsp;&nbsp;
            <asp:Panel ID="Panel1" runat="server" Visible="False" class="container">
                <asp:Label ID="Label3" class="titulo" runat="server" Text="Añadir cuatrimestre"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Año"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtAnio" CssClass="form-control" runat="server" MaxLength="250" TextMode="Number"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAnio" ErrorMessage="solo numeros positivos" Font-Bold="True" ForeColor="#CC0000" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <br />

                <asp:Label ID="Label6" runat="server" Text="Numero"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" MaxLength="250" TextMode="Number"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNumero" ErrorMessage="solo numeros positivos" Font-Bold="True" ForeColor="#CC0000" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <br />
                <asp:Button ID="btnAgregarCuatri" CssClass="btn btn-success" runat="server" OnClick="btnAgregarCuatri_Click" Text="Añadir cuatrimestre" />
                <br />
            </asp:Panel>


        <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <h4 class="titulo text-center">Ver/Editar/Eliminar Cuatrimestres</h4>
            <asp:GridView ID="grdCuatrimestre" CssClass="table table-hover" runat="server" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowDeleting="grdCuatrimestre_RowDeleting" OnRowUpdating="grdCuatrimestre_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" OnRowCancelingEdit="grdCuatrimestre_RowCancelingEdit" OnRowEditing="grdCuatrimestre_RowEditing">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("id_cuatrimestres") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("id_cuatrimestres") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescEdit" runat="server" Text='<%# Bind("descripcion_cuatrimestres") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("descripcion_cuatrimestres") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Año">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAnioEdit" TextMode="Number" min="0" runat="server" Text='<%# Bind("año_cuatrimestres") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("año_cuatrimestres") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Numero">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNumEdit" TextMode="Number" min="0" runat="server" Text='<%# Bind("cuatrimestre_cuatrimestres") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNum" runat="server" Text='<%# Bind("cuatrimestre_cuatrimestres") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="No se han encontrado resultados"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="Gray" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Gray" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>
        <br />
        &nbsp;&nbsp;&nbsp;
            <br />

    </div>

    
    <!-------------DATATABLES--------------->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/datatables.min.js"></script>


        
    <%if (grdCuatrimestre.Rows.Count > 0) { %>
    <script type="text/javascript">
        $(document).ready(function () {
            // Setup - add a text input to each footer cell
            $('.table thead tr')
                .clone(true)
                .addClass('filters')
                .appendTo('.table thead');

            var table = $('.table').DataTable({
                orderCellsTop: true,
                fixedHeader: true,
                initComplete: function () {
                    var api = this.api();

                    // For each column
                    api
                        .columns()
                        .eq(0)
                        .each(function (colIdx) {
                            // Set the header cell to contain the input element
                            var cell = $('.filters th').eq(
                                $(api.column(colIdx).header()).index()
                            );
                            var title = $(cell).text();
                            $(cell).html('<input type="text" placeholder="' + title + '" />');

                            // On every keypress in this input
                            $(
                                'input',
                                $('.filters th').eq($(api.column(colIdx).header()).index())
                            )
                                .off('keyup change')
                                .on('change', function (e) {
                                    // Get the search value
                                    $(this).attr('title', $(this).val());
                                    var regexr = '({search})'; //$(this).parents('th').find('select').val();

                                    var cursorPosition = this.selectionStart;
                                    // Search the column for that value
                                    api
                                        .column(colIdx)
                                        .search(
                                            this.value != ''
                                                ? regexr.replace('{search}', '(((' + this.value + ')))')
                                                : '',
                                            this.value != '',
                                            this.value == ''
                                        )
                                        .draw();
                                })
                                .on('keyup', function (e) {
                                    e.stopPropagation();

                                    $(this).trigger('change');
                                    $(this)
                                        .focus()[0]
                                        .setSelectionRange(cursorPosition, cursorPosition);
                                });
                        });
                },
            });
        });
    </script>
    <%} %>



</asp:Content>




