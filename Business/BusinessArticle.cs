using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
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
                data.setQuery("select A.Id, A.Codigo , A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, M.Descripcion Brand, C.Descripcion Category from ARTICULOS A, IMAGENES I, MARCAS M, CATEGORIAS C where (I.Id = A.Id and M.Id = A.Id and C.Id = A.Id)");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Code = (string)data.Reader["Codigo"];
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    aux.Brand = new Brand();
                    aux.Brand.Id = (int)data.Reader["IdMarca"];
                    aux.Brand.Description = (string)data.Reader["Brand"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategoria"];
                    aux.Category.Description = (string)data.Reader["Category"];
                    aux.Price = (decimal)data.Reader["Precio"];

                    string urlImage = (string)data.Reader["ImagenUrl"];
                    aux.UrlImage = new List<string>
                    {
                        urlImage
                    };

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
            try
            {
                data.setQuery("insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values(@Code, @Name, @Description, @idBrand , @idCategory, @Price)");
               // data.setQuery("insert into IMAGENES(Id, IdArticulo, ImagenUrl) values(1, @Code, @urlImage)");
                
                data.setParameter("@Code", article.Code);
                data.setParameter("@Name", article.Name);
                data.setParameter("@Description", article.Description);
                data.setParameter("@idBrand", article.Brand.Id);
                data.setParameter("@idCategory", article.Category.Id);
               // data.setParameter("@urlImage" , article.UrlImage);
                data.setParameter("@Price", article.Price);
                data.executeAction();
                
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

        public void modifyArticle(Article article)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("update ARTICULOS set Codigo=@Code, Nombre=@Name, Descripcion=@Description, IdMarca=@idBrand, IdCategoria=@idCategory, Precio=@Price where Id=@Id");
                data.setParameter("@Code", article.Code);
                data.setParameter("@Name", article.Name);
                data.setParameter("@Description", article.Description);
                data.setParameter("@idBrand", article.Brand.Id);
                data.setParameter("@idCategory", article.Category.Id);
                //data.setParameter("@urlImage" , article.UrlImage);
                data.setParameter("@Price", article.Price);
                data.setParameter("@Id", article.Id);

                data.executeAction();

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
    
