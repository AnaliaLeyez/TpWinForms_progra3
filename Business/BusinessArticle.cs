using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Business
{
    public class BusinessArticle
    {
        public List<Article> list()
        {
            List<Article> articleList = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("select A.Id, A.Codigo , A.Nombre, A.Descripcion, A.Precio, I.ImagenUrl from ARTICULOS A, IMAGENES I where I.Id = A.Id");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Price = (decimal)data.Reader["Precio"];

                    string urlImage = (string)data.Reader["ImagenUrl"];
                    aux.UrlImage = new List<string>();
                    aux.UrlImage.Add(urlImage);

                    articleList.Add(aux);
                }

                return articleList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void AddArticle(Article article)
        {
            DataAccess data = new DataAccess();
            
        }
    }
}
    
