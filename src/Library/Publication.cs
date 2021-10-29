using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase creada para crear una publicación y publicar los materiales para vender.
    /// </summary>
    public class Publication : IManagableData<Publication>
    {

        /// <summary>
        /// Lista de palabras clave para encontrar facilmente publicaciones.
        /// </summary>
        public List<string> KeyWords = new List<string>();


        /// <summary>
        /// Property de la clase PublicationItem.
        /// </summary>
        public PublicationItem PublicationItem {get; set;}

        /// <summary>
        /// Publication tiene una property de Company.
        /// </summary>
        public Company Company{get; set;}


        /// <summary>
        /// Id que se la da a cada publicación.
        /// </summary>
        public  int Id{get; set;}

        /// <summary>
        /// DateTime con la fecha de activación.
        /// </summary>
        public DateTime ActiveFrom{get; set;}

        /// <summary>
        /// Datetime con la fecha de desactivación de la publicación.
        /// </summary>
        public DateTime ActiveUntill{get; set;}

        /// <summary>
        /// Precio de lo que se vende en la publicación, ya sea un material o varios.
        /// </summary>
        public int Price{get; set;}

        /// <summary>
        /// Divisa del precio del material o materiales.
        /// </summary>
        public Currency Currency{get; set;}


        /// <summary>
        ///  Deleted sirve para saber si la publicación se borra o no.
        /// </summary>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor de la publicación para definir los atributos.
        /// </summary>
        /// <param name="ActiveFrom"></param>
        /// <param name="ActiveUntill"></param>
        /// <param name="Price"></param>
        /// <param name="Currency"></param>
        /// <param name="Deleted"></param>
        [JsonConstructor]
        public Publication(DateTime ActiveFrom, DateTime ActiveUntill, int Price, Currency Currency, bool Deleted)
        {
            this.ActiveFrom = ActiveFrom;
            this.ActiveUntill = ActiveUntill;
            this.Price = Price;
            this.Currency = Currency;
            this.Deleted = false;
        }

        /// <summary>
        /// Constructor vacio para PublicationAdmin.
        /// </summary>
        public Publication()
        {

        }

        

        /// <summary>
        /// Metodo para añadir una palabra clave del tipo string a la lista de palabras claves.
        /// </summary>
        /// <param name="KeyWord">Ingreso palabra clave.</param>
        public void AddKeyWord(string KeyWord)
        {
            if (!KeyWords.Contains(KeyWord))
            {
                KeyWords.Add(KeyWord);
            }

        }


        /// <summary>
        /// Metodo para remover palabra clave de la lista de palabras claves del tipo string.
        /// </summary>
        /// <param name="KeyWord">Ingreso palabra clave que quiero remover.</param>
        public void RemoveKeyWord(string KeyWord)
        {
            if (KeyWords.Contains(KeyWord))
            {
                KeyWords.Remove(KeyWord);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            Publication publication=JsonSerializer.Deserialize<Publication>(json);
            this.Id=publication.Id;
            this.ActiveFrom=publication.ActiveFrom;
            this.ActiveUntill=publication.ActiveUntill;
            this.Deleted=publication.Deleted;
            this.Currency=publication.Currency;
            this.Price=publication.Price;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Publication Clone()
        {
            Publication publication =new Publication();
            publication.LoadFromJson(this.ConvertToJson());
            return publication;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    

}