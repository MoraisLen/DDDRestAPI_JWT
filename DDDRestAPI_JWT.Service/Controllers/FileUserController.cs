using DDDRestAPI_JWT.Application.IApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DDDRestAPI_JWT.Service.Controllers
{
    [ApiController]
    [Route("/v1/FileUser")]
    public class FileUserController : ControllerBase
    {
        private readonly IAppUser AppUser;

        public FileUserController(IAppUser _AppUser)
        {
            this.AppUser = _AppUser;
        }

        [HttpGet]
        [Route("ImportFileUser/{path}")]
        [Authorize]
        public ActionResult ImportFileUser(string path)
        {
            if (path == null)
                return BadRequest();

            try
            {
                this.AppUser.ImportUser(path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("ExportFileUser")]
        [Authorize]
        public ActionResult ExportFileUser()
        {
            try
            {
                string path = this.AppUser.ExportUser();

                return Ok(new { Path = path });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}