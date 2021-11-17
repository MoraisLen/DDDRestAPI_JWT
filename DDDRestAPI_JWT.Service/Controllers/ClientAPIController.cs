using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Repository.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;

namespace DDDRestAPI_JWT.Service.Controllers
{
    [ApiController]
    [Route("/api/v1/ClientAPI")]
    public class ClientAPIController : Controller
    {
        private readonly IAppClientAPI IClientApp;
        private readonly IConfiguration configuration;

        public ClientAPIController(IConfiguration _configuration, IAppClientAPI _IClientApp)
        {
            this.IClientApp = _IClientApp;
            this.configuration = _configuration;
        }

        [HttpPost]
        [Route("tokenGeneration")]
        [AllowAnonymous]
        public ActionResult TokenGeneration(DTOClientAPI _dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            try
            {
                ClientAPI _clientAPI = this.IClientApp.GetAuth(_dto);

                if (_clientAPI == null)
                    return NotFound();

                string key = this.configuration.GetSection("KeyJWT").ToString();
                var token = TokenService.getToken(_clientAPI, key);

                return Ok(new
                {
                    User = _dto,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetInformation")]
        [Authorize]
        public ActionResult GetInformation()
        {
            return Ok(new
            {
                NameId = User.Identity.Name,
                Role = User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value,
            });
        }

        [HttpGet]
        [Route("GetAuthAdmin")]
        [Authorize(Roles = "admin")]
        public ActionResult GetAuthAdmin() => Ok("Admin");
    }
}