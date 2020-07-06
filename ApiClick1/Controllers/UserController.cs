using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
namespace ApiClick1.Controllers
{
    [RoutePrefix("api/users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody]DTO.DtoUser user)
       
        {

            if (UsersBLL.Register(user))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("login/{usercode}/{password}")]
        public IHttpActionResult Login([FromUri]string usercode, [FromUri]string password)
      
        {
            DtoUser user = UsersBLL.Login(usercode, password);
            if ( user!=null)
                return Ok(user);
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpDelete]
        public IHttpActionResult DeletePlayer([FromUri]int userId)

        {
           
            if (UsersBLL.DeletePlayer(userId))
                return Ok();
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpGet]
        [Route("getNameUser/{id}")]
        
        public IHttpActionResult getNameUser([FromUri]int id)

        {
            string fullName = UsersBLL.getNameUser(id);
            if (fullName != null)
                return Ok(fullName);
            else
                return BadRequest();//אולי להחזיר null
        }
    }

}
