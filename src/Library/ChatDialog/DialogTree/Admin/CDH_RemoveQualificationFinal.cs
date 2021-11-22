using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHRemoveQualificationFinal : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHRemoveQualificationFinal"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHRemoveQualificationFinal(ChatDialogHandlerBase next) : base(next, "hab_remove_final")
        {
            this.parents.Add("hab_remove_confirmar");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if(EraseQualification(selector))
            {
                builder.Append("Los datos se eliminaron correctamente.\n");
            }
            else
            {
                builder.Append("Los datos no se pudieron eliminar .\n");

            }
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        
        private bool EraseQualification(ChatDialogSelector selector)
        {
            bool xretorno=false;
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertQualificationData data = process.GetData<InsertQualificationData>();
            Qualification qualification=data.Qualification;
            if(IsNotAllReadyToDelete(data)==false)
            {
                this.datMgr.Qualification.Delete(qualification.Id);
                xretorno=true;
            }
            return xretorno;

        }
        private bool IsNotAllReadyToDelete(InsertQualificationData data)
        {
            bool xretorno=false;
            foreach(CompanyMaterialQualification xMatQuali in this.datMgr.CompanyMaterialQualification.Items)
            {
                if(xMatQuali.QualificationId==data.Qualification.Id)
                {
                    xretorno=true;
                }
            }
            if(xretorno==true)
            {
                foreach(EntrepreneurQualification xEntreQualification in this.datMgr.EntrepreneurQualification.Items)
                {
                    if(xEntreQualification.QualificationId==data.Qualification.Id)
                    {
                        xretorno=true;
                    }
                }
            }
            return xretorno;
        }
    }
}