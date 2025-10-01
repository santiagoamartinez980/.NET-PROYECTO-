using BackEndAPI.Models.Componentes;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IComponentes
    {
        Task<List<Procesador>> GetProcesadores();

        // Placas base compatibles con el procesador
        Task<List<PlacaBase>> GetPlacasCompatibles(int procesadorId);

        // Memorias compatibles con la placa base
        Task<List<MemoriaRAM>> GetMemoriasCompatibles(int placaBaseId);

        // Tarjetas gráficas (aquí puedes filtrar si depende de la placa base o no)
        Task<List<TarjetaGrafica>> GetTarjetasCompatibles(int placaBaseId);

        // Almacenamientos compatibles con la placa base
        Task<List<Almacenamiento>> GetAlmacenamientosCompatibles(int placaBaseId);

        // Fuente de poder según el consumo acumulado del ensamblaje
        Task<List<FuentePoder>> GetFuentesCompatibles(int ensamblajeId);


    }
}
