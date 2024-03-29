﻿<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bmlAlumnos.aspx.cs" Inherits="Vistas.bmlAlumnos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div>
        <asp:Label ID="Label2" CssClass="text-center" Style="display: block" runat="server" Font-Size="XX-Large" Text="ABML ALUMNOS"></asp:Label>
        <br />
        <asp:Label ID="lbl_res" CssClass="text-center text-success" Style="display: block" runat="server" Font-Size="X-Large"></asp:Label>
        <br />

        <div class="menu-btn">
            <asp:Button ID="btn_add" CssClass="btn btn-primary" runat="server" OnClick="btn_add_Click" Text="Añadir Alumno" />
            <asp:Button ID="btn_mod" CssClass="btn btn-primary" runat="server" OnClick="btn_mod_Click" Text="Ver/Editar/Eliminar Alumno" />
            <asp:Button ID="btn_CMasiva" CssClass="btn btn-primary" runat="server" OnClick="btn_CMasiva_Click" Text="Carga Masiva Alumnos" />
            <asp:Button ID="btn_inscribir" CssClass="btn btn-primary" runat="server" OnClick="btn_inscribir_Click" Text="Asignar Cuatrimestre" />
            <asp:Button ID="btn_edit_inscriptos" CssClass="btn btn-primary" runat="server" OnClick="btn_edit_inscriptos_Click" Text="Ver/Editar/Eliminar Inscriptos" />
        </div>
        <br />

        &nbsp;&nbsp;&nbsp;
            <asp:Panel ID="Panel1" runat="server" Visible="False" Style="width: 20%; margin: auto auto">
                <asp:Label ID="Label3" class="titulo" runat="server" Text="Añadir Alumnos"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Legajo"></asp:Label>
                <asp:TextBox ID="txtbx_legajo" CssClass="form-control" runat="server" MaxLength="15" min="0" TextMode="Number"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtbx_nombre" CssClass="form-control" runat="server" MaxLength="250"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtbx_nombre" ErrorMessage="El nombre no puede tener numeros ni simbolos" Font-Bold="True" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                <br />

                <asp:Label ID="Label6" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtbx_apellido" CssClass="form-control" runat="server" MaxLength="250"></asp:TextBox>


                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtbx_nombre" ErrorMessage="El Apellido no puede tener numeros ni simbolos" Font-Bold="True" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                <br />


                <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtbx_email" CssClass="form-control" runat="server" MaxLength="250" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Button ID="btn_add_alumno" CssClass="btn btn-success" Style="width: 100%" runat="server" OnClick="btn_add_alumno_Click" Text="Añadir Alumno" />
                <br />
            </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <h4 class="titulo text-center">Ver/Editar/Eliminar Alumnos</h4>
            <asp:GridView ID="grdAlumnos" runat="server" CssClass="table table-hover alumnos" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowDeleting="grdAlumnos_RowDeleting" OnRowUpdating="grdAlumnos_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" OnRowCancelingEdit="grdAlumnos_RowCancelingEdit" OnRowEditing="grdAlumnos_RowEditing">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Legajo">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_legajo" runat="server" Text='<%# Bind("legajo_alumnos") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("legajo_alumnos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Bind("nombre_alumnos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre_alumnos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoEdit" runat="server" Text='<%# Bind("apellido_alumnos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("apellido_alumnos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mail">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMailEdit" runat="server" Text='<%# Bind("mail_alumnos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMail" runat="server" Text='<%# Bind("mail_alumnos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:TextBox ID="ddlEstado" runat="server" Text='<%# Bind("estado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="No se han encontrado resultados"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

        &nbsp;<asp:Panel ID="Panel3" Style="width: 30%; margin: auto auto" runat="server" Visible="False">
            <h4 class="titulo text-center">Carga Masiva de Alumnos</h4>

            <p>Tutorial desde Hoja de Calculo de Google</p>
            <iframe src="https://www.youtube.com/embed/1sX9k99WJGI" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

            <asp:Label ID="Label8" runat="server" CssClass="auto-style5" Text="Seleccione un archivo:"></asp:Label>
            <asp:FileUpload ID="fExaminar" CssClass="form-control-file" runat="server" />
            <br />
            <asp:Label ID="Label28" runat="server" CssClass="auto-style5" Text="Seleccione si tiene encabezado:"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">sin encabezado</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Delimitador&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDelimitar" runat="server" MaxLength="1" Width="18px">;</asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblRuta" runat="server" CssClass="auto-style3" Width="130px"></asp:Label>
            <asp:Button ID="btnCargar" runat="server" CssClass="form-control-file btn btn-success" Style="display: block; width: 100%" OnClick="btnCargar_Click" Text="Cargar" Width="151px" />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>




        &nbsp;<asp:Panel ID="Panel4" Style="width: 25%; margin: auto auto" runat="server" Visible="False">

            <h4><strong>Asignar Cuatrimestre</strong></h4>
            <asp:Label ID="Label18" runat="server" Text="Alumno: "></asp:Label>
            <asp:DropDownList ID="ddlAlumnos" CssClass="form-control" runat="server"></asp:DropDownList>

            <asp:Label ID="Label19" runat="server" Text="Cuatrimestre: "></asp:Label>
            <asp:DropDownList ID="ddlCuatrimestre" CssClass="form-control" runat="server"></asp:DropDownList>


            <br />
            <br />
            <asp:Button ID="btn_add_inscripto" CssClass="btn btn-success" OnClick="btn_add_inscripto_Click" runat="server" Text="Aceptar" />
            <br />

        </asp:Panel>



        <asp:Panel ID="Panel5" runat="server" Visible="False">
            <h4 class="titulo text-center">Ver/Editar/Eliminar Inscriptos</h4>
            <asp:GridView ID="grdInscriptos" runat="server" CssClass="table table-hover inscriptos" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowDeleting="grdInscriptos_RowDeleting" OnRowUpdating="grdInscriptos_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" OnRowCancelingEdit="grdInscriptos_RowCancelingEdit" OnRowEditing="grdInscriptos_RowEditing">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>

                    <asp:TemplateField HeaderText="Cuatrimestre">
                        <EditItemTemplate>
                            <asp:Label ID="lblCuatriInsc1" runat="server" Text='<%# Bind("idcuatrimestre_inscriptos") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCuatriInsc2" runat="server" Text='<%# Bind("idcuatrimestre_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Legajo">
                        <EditItemTemplate>
                            <asp:Label ID="lblLegajoInsc1" runat="server" Text='<%# Bind("legajoalumno_inscriptos") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLegajoInsc2" runat="server" Text='<%# Bind("legajoalumno_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Condicion">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblCondicionInsc1" runat="server" Text='<%# Bind("condicion_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCondicionInsc2" runat="server" Text='<%# Bind("condicion_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Encuesta">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblEncuestaInsc1" runat="server" Text='<%# Bind("encuesta_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEncuestaInsc2" runat="server" Text='<%# Bind("encuesta_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Grupo">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblGrupoInsc1" TextMode="Number" min="0" runat="server" Text='<%# Bind("grupo_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGrupoInsc2" runat="server" Text='<%# Bind("grupo_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Discord">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblDiscordInsc1" runat="server" Text='<%# Bind("discord_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDiscordInsc2" runat="server" Text='<%# Bind("discord_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Documentacion">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblDocumentacionInsc1" runat="server" Text='<%# Bind("documentacion_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDocumentacionInsc2" runat="server" Text='<%# Bind("documentacion_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Proyecto">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblProyectoInsc1" runat="server" Text='<%# Bind("proyecto_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProyectoInsc2" runat="server" Text='<%# Bind("proyecto_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observaciones">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblObservacionesInsc1" runat="server" Text='<%# Bind("observaciones_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblObservacionesInsc2" runat="server" Text='<%# Bind("observaciones_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:TextBox ID="lblEstadoInsc1" runat="server" Text='<%# Bind("estado_inscriptos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEstadoInsc2" runat="server" Text='<%# Bind("estado_inscriptos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="No se han encontrado resultados"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

        <br />
        <br />
        <br />
    </div>





    <!-------------DATATABLES--------------->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/datatables.min.js"></script>

    <!--    <script type="text/javascript">
        $(document).ready(function () {
            <%-- $('#<%=grdAlumnos%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable(); --%>
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>-->

    <%if (grdAlumnos.Rows.Count > 0 && Session["editando"]==null) { %>
    <script type="text/javascript">
        $(document).ready(function () {
            // Setup - add a text input to each footer cell
            $('.alumnos thead tr')
                .clone(true)
                .addClass('filters')
                .appendTo('.alumnos thead');

            var table = $('.alumnos').DataTable({
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





    <!--si no se esta editando, y hay mas de 1 dato-->
    <%if (grdInscriptos.Rows.Count > 0 && Session["editando"]==null) { %>
    <%int s = 1; %>
    <script type="text/javascript">
        $(document).ready(function () {
            // Setup - add a text input to each footer cell
            $('.inscriptos thead tr')
                .clone(true)
                .addClass('filters')
                .appendTo('.inscriptos thead');

            var table = $('.inscriptos').DataTable({
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
