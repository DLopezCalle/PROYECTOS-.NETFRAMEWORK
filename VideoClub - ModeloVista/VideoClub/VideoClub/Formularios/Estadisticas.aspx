<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Plantilla.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="VideoClub.Formularios.Estadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>VideoClub - Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderEnlaces" runat="server">
    <li class="nav-item"><a href="Inicio.aspx" class="nav-link text-white">Inicio</a></li>
	<li class="nav-item"><a href="Estadisticas.aspx" class="nav-link active" aria-current="page">Estadisticas</a></li>
	<li class="nav-item"><a href="Logout.aspx" class="nav-link text-white">Cerrar sesión</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div runat="server" id="divAlerta" class="alert alert-danger alert-dismissible fade show" role="alert">
	    Está página está en obras. Si crees que es un error, comunicate con el desarrollador encargado.
    </div>

	<main class="container-fluid mt-5 row">
			<article class="col">
				<h2>Película alquilada más veces</h2>
                <div class="col-12 my-2 my-5">
					<section class="card shadow-sm">
						<img runat="server" ID="imgImagen1" src="https://loremflickr.com/640/360/1" alt="imagen1">                            
						<div class="card-body">
							<h5 class="card-title"><asp:Label runat="server" ID="lblTitulo1" Text="Titulo..."></asp:Label></h5>
							<p class="card-text">
								<asp:Label runat="server" ID="lblSinopsis1" Text="Sinopsis..."></asp:Label>
							</p>
							<a runat="server" ID="btnAlquilar1" href="#" class="btn btn-primary">Alquilar</a>
						</div>
					</section>
				</div>
			</article>
			<article class="col">
				<h2>Película menos alquilada</h2>
				<div class="col-12 my-2 my-5">
					<section class="card shadow-sm">
						<img runat="server" ID="imgImagen2" src="https://loremflickr.com/640/360/2" alt="imagen1">                            
						<div class="card-body">
							<h5 class="card-title"><asp:Label runat="server" ID="lblTitulo2" Text="Titulo..."></asp:Label></h5>
							<p class="card-text">
								<asp:Label runat="server" ID="lblSinopsis2" Text="Sinopsis..."></asp:Label>
							</p>
							<a runat="server" ID="btnAlquilar2" href="#" class="btn btn-primary">Alquilar</a>
						</div>
					</section>
				</div>
			</article>
		</main>
</asp:Content>
