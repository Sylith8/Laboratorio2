using System.Collections.Generic;
using PetCare.Models;

namespace PetCare.Data
{
    public class MascotaRepository
    {
        private static List<Mascota> _mascotas = new List<Mascota>();

        public void AgregarMascota(Mascota mascota)
        {
            _mascotas.Add(mascota);
        }

        public List<Mascota> ObtenerMascotas()
        {
            return _mascotas;
        }
    }
}
