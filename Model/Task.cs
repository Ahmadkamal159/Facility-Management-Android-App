using Facility_Management_App.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = Facility_Management_App.Enums.TaskStatus;

namespace Facility_Management_App.Models
{
    public class Task
    {
        #region Entity Properties
        public int Id { get; set; }
        public TaskType Type { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public double? Cost { get; set; }
        public DateTime? FixingTime { get; set; }
        #endregion

        #region Link with other

        [Required]
        public int CreatedById { get; set; }//we made this for the modelbuilder to select it 
        public AppUser CreatedBy { get; set; }//onDelete: ReferentialAction.SetDefault);//we made this (space must migration)//try modelBuilder in AplicationDBContext ClientCascade
        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
        public int? AssignedToId { get; set; }//new//need to be tested in api to make sure it add in the list
        public AppUser AssignedTo { get; set; }
        public int? AssignedById { get; set; }//new//need to be tested in api to make sure it add in the list
        public AppUser AssignedBy { get; set; }
        #endregion
    }
}
