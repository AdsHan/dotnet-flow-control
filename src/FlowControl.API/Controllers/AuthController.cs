using FlowControl.API.Application.OptionFluentResult;
using FlowControl.API.Application.OptionFluentResult.Errors;
using FlowControl.API.Application.OptionManual;
using FlowControl.API.Application.OptionOneOf;
using FlowControl.API.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FlowControl.API.Controllers;

[Produces("application/json")]
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

    // POST api/auth
    /// <summary>
    /// Manual
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     USU: adshan@gmail.com SEN: 123456 (Este registro é criado automaticamente)
    ///         
    ///     POST Login
    ///     
    ///     {
    ///         "email": "adshan@gmail.com",
    ///         "password": "123456"    
    ///     }
    ///     
    ///
    /// </remarks>        
    /// <returns>Token de autenticação</returns>                
    /// <response code="200">Foi realizado o login corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost("manual")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInManualAsync([FromBody] AccessCredentialsDTO credentials, [FromServices] AuthManualService _authManualService)
    {
        var result = await _authManualService.ValidateCredentialsAsync(credentials);

        if (!result.IsValid()) return ValidationProblem(statusCode: (int)HttpStatusCode.BadRequest, title: result.GetErrorsMessages());

        return Ok();
    }

    // POST api/auth
    /// <summary>
    /// Exception
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     USU: adshan@gmail.com SEN: 123456 (Este registro é criado automaticamente)
    ///         
    ///     POST Login
    ///     
    ///     {
    ///         "email": "adshan@gmail.com",
    ///         "password": "123456"    
    ///     }
    ///     
    ///
    /// </remarks>        
    /// <returns>Token de autenticação</returns>                
    /// <response code="200">Foi realizado o login corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost("exception")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInExceptionAsync([FromBody] AccessCredentialsDTO credentials, [FromServices] AuthExceptionService _authExceptionService)
    {
        await _authExceptionService.ValidateCredentialsAsync(credentials);

        return Ok();
    }

    // POST api/auth
    /// <summary>
    /// OneOf
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     USU: adshan@gmail.com SEN: 123456 (Este registro é criado automaticamente)
    ///         
    ///     POST Login
    ///     
    ///     {
    ///         "email": "adshan@gmail.com",
    ///         "password": "123456"    
    ///     }
    ///     
    ///
    /// </remarks>        
    /// <returns>Token de autenticação</returns>                
    /// <response code="200">Foi realizado o login corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost("oneof")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInOneOfAsync([FromBody] AccessCredentialsDTO credentials, [FromServices] AuthOneOfService _authOneOfService)
    {
        var result = await _authOneOfService.ValidateCredentialsAsync(credentials);

        return result.Match(
                user => Ok(),
                error => ValidationProblem(statusCode: (int)error.StatusCode, title: error.ErroMessage));
    }

    // POST api/auth
    /// <summary>
    /// FluentResult
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     USU: adshan@gmail.com SEN: 123456 (Este registro é criado automaticamente)
    ///         
    ///     POST Login
    ///     
    ///     {
    ///         "email": "adshan@gmail.com",
    ///         "password": "123456"    
    ///     }
    ///     
    ///
    /// </remarks>        
    /// <returns>Token de autenticação</returns>                
    /// <response code="200">Foi realizado o login corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost("fluentresult")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInFluentResultAsync([FromBody] AccessCredentialsDTO credentials, [FromServices] AuthFluentResultService _authFluentResultService)
    {
        var result = await _authFluentResultService.ValidateCredentialsAsync(credentials);

        if (result.IsSuccess) return Ok();

        var error = result.Errors[0];

        if (error is UserNameNotFoundFluentError)
        {
            return ValidationProblem(statusCode: (int)HttpStatusCode.BadRequest, title: "Este usuário não existe!");
        }
        else if (error is CredentialsInvalidFluentError)
        {
            return ValidationProblem(statusCode: (int)HttpStatusCode.BadRequest, title: "Usuário ou Senha incorretos!");
        }
        else
        {
            return ValidationProblem(statusCode: (int)HttpStatusCode.BadRequest, title: "Usuário temporariamente bloqueado por tentativas inválidas!");
        }

    }

    // POST api/auth
    /// <summary>
    /// ErrorOr
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     USU: adshan@gmail.com SEN: 123456 (Este registro é criado automaticamente)
    ///         
    ///     POST Login
    ///     
    ///     {
    ///         "email": "adshan@gmail.com",
    ///         "password": "123456"    
    ///     }
    ///     
    ///
    /// </remarks>        
    /// <returns>Token de autenticação</returns>                
    /// <response code="200">Foi realizado o login corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost("erroror")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInErrorOrAsync([FromBody] AccessCredentialsDTO credentials, [FromServices] AuthErrorOrService _authErrorOrService)
    {
        var result = await _authErrorOrService.ValidateCredentialsAsync(credentials);

        return result.MatchFirst(
            user => Ok(),
            error => ValidationProblem(statusCode: (int)HttpStatusCode.BadRequest, title: error.Description));

    }


}

