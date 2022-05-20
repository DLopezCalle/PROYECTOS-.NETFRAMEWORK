<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Plantilla.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VideoClub.Formularios.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>VideoClub - Inicio</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderEnlaces" runat="server">
    <li class="nav-item"><a href="Inicio.aspx" class="nav-link active" aria-current="page">Inicio</a></li>
	<li class="nav-item"><a href="Estadisticas.aspx" class="nav-link text-white disable">Estadisticas</a></li>
	<li class="nav-item"><a href="Logout.aspx" class="nav-link text-white">Cerrar sesión</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divAlerta" class="alert alert-primary alert-dismissible fade show" role="alert">
	    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

	<asp:ListView ID="lvPeliculas" runat="server" ItemPlaceholderID="peliculaPlaceHolder" OnItemDataBound="lvPeliculas_ItemDataBound">
        <LayoutTemplate>
            <main class="album mt-5 p-3">
                <article class="container-fluid row">
                    <asp:PlaceHolder runat="server" ID="peliculaPlaceHolder"></asp:PlaceHolder>
                </article>
            </main>
        </LayoutTemplate>
        <ItemTemplate>

            <div class="col-3 my-2">
                <section class="card shadow-sm">
                    <img runat="server" ID="imgImagen" alt="Un fotograma de la pelicula">                            
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label runat="server" ID="lblTitulo" Text="Titulo..."></asp:Label></h5>
                        <p class="card-text">
                            <asp:Label runat="server" ID="lblSinopsis" Text="Sinopsis..."></asp:Label>
                        </p>
                        <a runat="server" ID="btnAlquilar" href="#" class="btn btn-primary">Alquilar</a>
                    </div>
                </section>
            </div>

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
