using BackEndAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IConsultaComponentes
    {
        
        Task<Componente?> GetComponentePorId(int id);
        Task<List<Componente>> BuscarComponentes(string nombre);

        Task<List<Componente>> GetComponentesPorTipo(string tipo);
        Task<List<Componente>> BuscarPorMarca(string marca);
    }
}
