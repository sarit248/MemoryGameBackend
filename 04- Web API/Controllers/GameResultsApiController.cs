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
    public class GameResultsApiController : ApiController
    {
        private GameResultsLogic logic = new GameResultsLogic();

        [HttpGet]
        [Route("gameResults")]
        public HttpResponseMessage GetAllResults()
        {
            try
            {
                List<GameResultModel> gameResults = logic.GetAllResults();
                return Request.CreateResponse(HttpStatusCode.OK, gameResults);
            }
            catch (Exception ex)
            {

                //צריך לשנות את השגיאה לerror,[please try again]
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex); // For the Development.
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error, Please try again"); // For the Production.
                // נחזיר אובייקט אחר מאשר אובייקט החריגה, בכדי לא לחשוף Production-ב
                // מידע לגבי החריגה
            }
        }

        [HttpGet]
        [Route("gameResults/{id}")]
        public HttpResponseMessage GetOneGameResult(int id)
        {
            try
            {
                GameResultModel gameResult = logic.GetOneGameResult(id);
                return Request.CreateResponse(HttpStatusCode.OK, gameResult);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("gameResults")]
        public HttpResponseMessage AddGameResult(GameResultModel gameResultModel)
        {
            try
            {
                // אם הולידציה נכשלה:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
                }

                GameResultModel gameResult = logic.AddGameResult(gameResultModel);
                return Request.CreateResponse(HttpStatusCode.Created, gameResult);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
