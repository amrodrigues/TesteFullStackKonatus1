using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.Models.Request;
using Projeto.Services.Models.Response;
using Projeto.Business.Contracts;
using Projeto.Entities;
using System.Web.Http.ModelBinding;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/Stage")]
    public class StageController : ApiController
    {
        private IStageBusiness business;
      //  private object response;
        public StageController(IStageBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(StageCadastroRequest request)
        {
            var response = new MensagemResponse();
            if (ModelState.IsValid)
            {
                Stage s = new Stage();
                s.Description = request.Description;
                s.MaintenanceId = request.MaintenanceId;
                s.Status = request.Status;
                s.Type = request.Type;
                s.Value = request.Value;
                s.CreatedAt = DateTime.Now;

                business.Cadastrar(s);

                response.Mensagem = $"Etapa { request.MaintenanceId}, cadastrada com sucesso.";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);

                //    response.Mensagem = "Ocorreram erros de Validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("excluir")]
        [HttpPost]
        public HttpResponseMessage Excluir(StageExcluirRequest request)
        {
            var response = new MensagemResponse();
            if (ModelState.IsValid)
            {
                try
                {
                    Stage s = business.ConsultarPorId(request.Id);
                    business.Excluir(s);

                    response.Mensagem = $"Etapa { request.Id}, excluído com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {

                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }


            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);

                // response.Mensagem = "Ocorreram erros de Validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {      //declarando uma lista..
            var response = new MensagemResponse();

            List<StageConsultaRequest> lista = new List<StageConsultaRequest>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Stage s in business.ConsultarTodos())
                {
                    StageConsultaRequest model = new StageConsultaRequest();
                    model.Id = s.Id;
                    model.MaintenanceId = s.MaintenanceId;
                    model.Status = s.Status;
                    model.Type = s.Type;
                    model.Value = s.Value;
                    model.Description = s.Description;
                    model.CreatedAt = s.CreatedAt;
                    
                    lista.Add(model); //adicionando..

                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

            //return Request.CreateResponse(HttpStatusCode.BadRequest, lista);

        }

        private string ObterMensagensDeValidacao(ModelStateDictionary model)
        {
            List<string> erros = new List<string>();
            foreach (var m in model)
            {
                if (m.Value.Errors.Count > 0)
                {
                    erros.Add(m.Value.Errors.Select

                    (s => s.ErrorMessage).FirstOrDefault());

                }
            }
            return string.Join(",", erros);
        }
    }
}
