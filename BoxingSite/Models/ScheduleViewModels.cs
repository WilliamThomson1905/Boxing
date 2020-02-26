using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxingSite.Models
{
    public class ClassAndScheduleViewmodel
    {
        public int BoxingClassID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Foriegn key - Boxer will do class
        public string BoxerID { get; set; }
        // Corresponding navigation property 
        public virtual BoxerUser Boxer { get; set; }


        // Navigation property - BoxingClass can have one or more instances of 'Schedule' 
        public virtual ICollection<Schedule> Schedule { get; set; }

    }

    public class ScheduleListsViewmodel
    {
        public List<Schedule> Monday { get; set; }
        public List<Schedule> Tuesday { get; set; }
        public List<Schedule> Wednesday { get; set; }
        public List<Schedule> Thursday { get; set; }
        public List<Schedule> Friday { get; set; }
        public List<Schedule> Saturday { get; set; }
        public List<Schedule> Sunday { get; set; }

    }





}
