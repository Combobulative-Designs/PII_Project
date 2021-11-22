using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la confirmación de la ´publicación.
    /// </summary>
    public class CDHConfirmation_Sale_Category : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHConfirmation_Sale_Category"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHConfirmation_Sale_Category(ChatDialogHandlerBase next) : base(next, "Confirmation_Sale_Category")
        {
            this.parents.Add("Sale_Publication_Category");
            this.route = "\\comprar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process=session.Process;
            SearchPublication data=process.GetData<SearchPublication>();
            
            builder.Append($"Quieres confirmar la compra de una publicación de Id - {data.Publication.Id} \n");
            builder.Append("\\confirmar : Confirma la compra la publicación\n");
            builder.Append("\\cancelar : Cancelar la compra\n");
            return builder.ToString();
        }
    }
}