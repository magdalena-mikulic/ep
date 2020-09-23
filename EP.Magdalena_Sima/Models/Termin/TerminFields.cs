using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EP.Magdalena_Sima.Models.Termin
{
    public class TerminFields
    {
        public bool APP_MANDATORY { get; set; }
        public bool CASAWAY { get; set; }
        public bool WHOLEDAY { get; set; }
        public double DURATION { get; set; }

        [DisplayName("Početak termina")] public DateTime END_DT { get; set; }

        public DateTime END_DT_ORIG { get; set; }
        public bool EXCLUSION_EVENT { get; set; }
        public int FOREIGNEDITPERMISSION { get; set; }

        [Key] public string GGUID { get; set; }

        public int GWAPPOINTMENTTYPE { get; set; }

        [DisplayName("Odrađeno ?")] public bool GWDURATIONMANUAL { get; set; }

        public bool GWISINFINITEPERIODICEVENT { get; set; }
        public DateTime INSERTTIMESTAMP { get; set; }
        public string INSERTUSER { get; set; }
        public bool IS_INTEND_TIME { get; set; }
        public bool ISPARTOFEVENT { get; set; }

        [DisplayName("Klijent")] public string KEYWORD { get; set; }

        public string OWNERGUID { get; set; }
        public string OWNERNAME { get; set; }
        public bool PERCONFLICTFR { get; set; }
        public bool PERCONFLICTHO { get; set; }
        public bool PERCONFLICTMO { get; set; }
        public int PERCONFLICTS { get; set; }
        public bool PERCONFLICTSA { get; set; }
        public bool PERCONFLICTSU { get; set; }
        public bool PERCONFLICTTH { get; set; }
        public bool PERCONFLICTTU { get; set; }
        public bool PERCONFLICTWE { get; set; }
        public int DAYOFMONTH { get; set; }
        public bool PEREDITABLE { get; set; }
        public bool PERIODALARMSET { get; set; }
        public bool PERIODSCHEMEEVERY { get; set; }
        public bool PERMONTHFIRST { get; set; }
        public bool PERMONTHFOURTH { get; set; }
        public bool PERMONTHLAST { get; set; }
        public bool PERMONTHSECOND { get; set; }
        public bool PERMONTHTHIRD { get; set; }
        public bool PERWEEKANYDAY { get; set; }
        public bool PERWEEKDAY { get; set; }
        public bool PERWEEKFR { get; set; }
        public bool PERWEEKMO { get; set; }
        public bool PERWEEKSA { get; set; }
        public bool PERWEEKSU { get; set; }
        public bool PERWEEKTH { get; set; }
        public bool PERWEEKTU { get; set; }
        public bool PERWEEKWE { get; set; }
        public bool PERWEEKWEEKENDDAY { get; set; }
        public bool PERWEEKWORKDAY { get; set; }
        public bool SINGLE_MODIFIED { get; set; }

        [DisplayName("Kraj termina")] public DateTime START_DT { get; set; }

        public DateTime START_DT_ORIG { get; set; }
        public DateTime UPDATETIMESTAMP { get; set; }
        public string UPDATEUSER { get; set; }
    }
}
