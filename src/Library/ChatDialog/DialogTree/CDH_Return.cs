// -----------------------------------------------------------------------
// <copyright file="CDH_Return.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso del comando de cancelar
    /// mientras se esta en uno de los pasos pertenecientes
    /// al proceso de registro de usuarios. Devuelve al
    /// usuario al menu de bienvenida.
    /// </summary>
    public class CDH_Return : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Return"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Return(ChatDialogHandlerBase next)
            : base(next, "return")
        {
            this.Route = "/volver";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity.Terminate(true);
            return null;
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Route == selector.Code)
            {
                return true;
            }

            return false;
        }
    }
}