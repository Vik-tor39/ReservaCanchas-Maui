using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface ICanchaRepository
    {
        public Cancha VerCancha(int id);
        public List<Cancha> ListarCanchas();
        public bool ModificarInformacionCancha(int id, Cancha canchaActualizada);
        public bool AgregarCancha(Cancha cancha);
        public bool EliminarCancha(int id);
    }
}
