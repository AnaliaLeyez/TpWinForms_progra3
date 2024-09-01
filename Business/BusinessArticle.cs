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
                data.setQuery("select Id,Codigo , Nombre, Descripcion, Precio from ARTICULOS");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Price = (decimal)data.Reader["Precio"];

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
    }
}
    
