using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Arq.WebApi.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected async Task<ActionResult<T>> ExecuteAsync<T>(Func<Task<ActionResult<T>>> functionAsync)
        {
            try
            {
                return await functionAsync();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected async Task<ActionResult> ExecuteAsync(Func<Task<ActionResult>> functionAsync)
        {
            try
            {
                return await functionAsync();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}