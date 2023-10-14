using Notificacao;

namespace ExcelAutomation.Layouts
{
    public static class LayoutNotificacao
    {
        public static void AbrirAlerta(Color backColor, Color linhaAlertaColor, string titulo, string texto, Image icone)
        {
            Alertas alerta = new Alertas();
            alerta.BackColor = backColor;
            alerta.ColorLinhaAlerta = linhaAlertaColor;
            alerta.TituloAlerta = titulo;
            alerta.TextoAlerta = texto;
            alerta.IconeAlerta = icone;
            alerta.Show();
        }
        
    }
}
