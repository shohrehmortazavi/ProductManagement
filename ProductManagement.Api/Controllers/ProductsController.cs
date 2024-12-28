using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Application.Products.Queries;
using ProductManagement.Domain.Domains.Products;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
           
            if (result == null)
                return NotFound();         
       
            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestDto product)
        {
            var result = await _mediator.Send(new CreateProductCommand(product));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put(ProductRequestDto product)
        {
            var result = await _mediator.Send(new UpdateProductCommand(product));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}
