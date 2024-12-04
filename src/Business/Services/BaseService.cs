using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models;
using Hamurgueria.Business.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Services
{
    public abstract class BaseService 
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

        //protected void Notificar(ValidationResult validationResult)
        //{
        //    foreach (var item in validationResult.Errors)
        //    {
        //        Notificar(item.ErrorMessage);
        //    }

        //}

        //protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        //{

        //    var validator = validacao.Validate(entidade);

        //    if (validator.IsValid) return true;

        //    Notificar(validator);

        //    return false;
        //}
    }
}
