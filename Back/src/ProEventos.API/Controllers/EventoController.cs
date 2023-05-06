﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento [] {
            new Evento () {
                EventoId = 1,
                Tema  = "angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1° Lote",
                QtdPessoas =  250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.png",

              },
               new Evento () {
                EventoId = 2,
                Tema  = "angular e suas novidades",
                Local = "São Paulo",
                Lote = "2° Lote",
                QtdPessoas =  350,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy"),
                ImagemURL = "foto1.png",

              }
        };
        public EventoController()
        {   

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
          return _evento.Where(evento => evento.EventoId == id );
        }

        [HttpPost]
        public string Post()
        {
          return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string HttpPut(int id)
        {
          return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Deelete(int id)
        {
          return $"Exemplo de delete com id = {id}";
        }
    }
}