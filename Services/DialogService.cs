using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DialogService : IDialogService
    {
        private readonly IDialogRepository _dialogRepository;

        public DialogService()
        {
            _dialogRepository = new DialogRepository(new WebSiteContext());
        }

        public void AddDialogService(Dialog item)
        {
            _dialogRepository.Add(item);
        }

        public void DeleteDialogService(int id)
        {
            _dialogRepository.Delete(id);
        }

        public List<Dialog> GetAllDialogsService()
        {
            IEnumerable<Dialog> dialogList = _dialogRepository.GetAll();

            return dialogList.ToList();
        }

        public Dialog GetDialogService(int id)
        {
            return _dialogRepository.GetById(id);
        }

        public Dialog GetDialogService(int from, int to)
        {
            var dialog = _dialogRepository.GetAll()
                .FirstOrDefault(d => 
                (d.From == from && d.To == to) ||
                (d.From == to && d.To == from));

            return dialog;
        }

        public void UpdateDialogService(Dialog item)
        {
            _dialogRepository.Update(item);
        }
    }
}
