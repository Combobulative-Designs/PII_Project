// -----------------------------------------------------------------------
// <copyright file="InsertCompanyMaterialData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertCompanyMaterialData : SearchData
    {
        private CompanyMaterial companyMaterial;
        private MaterialCategory materialCategory;
        private DataManager DatMgr;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertCompanyMaterialData"/>.
        /// </summary>
        /// <param name="searchResults">
        /// Resultados de busqueda.
        /// </param>
        /// <param name="searchPageContext">
        /// Contexto de la busqueda.
        /// </param>
        /// <param name="searchPageRoute">
        /// Ruta de la busqueda.
        /// </param>
        /// <param name="pageItemCount">
        /// Items por pagina de resultados.
        /// </param>
        public InsertCompanyMaterialData(IReadOnlyCollection<int> searchResults, string searchPageContext, string searchPageRoute, int pageItemCount = 6)
            : base(searchResults, searchPageContext, searchPageRoute, pageItemCount)
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial; set => this.companyMaterial = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public MaterialCategory MaterialCategory { get => this.materialCategory; set => this.materialCategory = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public override bool RunTask()
        {
            bool xretonro = false;
            CompanyMaterial companyMaterial = this.CompanyMaterial;
            int idCompanyMatId = this.DatMgr.CompanyMaterial.Insert(companyMaterial);
            if (idCompanyMatId != 0)
            {
                xretonro = true;
            }

            return xretonro;
        }
    }
}