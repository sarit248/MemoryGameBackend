using Match_Memory_Game.helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Match_Memory_Game
{
    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class UsersFeedbackApiController : ApiController
    {
        private UsersFeedbackLogic logic = new UsersFeedbackLogic();

        [HttpGet]
        [Route("usersFeedback")]
        public HttpResponseMessage GetAllFeedbacks()
        {
            try
            {
                List<UserFeedbackModel> usersFeedback = logic.GetAllFeedbacks();
                return Request.CreateResponse(HttpStatusCode.OK, usersFeedback);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex); // For the Development.
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error, Please try again"); // For the Production.
                // נחזיר אובייקט אחר מאשר אובייקט החריגה, בכדי לא לחשוף Production-ב
                // מידע לגבי החריגה
            }
        }

        [HttpGet]
        [Route("usersFeedback/{id}")]
        public HttpResponseMessage GetOneFeedback(int id)
        {
            try
            {
                UserFeedbackModel userFeedback = logic.GetOneFeedback(id);
                return Request.CreateResponse(HttpStatusCode.OK, userFeedback);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("usersFeedback")]
        public HttpResponseMessage AddFeedback(UserFeedbackModel userFeedbackModel)
        {
            try
            {
                // אם הולידציה נכשלה:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                UserFeedbackModel userFeedback = logic.AddFeedback(userFeedbackModel);
                return Request.CreateResponse(HttpStatusCode.Created, userFeedback);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
