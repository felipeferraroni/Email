<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppEnvio.Default" %>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <title>Felipe AppEnvio</title>
    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/Custom.css" />

</head>
<body>
    <div class="navbar navbar-light bg-faded navbar-static-top mb-1">
    </div>


    <div class="container">
        <div class="jumbotron">
            <h1>Felipe Ferraroni de Melo</h1>
            <p class="lead">
                App Easy para <strong>envio</strong> de curriculos. Não existe segredo no desenvolvimento a unica coisa
                a esconder e a senha do E-mail.
            </p>
        </div>
        <div Visible="False" role="alert" id="DivAlert" name="DivAlert" runat="server">
            <i runat="server" id="alertText" name="alertText"></i>
            <button type="button" class="close" data-dismiss="alert"  aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
        <div class="row">
            <div class="col-xs-9 col-sm-7">
                <form runat="server" method="post">
                    <div class="form-group">
                        <label for="emailDestinatario"><i class="fa fa-address-card"></i>E-mail da empresa</label>
                        <input type="email" runat="server" name="emailDestinatario" class="form-control" id="emailDestinatario" maxlength="100" aria-describedby="emailInfo" placeholder="E-mail do Contratante" required="Preencha o e-mail"/>
                        <small id="emailInfo" class="form-text text-muted">E-mail de contato da empresa.</small>
                    </div>
                    <div class="form-group">
                        <label for="assuntoDestinatario"><i class="fa fa-commenting"></i>Assunto do e-mail</label>
                        <input type="text" runat="server" name="assuntoDestinatario" class="form-control" id="assuntoDestinatario" maxlength="50" aria-describedby="assuntoInfo" placeholder="E-mail do Contratante" required="Preencha o assunto"/>
                        <small id="assuntoInfo" class="form-text text-muted">Informar assunto o código do da vaga.</small>
                    </div>
                    <div class="form-group">
                        <label for="corpoEmail"><i class="fa fa-file-text-o"></i>Corpo do E-mail</label>
                        <textarea class="form-control" runat="server" name="corpoEmail" id="corpoEmail" placeholder="Corpo do E-mail" rows="6"></textarea>
                    </div>
                    <div class="form-inline">
                        <button type="submit" runat="server" name="btnEnviar" class="btn btn-primary" onserverclick="Enviar"><i class="fa fa-send"></i>Enviar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <footer class="footer">
        <div class="container">
            <span class="text-muted">Desenvolvidor por Felipe Ferraroni.</span>
        </div>
    </footer>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>

