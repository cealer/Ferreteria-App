using Application.Commands.InventoryCommands;
using Application.Commands.ProductCommands;
using Application.Extensions;
using Application.Queries.ProductsQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductQueries _productQueries;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductQueries productQueries, ILogger<ProductsController> logger)
        {
            _productQueries = productQueries ?? throw new ArgumentNullException(nameof(productQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetByAsync()
        {
            try
            {
                var products = await _productQueries.GetAllAsync();

                return Ok(products);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetByFilterAsync(string filter)
        {
            try
            {
                var products = await _productQueries.GetByFilterAsync(filter);

                return Ok(products);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateProductAsync([FromBody] CreateProductCommand createCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                createCommand.GetGenericTypeName(),
                nameof(createCommand.Code),
                createCommand.Code,
                createCommand);

            var result = await Mediator.Send(createCommand);
            if (result)
            {
                return Ok();
            }
            return StatusCode(500, new { error = "Product can't be created." });
        }

        [HttpPost("AddQuantity")]
        public async Task<ActionResult<bool>> AddInventaryAsync([FromBody] AddQuantityInventoryCommand addQuantityInventoryCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                addQuantityInventoryCommand.GetGenericTypeName(),
                nameof(addQuantityInventoryCommand.ProductId),
                addQuantityInventoryCommand.ProductId,
                addQuantityInventoryCommand);

            var result = await Mediator.Send(addQuantityInventoryCommand);
            if (result)
            {
                return Ok();
            }
            return StatusCode(500, new { error = "Product can't be created." });
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductAsync([FromBody] EditProductCommand editCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                editCommand.GetGenericTypeName(),
                nameof(editCommand.Code),
                editCommand.Code,
                editCommand);

            var result = await Mediator.Send(editCommand);
            if (result)
            {
                return Ok();
            }
            return StatusCode(500, new { error = "Product can't be updated." });
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> DeleteProductAsync(Guid productId)
        {
            DeleteProductCommand deleteCommand = new DeleteProductCommand(productId);
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                deleteCommand.GetGenericTypeName(),
                nameof(deleteCommand.ProductId),
                deleteCommand.ProductId,
                deleteCommand);

            var result = await Mediator.Send(deleteCommand);
            if (result)
            {
                return Ok();
            }
            return StatusCode(500, new { error = "Product can't be updated." });
        }

    }
}
