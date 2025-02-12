﻿using EsercitazioneWeek7.CORE.Entities;
using EsercitazioneWeek7.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.EF
{
    public class RepositoryUtentiEF : IRepositoryUtenti
    {
        public Utente Add(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Utente item)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Username == username);
            }
        }

        public Utente Update(Utente item)
        {
            throw new NotImplementedException();
        }
    }
}
