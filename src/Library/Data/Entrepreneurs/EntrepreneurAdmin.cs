using System;
using System.Collections.Generic;
using System.Collections;
using ClassLibrary;

using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Entrepreneur.
    /// </summary>
    public class EntrepreneurAdmin: DataAdmin<Entrepreneur>
    {
        /// <summary>
        /// encontramos un emprendedor por id de user 
        /// </summary>
        /// <param name="id">id de user</param>
        /// <returns></returns>
        public Entrepreneur GetByUser(int id)
        {
            ReadOnlyCollection<Entrepreneur> entrepreneurs = this.Items;
            foreach (Entrepreneur item in this.Items)
            {
                if (item.UserId== id)
                return item.Clone();


            }
            return null;
        }
    }
}
