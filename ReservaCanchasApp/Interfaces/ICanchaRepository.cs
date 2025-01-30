﻿using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Interfaces
{
    public interface ICanchaRepository
    {
        public Cancha ObtenerCanchaPorId(int idCancha);
        public List<Cancha> ObtenerTodasLasCanchas();
        public bool CrearCancha(Cancha cancha);
        public bool ActualizarCancha(Cancha cancha);
        public bool EliminarCancha(int idCancha); 
    }
}
