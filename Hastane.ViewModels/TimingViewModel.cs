using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hastane.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> morningShiftStart = new List<SelectListItem>();
        List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftStart = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftEnd = new List<SelectListItem>();

        public TimingViewModel()
        {

        }
        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            ScheduleDate = model.ScheduleDate;
            MorningShiftStartTime= model.MorningShiftStartTime;
            MorningShiftEndTime= model.MorningShiftEndTime;
            AfternoonShiftStartTime= model.AfternoonShiftStartTime;
            AfternoonShiftEndTime= model.AfternoonShiftEndTime;
            Duration= model.Duration;
            Status = model.Status;
            DoctorId = model.DoctorId;
            Doctor = model.Doctor;
        }
        public Timing ConverViewModel(TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                ScheduleDate = model.ScheduleDate,
                MorningShiftStartTime = model.MorningShiftStartTime,
                MorningShiftEndTime = model.MorningShiftEndTime,
                AfternoonShiftStartTime = model.AfternoonShiftStartTime,
                AfternoonShiftEndTime = model.AfternoonShiftEndTime,
                Duration = model.Duration,
                Status = model.Status,
                DoctorId = model.DoctorId,
                Doctor=model.Doctor
            };
        }
    }
}
