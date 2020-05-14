using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class PasajeroService
    {
        private readonly TravellContext _context;

        public PasajeroService(TravellContext context)
        {
            _context = context;
        }

        public GuardarPasajeroResponse Guardar(Pasajero pasajero){
            try{
                var pasajeroBuscado = _context.Pasajeros.Find(pasajero.Identificacion);
                if(pasajeroBuscado != null){
                    return new GuardarPasajeroResponse("Error el cultivo ya se encuentra registrado");
                }
                _context.Pasajeros.Add(pasajero);
                _context.SaveChanges();
                return new GuardarPasajeroResponse(pasajero);
            }catch(Exception e){ 
                return new GuardarPasajeroResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public Pasajero BuscarXIdentificacion(int identificacion){  
            Pasajero pasajero = _context.Pasajeros.Find(identificacion);
            return pasajero;
        }

        public List<Pasajero> ConsultarTodos(){  
            List<Pasajero> pasajeros = _context.Pasajeros.Include(x => x.Tiquetes).ToList();
            return pasajeros;
        }
    }

    public class GuardarPasajeroResponse 
    {
        public GuardarPasajeroResponse(Pasajero pasajero1)
        {
            Error = false;
            pasajero = pasajero1;
        }
        public GuardarPasajeroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Pasajero pasajero { get; set; }
    }
}