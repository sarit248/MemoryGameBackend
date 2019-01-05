using Match_Memory_Game.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Match_Memory_Game.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class UsersApiController : ApiController
    {
        private UsersLogic logic = new UsersLogic();

        [HttpPost]
        [Route("users")]
        public HttpResponseMessage AddUser(UserModel userModel)
        {
            try
            {
                // אם הולידציה נכשלה:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                if(logic.IsUserExists(userModel))
                {
                    List<PropErrors> error = new List<PropErrors>();

                    error.Add(new PropErrors() { property = "userName or password", errors = new List<string>() { "There is existing user with that userName or password" } });
                    return Request.CreateResponse(HttpStatusCode.BadRequest, error);

                }

        
                UserModel user = logic.AddUser(userModel);
                return Request.CreateResponse(HttpStatusCode.Created, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("users/{id}")]
        public HttpResponseMessage GetOneUser(int id)
        {
            try
            {
                UserModel user = logic.GetOneUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("user")]
        public HttpResponseMessage GetUser(UserModel userModel)
        {
            try
            {
                UserModel user = logic.GetUser(userModel);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                List<UserModel> users = logic.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex); // For the Development.
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error, Please try again"); // For the Production.
                // נחזיר אובייקט אחר מאשר אובייקט החריגה, בכדי לא לחשוף Production-ב
                // מידע לגבי החריגה
            }
        }

    }
}
