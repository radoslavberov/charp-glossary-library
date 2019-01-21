using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlossaryClassLibrary.Core;
using GlossaryClassLibrary.Core.Exeptions;
using NLog;

namespace GlossaryREST.Controllers
{
    public class GlossaryController : ApiController
    {
        private ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet]
        [Route("api/glossary")]
        public HttpResponseMessage GetTerm([FromUri] string term)
        {
            var glossary = InMemoryGlossaryProvider.Get();

            var possibleTerm = glossary.Find(term);

            if (possibleTerm.HasValue)
            {
                return Request.CreateResponse(HttpStatusCode.OK, possibleTerm.Value);
            }else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("api/glossary")]
        public HttpResponseMessage Get([FromBody] RegisterTermRequest request)
        {
            var glossary = InMemoryGlossaryProvider.Get();

            try
            {
                var registeredTerm = glossary.Register(request);

                return Request.CreateResponse(HttpStatusCode.Created, registeredTerm);
            }
            catch(ArgumentNullException e)
            {
                logger.Error(e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch(TermAlreadyRegisteredException e)
            {
                logger.Error(e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("api/glossary/{name}")]
        public HttpResponseMessage UpdateTerm(string name, [FromBody] UpdateTermRequest request)
        {
            var glossary = InMemoryGlossaryProvider.Get();

            try
            {
                var updatedTerm = glossary.Update(name, request);

                return Request.CreateResponse(HttpStatusCode.Created, updatedTerm);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("api/glossary/all")]
        public HttpResponseMessage GetAll()
        {
            var glossary = InMemoryGlossaryProvider.Get();
            return Request.CreateResponse(HttpStatusCode.OK, glossary.GetTerms());
        }

        [HttpGet]
        [Route("api/glossary/count")]
        public HttpResponseMessage GetCount()
        {
            var glossary = InMemoryGlossaryProvider.Get();
            return Request.CreateResponse(HttpStatusCode.OK, glossary.GetCount());
        }
    }
}
