﻿using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SQLite;

namespace ReservaCanchas_Maui.Repositories
{
    public class CanchaRepository : ICanchaRepository
    {
        public string _dbPath;
        public string? StatusMessage { get; set; }
        
        private SQLiteConnection? conn;
        public CanchaRepository(string dbpath)
        {
            _dbPath = dbpath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Cancha>();
        }


        public void ActualizarCancha(Cancha canchaActualizada)
        {
            List<Cancha> canchas = ObtenerTodasLasCanchas();

            Cancha canchaExistente = canchas.FirstOrDefault(c => c.IdCancha == canchaActualizada.IdCancha);
            if (canchaExistente != null)
            {
                canchaExistente.NombreCancha = canchaActualizada.NombreCancha;
                canchaExistente.NumeroJugadores = canchaActualizada.NumeroJugadores;
                canchaExistente.PrecioPorHora = canchaActualizada.PrecioPorHora;
                canchaExistente.HoraApertura = canchaActualizada.HoraApertura;
                canchaExistente.HoraCierre = canchaActualizada.HoraCierre;
                canchaExistente.ImagenCancha = canchaActualizada.ImagenCancha;

                File.WriteAllText(_fileName, JsonSerializer.Serialize(canchas, new JsonSerializerOptions { WriteIndented = true }));
            }
        }


        public void CrearCancha(Cancha cancha)
        {
            List<Cancha> canchas = new List<Cancha>();
            List<Cancha> listaCanchas = ObtenerTodasLasCanchas();

            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                canchas = JsonSerializer.Deserialize<List<Cancha>>(contenido) ?? new List<Cancha>();
            }

            cancha.IdCancha = listaCanchas.Count > 0 ? listaCanchas.Max(c => c.IdCancha) + 1 : 1;
            canchas.Add(cancha);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(canchas, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void EliminarCancha(int idCancha)
        {
            try
            {
                if (File.Exists(_fileName))
                {
                    string contenidoJson = File.ReadAllText(_fileName);
                    var canchas = JsonSerializer.Deserialize<List<Cancha>>(contenidoJson) ?? new List<Cancha>();

                    var canchaAEliminar = canchas.FirstOrDefault(c => c.IdCancha == idCancha);
                    if (canchaAEliminar != null)
                    {
                        canchas.Remove(canchaAEliminar);
                        File.WriteAllText(_fileName, JsonSerializer.Serialize(canchas, new JsonSerializerOptions { WriteIndented = true }));
                    }
                    else
                    {
                        Console.WriteLine($"Cancha con ID {idCancha} no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("El archivo JSON no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en EliminarUsuario: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                throw; // Re-lanzar para propagar el error si es necesario
            }
        }

        public Cancha ObtenerCanchaPorId(int idCancha)
        {
            List<Cancha> canchas = ObtenerTodasLasCanchas();
            return canchas.FirstOrDefault(c => c.IdCancha == idCancha);
        }


        public List<Cancha> ObtenerCanchasPorComplejo()
        {
            throw new NotImplementedException();
        }

        public List<Cancha> ObtenerTodasLasCanchas()
        {
            List<Cancha> _canchas;
            if (File.Exists(_fileName))
            {
                string contenidoJson = File.ReadAllText(_fileName);
                _canchas = JsonSerializer.Deserialize<List<Cancha>>(contenidoJson) ?? new List<Cancha>();
                return _canchas;
            }
            else
            {
                return new List<Cancha>();
            }
        }
    }
}
