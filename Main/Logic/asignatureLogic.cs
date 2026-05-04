using Dysfunction.Data;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dysfunction.Logic
{
    public class asignatureLogic
    {
        asignatureData asignatureData = new asignatureData();
        projectLogic projectLogic = new projectLogic();
        periodData periodData = new periodData();
        public void NewObject(asignatureModel objectAsignatureModel)
        {
            asignatureData.AddNew(objectAsignatureModel);
        }
        public void EditObject(asignatureModel objectAsignatureModel)
        {
            asignatureData.Edit(objectAsignatureModel);
        }
        public void DeleteObject(asignatureModel objectAsignatureModel)
        {
            asignatureData.Delete(objectAsignatureModel);
        }
        public List<asignatureModel> Consult()
        {
            List<asignatureModel> asignatureModels = asignatureData.ConsultBD();
            asignatureModels.Reverse();

            return asignatureModels;

        }
        public bool ValidAsignatureInPeriod(string code)
        {
            List<periodModel> periodModels = periodData.ConsultBD();

            foreach (var period in periodModels)
            {
                if (period?.Asignatures != null && period.Asignatures.Contains(code)) 
                {
                    return true;
                }
            }

            return false;
        }

        public string ObtainCode(string asignature)
        {
            List<asignatureModel> asignatureModels = Consult();

            foreach (var model in asignatureModels)
            {
                if (model != null && model.Asignature == asignature)
                {
                    return model.Code;
                }
            }
            return null;
        }

        public string ObtainName(string code)
        {
            List<asignatureModel> asignatureModels = Consult();

            foreach (var model in asignatureModels)
            {
                if (model != null && model.Code == code)
                {
                    return model.Asignature;
                }
            }
            return null;
        }
        public void UpdateFinalScore(string code, string period, int year)
        {

            float totalRealValue = 0;
            bool yes = false;

            List<projectModel> projectModels = projectLogic.Consult();

            var filteredProjects = projectModels.Where(p => p.Period == period && p.Code == code && p.Year == year).ToList();

            foreach (var project in filteredProjects)
            {
                totalRealValue = projectLogic.MakeItReal(project.Score, project.Value, 10) + totalRealValue;
            }

            List<asignatureModel> asignatureModels = Consult();


            var asignatureToUpdate = asignatureModels.FirstOrDefault(a => a.Code == code);

            if (asignatureToUpdate != null)
            {
                if (totalRealValue > 6.74)
                {
                    yes = true;
                }
                asignatureToUpdate.Approved = yes;

                asignatureData.Edit(asignatureToUpdate);


            }
        }
        public float ObtainFinalScore(string code, string period, int year)
        {
            float totalRealValue = 0;

            List<projectModel> projectModels = projectLogic.Consult();

            var filteredProjects = projectModels.Where(p => p.Period == period && p.Code == code && p.Year == year).ToList();

            foreach (var project in filteredProjects)
            {
                totalRealValue = projectLogic.MakeItReal(project.Score, project.Value, 10) + totalRealValue;
            }
            return totalRealValue;
        }

        public bool ValidNotNull(string p)
        {
            if (string.IsNullOrEmpty(p)) return false;

            return true;
        }
        public bool ValidUniqueCode(string p)
        {
            List<asignatureModel> asignatures = Consult();

            foreach (var model in asignatures)
            {
                if (model != null)
                {
                    if (p == model.Code)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool ValidUniqueName(string p)
        {
            List<asignatureModel> asignatures = Consult();

            foreach (var model in asignatures)
            {
                if (model != null)
                {
                    if (p == model.Asignature)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
