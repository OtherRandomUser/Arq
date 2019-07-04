using System.Threading.Tasks;
using Arq.WebApi.InputModels;
using Arq.WebApi.Security;
using Arq.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arq.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokensController : ApiControllerBase
    {
        private TokenService _tokenService;

        public TokensController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Generates a jwt token
        /// </summary>
        /// <param name="inputModel">Input model of the token</param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult<TokenViewModel>> PostAsync([FromBody] TokenInputModel inputModel)
            => ExecuteAsync<TokenViewModel>(async () =>
            {
                if (inputModel == null)
                    return BadRequest();

                return Ok(await _tokenService.GenerateTokenAsync(inputModel.Username, inputModel.Password));
            });

        [HttpGet]
        [Authorize]
        public Task<ActionResult> AuthenticateAsync()
            => Task.FromResult((ActionResult) Ok());
    }
}