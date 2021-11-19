// -----------------------------------------------------------------------
// <copyright file="CDH_SessionExpired.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// no registrado en la plataforma.
    /// </summary>
    public class CDH_SessionExpired : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SessionExpired"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SessionExpired"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SessionExpired(ChatDialogHandlerBase next)
            : base(next, "session_expired_alert")
        {
            this.Parents.Add("session_expired");
            this.Route = "/resetsession";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            session.MenuLocation = null;
            session.ClearActivitiesStack();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Su sesion ha caducado.");
            builder.Append("Volviendo al inicio.");
            return builder.ToString();
        }
    }
}