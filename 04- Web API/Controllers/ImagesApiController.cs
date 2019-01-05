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
    public class ImagesApiController : ApiController
    {
        private ImagesLogic logic = new ImagesLogic();

        [HttpGet]
        [Route("images")]
        public HttpResponseMessage GetAllImages()
        {
            try
            {
                List<ImageModel> images = logic.GetAllImages();
                return Request.CreateResponse(HttpStatusCode.OK, images);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex); // For the Development.
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error, Please try again"); // For the Production.
                // נחזיר אובייקט אחר מאשר אובייקט החריגה, בכדי לא לחשוף Production-ב
                // מידע לגבי החריגה
            }
        }



        //[HttpGet]
        //[Route("images/{id}")]
        //public HttpResponseMessage GetOneImage(int id)
        //{
        //    try
        //    {
        //        ImageModel image = logic.GetOneImage(id);
        //        return Request.CreateResponse(HttpStatusCode.OK, image);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //}
    }
}



