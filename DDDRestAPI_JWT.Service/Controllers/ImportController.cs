using DDDRestAPI_JWT.Application.IApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        [HttpGet]
        [Route ("teste")]
        public ActionResult teste (string valorPost)
        {

            List<IEnumerable<string>> olaK = new List<IEnumerable<string>> ();

            string[] ola = { "dfsgdfsg", "fdsgfd", "sdfsdfsdf", "fdsfsdfsf", "ola"};

            var ok = ola.Select((s, i) => ola.Skip(i * 2).Take(2)).Where(a => a.Any()).ToList();

            foreach (var x in ok)
            {
                if (x.Count() >= 2)
                {
                    olaK.Add(x);
                }
            }

            return Ok(olaK);
        }
    }
}