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
    [RoutePrefix("api/Maintenance")]
    public class MaintenanceController : ApiController
    {
        private IMaintenanceBusiness business;
    //    private object response;
        public MaintenanceController(IMaintenanceBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(MaintenanceCadastroRequest request)
        {
            var response = new MensagemResponse();
            if(ModelState.IsValid)
            {
                Maintenance m = new Maintenance();
         
                m.Status = request.Status;
                m.UserId = request.UserId;
                m.Description = request.Description;
                m.CreatedAt = DateTime.Now;
                business.Cadastrar(m);

                response.Mensagem = $"Manutenção { request.Description}, cadastrada com sucesso.";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);

                //response.Mensagem = "Ocorreram erros de Validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("excluir")]
        [HttpPost]
        public HttpResponseMessage Excluir(MaintenanceExcluirRequest request)
        {
            var response = new MensagemResponse();
            if (ModelState.IsValid)
            {
                try
                {
                    Maintenance m = business.ConsultarPorId(request.Id);
                    business.Excluir(m);

                    response.Mensagem = $"Manutenção { request.Id}, excluída com sucesso.";
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

            List<MaintenanceConsultaRequest> lista = new List<MaintenanceConsultaRequest>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Maintenance m in business.ConsultarTodos())
                {
                    MaintenanceConsultaRequest model = new MaintenanceConsultaRequest();
                    model.Id = m.Id;
                    model.Status = m.Status;
                    model.CreatedAt = m.CreatedAt;
                    model.Description = m.Description;
                    model.UserId = m.UserId;
                    
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
