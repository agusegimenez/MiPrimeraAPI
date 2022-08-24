using MiPrimeraAPI.Model;
using System.Data;
using System.Data.SqlClient;


namespace MiPrimeraAPI.Repository
{
    public static class ProductoHandler
    {
        public const string ConnectionString = "Server=XXXXXX;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Productos";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataTable tabla = new DataTable();

                    sqlDataAdapter.Fill(tabla);

                    sqlCommand.Connection.Close();

                    foreach(DataRow data in tabla.Rows)
                    {
                        Producto producto = new Producto();

                        producto.Id = Convert.ToInt32(data["Id"]);
                        producto.Descripciones = data["Descripciones"].ToString();
                        producto.Costo = Convert.ToInt32(data["Id"]);
                        producto.PrecioVenta = Convert.ToInt32(data["Id"]);
                        producto.Stock = Convert.ToInt32(data["Id"]);
                        producto.IdUsuario = Convert.ToInt32(data["Id"]);

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }
    }
}