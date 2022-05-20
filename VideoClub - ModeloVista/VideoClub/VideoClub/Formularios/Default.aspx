<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VideoClub.Formularios.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../Fonts/all.min.css">
    <script src="../Fonts/all.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <title>VideoClub - LogIn</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div runat="server" id="divAlerta" class="alert alert-primary alert-dismissible fade show" role="alert">
	            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <section class="d-flex align-items-center my-5" style="height: 85vh">
              <div class="container-fluid h-custom">
                <div class="row d-flex justify-content-center text-black align-items-center h-100">
                  <div class="d-flex fs-1 align-items-center col-md-9 col-lg-6 col-xl-5">
                    <i runat="server" id="icono" class="fa-brands fa-bilibili ms-4 me-4 fa-10x"></i>
                    <div class="fs-1">VideoClub Online</div>
                  </div>
                  <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                      <h1>Inicio de sesión</h1>

                      <!-- Usuario -->
                      <div class="form-outline mb-4">
                        <input runat="server" id="inputUser" type="text" class="form-control form-control-lg" placeholder="Introduzca su nombre de usuario" />
                        <label class="form-label" for="form3Example3">Usuario</label>
                      </div>

                      <!-- Contraseña -->
                      <div class="form-outline mb-3">
                        <input runat="server" id="inputPass" type="password" class="form-control form-control-lg" placeholder="Introduzca su contraseña" />
                        <label class="form-label" for="form3Example4">Contraseña</label>
                      </div>
                        
                      <!-- Boton -->
                      <div class="text-center text-lg-start mt-4 pt-2">
                        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary p-2 fs-5" Text="Iniciar sesión" OnClick="btnLogin_Click" />
                        <p class="small fw-bold mt-2 pt-1 mb-0">

                            ¿No estás registrado?
                            <a href="Registro.aspx" class="link-danger">Regístrate</a>

                        </p>
                      </div>

                  </div>
                </div>
              </div>
            </section>
        </div>
    </form>
</body>
</html>
