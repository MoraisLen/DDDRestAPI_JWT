using DDDRestAPI_JWT.Application.IApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace DDDRestAPI_JWT.Service.Controllers
{
    [ApiController]
    [Route("/v1/database")]
    public class ImportController : ControllerBase
    {
        private readonly IAppUser AppUser;

        public ImportController(IAppUser _AppUser)
        {
            this.AppUser = _AppUser;
        }

        [HttpPost]
        [Route("importUser")]
        public ActionResult ImportUser(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    try
                    {
                        this.AppUser.ImportUser(reader.ReadToEnd());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }

            return Ok();
        }
    }
}