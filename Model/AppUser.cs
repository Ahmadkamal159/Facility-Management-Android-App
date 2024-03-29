﻿using Facility_Management_APP.Enums;
using Facility_Management_APP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facility_Management_APP.Model
{
    public class AppUser
    {
        #region Entity Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        #endregion

        #region Link with other
        public List<SensorWarning> SensorWarnings { get; set; }
        public int? BuildingId { get; set; } //new//may may user one to many can be null
        public Building Building { get; set; }//if we put a FK we will have a error
        //public int BuildingId { get; set; }//if we put a FK we will have a error
        public List<Incident> Incidents { get; set; }
        ////[InverseProperty("CreatedBy")] //we made this with fluent api look AplicationDBContext 
        public List<Model.Task> TasksCreated { get; set; }
        [InverseProperty("AssignedBy")]
        public List<Model.Task> TasksAssigned { get; set; }
        [InverseProperty("AssignedTo")]
        public List<Model.Task> TasksReceived { get; set; }
        // represents the Unary RelationShip
        public int? SuperId { get; set; }//user SuperVisor Id
        public AppUser Super { get; set; } // supervisor object
        [InverseProperty("Super")]//new//will not make anny difference if we remove it 
        public List<AppUser> SuperUnder { get; set; } // supervised personal 
        //[Required]
       // public string LogUserId { get; set; }
       // public LogUser LogUser { get; set; }
        #endregion
    }
}
