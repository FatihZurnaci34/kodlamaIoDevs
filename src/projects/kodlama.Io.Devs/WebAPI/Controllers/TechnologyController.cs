using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TechnologyController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreateTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdateTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnology)
        {
            DeleteTechnologyDto result = await Mediator.Send(deleteTechnology);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListTechnologyByDynamicQuery = new GetListTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            TechnologyListModel result = await Mediator.Send(getListTechnologyByDynamicQuery);
            return Ok(result);

        }
    }
}
