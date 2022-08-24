using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Model;
using MiPrimeraAPI.Repository;

namespace MiPrimeraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        } 
    }
}