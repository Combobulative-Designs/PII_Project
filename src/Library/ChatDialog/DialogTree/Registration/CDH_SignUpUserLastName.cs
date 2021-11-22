using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del primer nombre
    /// del usuario y continua pidiendole el apellido.
    /// </summary>
    public class CDHSignUpUserLastName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpUserLastName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpUserLastName(ChatDialogHandlerBase next) : base(next, "registration_user_l_name")
        {
            this.parents.Add("registration_user_f_name");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SignUpData data = process.GetData<SignUpData>();

            User user = this.datMgr.User.New();
            user.FirstName = selector.Code.Trim();
            data.User = user;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese su <b>primer apellido</b>");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}