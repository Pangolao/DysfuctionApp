using Dysfunction.Data;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysfunction.Logic
{
    public class eventsLogic
    {
        eventsData eventsData = new eventsData();
        public void NewObject(string id, string name, string description, DateTime startDate, DateTime? endDate, TimeSpan? hour)
        {
            eventsModel objectEventsModel = new eventsModel(id, name, description, startDate, endDate, hour);

            eventsData.AddNew(objectEventsModel);
        }
        public List<eventsModel> Consult()
        {
            List<eventsModel> eventModels = eventsData.ConsultBD();
            eventModels.Reverse();
            return eventModels;

        }
        public void EditObject(eventsModel objectEventsModel)
        {
            eventsData.Edit(objectEventsModel);
        }
        public void DeleteObject(eventsModel objectEventsModel) 
        {
            eventsData.Delete(objectEventsModel);
        }

        public bool ValidNotNull(string p)
        {
            if (string.IsNullOrEmpty(p)) return false;

            return true;
        }

        public bool ValidUniqueEvent(string p, DateTime startDate)
        {
            List<eventsModel> events = Consult();

            foreach (var model in events)
            {
                if (model != null)
                {
                    if (p == model.Name && startDate == model.StartDate)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string MakeAnID()
        {
            List<eventsModel> events = Consult();

            int lastId = 0;

            foreach (var model in events)
            {
                if (model != null && int.TryParse(model.Id, out int currentId))
                {
                    if (currentId > lastId)
                    {
                        lastId = currentId;
                    }
                }
            }
            int newId = lastId + 1;
            return newId.ToString();
        }
    }
}
