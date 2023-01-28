using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            ProgramingLanguageGetByIdDto programingLanguageGetByIdDto = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(programingLanguageGetByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreateProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdateProgramingLanguageDto updateProgramingLanguageDto = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(updateProgramingLanguageDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeleteProgramingLanguageDto deleteProgramingLanguageDto = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(deleteProgramingLanguageDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest= pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }
    }
}
