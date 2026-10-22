using MediatR;
using Microsoft.AspNetCore.Mvc;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Queries;
using StargateAPI.Business.Data;
using System.Net;

namespace StargateAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AstronautDutyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AstronautDutyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get")]
        public async Task<IActionResult> GetAstronautDutiesByName([FromBody] string name)
        {
            try
            {
                var result = await _mediator.Send(new GetAstronautDutiesByName()
                {
                    Name = name
                });

                return this.GetResponse(result);
            }
            catch(BadHttpRequestException ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.BadRequest
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.BadRequest
                });
            }
            catch (Exception ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.InternalServerError
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAstronautDuty([FromBody] AstronautDuty request)
        {
            try
            {
                var result = await _mediator.Send(new CreateAstronautDuty()
                {
                    Name = request.Person?.Name ?? string.Empty,
                    Rank = request.Rank,
                    DutyTitle = request.DutyTitle,
                    DutyStartDate = request.DutyStartDate
                });
                return this.GetResponse(result);         
            }
            catch(BadHttpRequestException ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.BadRequest
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.BadRequest
                });
            }
            catch (Exception ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.InternalServerError
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.InternalServerError
                });
            }      
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAstronautDuty([FromBody] AstronautDuty request)
        {
            try
            {
                var result = await _mediator.Send(new UpdateAstronautDuty()
                {
                    Name = request.Person?.Name ?? string.Empty,
                    Rank = request.Rank,
                    DutyTitle = request.DutyTitle,
                    DutyStartDate = request.DutyStartDate,
                    DutyEndDate = request.DutyEndDate
                });
                return this.GetResponse(result);         
            }
            catch(BadHttpRequestException ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.BadRequest
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.BadRequest
                });
            }
            catch (Exception ex)
            {
                await _mediator.Send(new CreateLogMessage()
                {
                    Message = ex.Message,
                    IsError = true,
                    ErrorCode = (int)HttpStatusCode.InternalServerError
                });
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.InternalServerError
                });
            }      
        }
    }
}