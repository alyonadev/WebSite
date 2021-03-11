using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DialogRepository : IDialogRepository
    {
        private readonly WebSiteContext _context;

        public DialogRepository(WebSiteContext context)
        {
            _context = context;
        }

        public void Add(Dialog item)
        {
            _context.Dialogs.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Dialog dialog = _context.Dialogs.Find(id);

            _context.Dialogs.Remove(dialog);
            _context.SaveChanges();
        }

        public IEnumerable<Dialog> GetAll()
        {
            return _context.Dialogs.ToList();
        }

        public Dialog GetById(int id)
        {
            return _context.Dialogs.Find(id);
        }

        public void Update(Dialog dialog)
        {
            _context.Entry(dialog).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
