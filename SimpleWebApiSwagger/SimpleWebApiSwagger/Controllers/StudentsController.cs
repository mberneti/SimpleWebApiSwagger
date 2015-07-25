using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleWebApiSwagger.Models;

namespace SimpleWebApiSwagger.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IList<User> _usersList = new List<User>()
        {
            new User {Fullname = "alireza esfahani",UserName = "a.esfahani",Email = "mberneti@live.com",CreatedOn = DateTime.UtcNow},
            new User {Fullname = "hasan gilak",UserName = "h.gilak",Email = "hasan.gilak@outlook.com",CreatedOn = DateTime.UtcNow},
            new User {Fullname = "saman sadeghpour",UserName = "s.sadeghpour",Email = "saman@sadeghpour.me",CreatedOn = DateTime.UtcNow},
            new User {Fullname = "mahdi salehian",UserName = "m.salehian",Email = "mahdi.salehian@hotmail.com",CreatedOn = DateTime.UtcNow},
            new User {Fullname = "elyas gilak",UserName = "e.gilak",Email = "gilak.elyas@gmail.com",CreatedOn = DateTime.UtcNow},
            new User {Fullname = "mohammadreza berneti",UserName = "mberneti",Email = "mberneti@live.com",CreatedOn = DateTime.UtcNow}

        };

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <remarks>Get an array of all Users</remarks>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult Get()
        {
            return Ok(_usersList);
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userName">Search username</param>
        /// <remarks>Get signle User by providing username</remarks>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{userName:alpha}", Name = "GetUserByUserName")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(string userName)
        {

            var User = _usersList.FirstOrDefault(s => s.UserName.Contains(userName));

            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="User">User Model</param>
        /// <remarks>Insert new User</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post(User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_usersList.Any(s => s.UserName == User.UserName))
            {
                return BadRequest("Username already exists");
            }

            _usersList.Add(User);

            string uri = Url.Link("GetUserByUserName", new { userName = User.UserName });

            return Created(uri, User);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userName">Unique username</param>
        /// <remarks>Delete existing User</remarks>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{userName:alpha}")]
        public HttpResponseMessage Delete(string userName)
        {

            var User = _usersList.FirstOrDefault(s => s.UserName == userName);

            if (User == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _usersList.Remove(User);

            return Request.CreateResponse(HttpStatusCode.NoContent);

        }

    }
}
