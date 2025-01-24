using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface ICanchaRepository
    {
        public Task<Cancha> VerCancha(int id);
        public Task<List<Cancha>> ListarCanchas();
        public Task<bool> ModificarInformacionCancha(int id);
        public Task<bool> AgregarCancha();
        public Task<bool> EliminarCancha(int id);
    }
}
