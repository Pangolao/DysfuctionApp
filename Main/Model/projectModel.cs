using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysfunction.Model
{
    public class projectModel : asignatureModel
    {
        private int year;
        private string project;
        private float value;
        private float score;
        private DateTime limitDate;

        public projectModel(int year,string period, string code, string project, float value, float score, DateTime limitDate ) : base( period, code, default(string), default(string), default(string), default(bool))
        {
            this.project = project;
            this.value = value;
            this.score = score;
            this.limitDate = limitDate;
            this.year = year;
        }

        public string Project { get => project; set => project = value; }
        public float Value { get => value; set => this.value = value; }
        public float Score { get => score; set => score = value; }
        public DateTime LimitDate { get => limitDate; set => limitDate = value; }
        public int Year { get => year; set => year = value; }
    }
}
