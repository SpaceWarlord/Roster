﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class Shift: BaseModel
    {
        [Key]
        public int ShiftId { get; protected set; }

        /*
        private string startDate;
        public string StartDate
        {
            get
            {
                if (startDate == string.Empty)
                {
                    return DateTimeOffset.Now;
                }
                return DateTimeOffset.Parse(StartDate);

            }
            set => SetProperty(ref startDate, value);
        }*/

        [ObservableProperty]
        private string day = string.Empty;

        [ObservableProperty]
        private string _startTime = string.Empty;

        [ObservableProperty]
        private string _endTime = string.Empty;

        //public virtual ShiftAddress StartLocation { get; set; }
        //public virtual ShiftAddress EndLocation { get; set; }

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual Address StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual Address EndLocation { get; set; }

        [ObservableProperty]
        private byte _travelTime;

        [ObservableProperty]
        private short _maxTravelDistance;

        //[ObservableProperty]
        //private Address _startLocation;
        
       

        /*
        [ObservableProperty]
        private Address _startLocation;

        [ObservableProperty]        
        private Address _endLocation;

        */

        [ObservableProperty]
        private char _shiftType;

        [ObservableProperty]
        private bool _reoccuring;

        /*
        [ObservableProperty]
        private ShiftTask _shiftTaskId;

        public ShiftTask ShiftTask { get; set; }
        */
        [ObservableProperty]
        private bool _caseNoteCompleted;
        
        private ObservableCollection<ShiftWorker> _shiftWorkers;
        
        public int ClientId { get; set; } //1 client per shift
        public Client Client { get; set; } = null;  

        public ObservableCollection<Route> Routes { get; set; }
        /*
        [NotMapped]
        public DateTimeOffset StartDateTemp
        {
            get
            {
                if(StartDate == string.Empty)
                {
                    return DateTimeOffset.Now; 
                }                
                return DateTimeOffset.Parse(StartDate);
            }
            set
            {
                StartDate = value.ToString();
            }
        }

        [NotMapped]
        public DateTimeOffset EndDateTemp
        {
            get
            {
                if (EndDate == string.Empty)
                {
                    return DateTimeOffset.Now;
                }
                return DateTimeOffset.Parse(EndDate);
            }
            set
            {
                EndDate = value.ToString();
            }
        }

        [NotMapped]
        public DateTimeOffset StartTimeTemp
        {
            get
            {
                if (StartTime == string.Empty)
                {
                    return DateTimeOffset.Now;
                }
                return DateTimeOffset.Parse(StartTime);
            }
            set
            {
                StartTime = value.ToString();
            }
        }

        [NotMapped]
        public DateTimeOffset EndTimeTemp
        {
            get
            {
                if (EndTime == string.Empty)
                {
                    return DateTimeOffset.Now;
                }
                return DateTimeOffset.Parse(EndTime);
            }
            set
            {
                EndTime = value.ToString();
            }
        }
        */
        public Shift() { }

        //public Shift(string startDate, string endDate, string startTime, string endTime, int travelTime, Staff staff, Client client, Location location, bool caseNoteCompleted)
        public Shift(string startTime, string endTime, byte travelTime, short maxTravelDistance, ShiftAddress startLocation, ShiftAddress endLocation, char shiftType, bool reocurring, Client client)
        {                        
            StartTime = startTime;
            EndTime = endTime;
            TravelTime = travelTime;
            MaxTravelDistance = maxTravelDistance;
            StartLocation = startLocation;
            EndLocation = endLocation;
            ShiftType = shiftType;
            Reoccuring = reocurring;            
            Client = client;
            //Location = location;
            //CaseNoteCompleted = caseNoteCompleted;            
        }
    }
}
