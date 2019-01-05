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
    public class MessagesApiController : ApiController
    {
        private MessagesLogic logic = new MessagesLogic();

        [HttpGet]
        [Route("messages")]
        public HttpResponseMessage GetAllMessages()
        {
            try
            {
                List<MessageModel> messages = logic.GetAllMessages();
                return Request.CreateResponse(HttpStatusCode.OK, messages);
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
        [Route("messages/{id}")]
        public HttpResponseMessage GetOneMessage(int id)
        {
            try
            {
                MessageModel message = logic.GetOneMessage(id);
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("messages")]
        public HttpResponseMessage AddMessage(MessageModel messageModel)
        {
            try
            {
                // אם הולידציה נכשלה:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                MessageModel message = logic.AddMessage(messageModel);
                return Request.CreateResponse(HttpStatusCode.Created, message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
