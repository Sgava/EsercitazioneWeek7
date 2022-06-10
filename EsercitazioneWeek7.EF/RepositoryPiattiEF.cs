using EsercitazioneWeek7.CORE.Entities;
using EsercitazioneWeek7.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.EF
{
    public class RepositoryPiattiEF : IRepositoryPiatti
    {
        public Piatto Add(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Add(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Piatto> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p =>p.Menu).ToList();

            }
        }

        public Piatto GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p => p.Menu).FirstOrDefault(p => p.Id == id);
            }
        }

        public Piatto Update(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
