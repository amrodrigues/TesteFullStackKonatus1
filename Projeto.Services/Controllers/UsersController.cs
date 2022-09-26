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
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private IUsersBusiness business;
    //    private object response;
        public UsersController(IUsersBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(UsersCadastroRequest request)
        {
            var response = new MensagemResponse();
            if (ModelState.IsValid)
            {
                Users s = new Users();
                s.Login = request.Login;
                s.Password = request.Password;
                s.CreatedAt = DateTime.Now;

                business.Cadastrar(s);

                response.Mensagem = $"Usuário { request.Login}, cadastrada com sucesso.";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);

                // response.Mensagem = "Ocorreram erros de Validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("excluir")]
        [HttpPost]
        public HttpResponseMessage Excluir(UsersExcluirRequest request)
        {
            var response = new MensagemResponse();
            if (ModelState.IsValid)
            {
                try
                {
                    Users s = business.ConsultarPorId(request.Id);
                    business.Excluir(s);

                    response.Mensagem = $"Usuário { request.Id}, excluído com sucesso.";
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

            List<UsersConsultaRequest> lista = new List<UsersConsultaRequest>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Users s in business.ConsultarTodos())
                {
                    UsersConsultaRequest model = new UsersConsultaRequest();
                    model.Id = s.Id;
                    model.Login = s.Login;
                    model.Password = s.Password;
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
