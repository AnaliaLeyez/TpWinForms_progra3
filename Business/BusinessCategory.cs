using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessCategory
    {

        public List<Category> list()
        {
            List<Category> list = new List<Category>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("select Id,Descripcion from CATEGORIAS");
                data.executeRead();


                while (data.Reader.Read())
                {
                    Category aux = new Category();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Description = (string)data.Reader["Descripcion"];

                    list.Add(aux);
                }
                return list;
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
