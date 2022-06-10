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
    public class RepositoryMenuEF : IRepositoryMenu
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Piatti).ToList();

            }
        }

        public Menu GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Piatti).FirstOrDefault(c => c.CorsoCodice == codice);
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
