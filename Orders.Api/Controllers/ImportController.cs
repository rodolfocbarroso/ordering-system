using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.Helpers;
using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Enums;
using Orders.Domain.Handlers;
using Orders.Domain.Repositories.Contracts;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("v1/imports")]
    public class ImportController : ControllerBase
    {
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Import>>> GetAll(
            [FromServices] IImportRepository repository
        )
        {
            return Ok(await repository.GetAll());
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<Import>> GetById([FromServices] IImportRepository repository, Guid id)
        {
            return Ok(await repository.GetById(id));
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult<GenericCommandResult> Create(IFormFile file,
            [FromServices] ImportHandler handler)
        {
            var command = new CreateImportCommand { FileExtension = FileExtension.Xlsx, Items = FileHandler.Excel(file) };
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
    