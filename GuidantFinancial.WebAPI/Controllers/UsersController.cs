using GuidantFinancial.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuidantFinancial.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private UserRepository _userRepository;
        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        [Route("")]
        [HttpGet]
        public User[] Get()
        {
            return _userRepository.GetAll().ToArray();
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                if (user != null)
                {
                    if (_userRepository.IsExisted(user.Name))
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Name is already existed");
                    if (_userRepository.Add(user))
                        return Request.CreateResponse(HttpStatusCode.Created, user.Id);
                }
            }
            catch (Exception ex)
            {
                //TODO: log excepsiton message
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some thing went wrong!");
        }


        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            try
            {
                var user = _userRepository.Get(id);
                if (user != null)
                {
                    return Request.CreateResponse<User>(HttpStatusCode.OK, user);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User is not existed!");
                }

            }
            catch (Exception ex)
            {              
                //TODO: log excepsiton message
            }
            
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some thing went wrong!"); ;
        }

        [Route("setPoints")]
        [HttpPost]
        public HttpResponseMessage GetUser([FromBody]User user)
        {
            try
            {
                if (user != null)
                {
                    if (_userRepository.Update(user))
                        return Request.CreateResponse(HttpStatusCode.OK, "User was updated");
                }
            }
            catch (Exception ex)
            {
                //TODO: log excepsiton message
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some thing went wrong!");
        }
    }
}

