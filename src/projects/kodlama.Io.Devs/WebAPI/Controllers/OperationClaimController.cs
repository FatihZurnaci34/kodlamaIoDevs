using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            OperationClaimGetByIdDto operationClaimGetByIdDto = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(operationClaimGetByIdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreateOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdateOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeleteOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result);
        } 
    }
}
