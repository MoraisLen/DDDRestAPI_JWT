using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DDDRestAPI_JWT.Service.Controllers
{
    [ApiController]
    [Route("/api/v1/ClientAPI")]
    public class ClientAPIController : Controller
    {
        private readonly IAppClientAPI IClientApp;

        public ClientAPIController(IAppClientAPI _IClientApp)
        {
            this.IClientApp = _IClientApp;
        }

        [HttpPost]
        [Route("tokenGeneration")]
        public ActionResult TokenGeneration(DTOClientAPI _dto)
        {
            try
            {
                this.IClientApp.Add(_dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}