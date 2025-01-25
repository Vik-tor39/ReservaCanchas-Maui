using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface IComplejoRepository
    {
        public Complejo VerComplejo(int id);
        public List<Complejo> ListarComplejos();
        public bool ModificarInformacionComplejo(int id, Complejo complejoActualizado);
        public bool AgregarComplejo(Complejo complejo);
        public bool EliminarComplejo(int id);
    }
}
