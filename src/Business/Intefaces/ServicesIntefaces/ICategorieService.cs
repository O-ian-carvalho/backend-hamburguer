using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.ServicesIntefaces
{
    public interface ICategorieService 
    {
        Task Add(Categorie usercategorie);
        Task Update(Categorie categorie);
        Task Remove(Guid id);
    }
}
