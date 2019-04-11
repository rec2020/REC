using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IReligionRepository
    {
        int AddReligion(Religion religion);
        Religion GetReligion(int religionId);
        IQueryable<Religion> GetReligions();
        bool RemoveReligion(int religionId);
        bool UpdateReligion(int religionId, Religion religion);
    }
}
