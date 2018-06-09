using Models.Requests;
using Models.Responses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class HighSchoolTypeAheadController : ApiController
    {
        readonly IHighSchoolTypeAheadService highSchooltypeAheadService;

        public HighSchoolTypeAheadController(IHighSchoolTypeAheadService highSchooltypeAheadService)
        {
            this.highSchooltypeAheadService = highSchooltypeAheadService;
        }

        [Route("api/highschools/search"), HttpPost]
        public HttpResponseMessage GetByName(HighSchoolTypeAheadRequestName model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "You did not send any body data!");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            List<HighSchoolTypeAheadRequest> highSchoolTypeAhead = highSchooltypeAheadService.GetByName(model);

            ItemsResponse<HighSchoolTypeAheadRequest> itemsResponse = new ItemsResponse<HighSchoolTypeAheadRequest>();
            itemsResponse.Items = highSchoolTypeAhead;

            return Request.CreateResponse(HttpStatusCode.OK, itemsResponse);
        }
    }
}
