using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
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

        [HttpPost]
        [Route("ImportFileUser")]
        [Authorize]
        public ActionResult ImportFileUser([FromBody] DTOFileUser file)
        {
            if (file.Path == null)
                return BadRequest();

            try
            {
                this.AppUser.ImportUser(file.Path);
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