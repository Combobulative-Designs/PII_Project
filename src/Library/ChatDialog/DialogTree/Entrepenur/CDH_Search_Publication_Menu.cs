using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDHSearch_Publication_Menu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearch_Publication_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearch_Publication_Menu(ChatDialogHandlerBase next) : base(next, "Search_Publication_Menu")
        {
            this.parents.Add("welcome_entrepreneur");
            this.route = "\\buscarpublicacion";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu para buscar una publicación\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\palabraclave : Buscar publicación por palabra clave.\n");
            builder.Append("\\localidad : Buscar por localidad.\n");
            builder.Append("\\cartegoria : Buscar por categoria.\n");

            return builder.ToString();
        }
    }
}