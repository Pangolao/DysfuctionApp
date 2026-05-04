using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysfunction.Model
{
    public class asignatureModel
    {
        private string period;
        private string code;
        private string asignature;
        private string teacher;
        private string group;
        private bool approved;

        public asignatureModel(string period, string code, string asignature, string teacher, string group, bool finalScore )
        {
            this.period = period;
            this.code = code;
            this.asignature = asignature;
            this.teacher = teacher;
            this.group = group;
            this.approved = finalScore;
        }

        public string Period { get => period; set => period = value; }
        public string Code { get => code; set => code = value; }
        public string Asignature { get => asignature; set => asignature = value; }
        public string Teacher { get => teacher; set => teacher = value; }
        public string Group { get => group; set => group = value; }
        public bool Approved { get => approved; set => approved = value; }
    }
}
