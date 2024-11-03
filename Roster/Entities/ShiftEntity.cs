using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class ShiftEntity
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

        
        public string Day = string.Empty;

        
        public string StartTime = string.Empty;

        
        public string EndTime = string.Empty;

        //public virtual ShiftAddress StartLocation { get; set; }
        //public virtual ShiftAddress EndLocation { get; set; }

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual AddressEntity StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual AddressEntity EndLocation { get; set; }

        
        public byte TravelTime;

        
        public short MaxTravelDistance;

        //[ObservableProperty]
        //private Address _startLocation;
        
       

        /*
        [ObservableProperty]
        private Address _startLocation;

        [ObservableProperty]        
        private Address _endLocation;

        */

        
        public char ShiftType;

        
        public bool Reoccuring;

        /*
        [ObservableProperty]
        private ShiftTask _shiftTaskId;

        public ShiftTask ShiftTask { get; set; }
        */
        
        public bool CaseNoteCompleted;
        
        public ObservableCollection<ShiftWorkerEntity> ShiftWorkers;
        
        public int ClientId { get; set; } //1 client per shift
        public ClientEntity Client { get; set; } = null;  

        public ObservableCollection<RouteEntity> Routes { get; set; }
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
        public ShiftEntity() { }

        //public Shift(string startDate, string endDate, string startTime, string endTime, int travelTime, Staff staff, Client client, Location location, bool caseNoteCompleted)
        public ShiftEntity(string startTime, string endTime, byte travelTime, short maxTravelDistance, ShiftAddressEntity startLocation, ShiftAddressEntity endLocation, char shiftType, bool reocurring, ClientEntity client)
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
