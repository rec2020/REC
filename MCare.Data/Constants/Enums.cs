using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Constants
{
    public enum LanguageEnum
    {
        Arabic = 1, English
    }

    public enum VacationTypeEnum
    {
        Annual = 1, Urgent, Offical
    }

    public enum VacationStatusEnum
    {
        Pending = 1, Accepted, Rejected
    }

    public enum AppointmentStatusEnum
    {
        Pending = 1, Confirmed, Cancled, Completed
    }

    public enum ScheduleStatusEnum
    {
        Free = 1, Booked, Vaction, NotAllowed
    }
}
