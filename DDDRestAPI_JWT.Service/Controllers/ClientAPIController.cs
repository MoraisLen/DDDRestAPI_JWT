using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Repository.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDDRestAPI_JWT.Service.Controllers
{
    [ApiController]
    [Route("/api/v1/ClientAPI")]
    public class ClientAPIController : ControllerBase
    {
        private readonly IAppClientAPI IClientApp;
        private readonly IConfiguration configuration;

        public ClientAPIController(IConfiguration _configuration, IAppClientAPI _IClientApp)
        {
            this.IClientApp = _IClientApp;
            this.configuration = _configuration;
        }

        [HttpPost]
        [Route("TokenGeneration")]
        [AllowAnonymous]
        public async Task<ActionResult> TokenAuth([FromBody] DTOClientAPI _dto)
        {
            try
            {
                ClientAPI _clientAPI = await this.IClientApp.GetAuth(_dto);

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
        [Route("InforAuth")]
        [Authorize]
        public ActionResult Information() => Ok(new
        {
            NameId = User.Identity.Name,
            Role = User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value,
        });


        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public ActionResult Add([FromBody] DTOClientAPI newClientAPI)
        {
            if (newClientAPI == null)
                return BadRequest();

            try
            {
                this.IClientApp.Add(newClientAPI);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(newClientAPI);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Get([FromRoute] int Id)
        { 
            try
            {
                ClientAPI clientApi = this.IClientApp.Get(Id);

                if (clientApi == null)
                    return NotFound();
                else
                    return Ok(clientApi);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get")]
        [Authorize(Roles = "admin")]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<ClientAPI> lstClientApi = this.IClientApp.GetAll();

                if (lstClientApi == null)
                    return NotFound();
                else
                    return Ok(lstClientApi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{Id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Update([FromRoute] int Id, [FromBody] DTOClientAPI DTOClientAPI)
        {
            ClientAPI clientApi = this.IClientApp.Get(Id);

            if (clientApi == null)
                return NotFound();

            try
            {
                clientApi.NameId = DTOClientAPI.NameId;
                clientApi.Secret = DTOClientAPI.Secret;
                clientApi.Role = DTOClientAPI.Role;

                this.IClientApp.Update(clientApi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(clientApi);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete([FromRoute] int Id)
        {
            ClientAPI clientApi = this.IClientApp.Get(Id);

            try
            {
                this.IClientApp.Remove(clientApi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}