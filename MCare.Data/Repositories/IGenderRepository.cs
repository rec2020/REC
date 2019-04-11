using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IGenderRepository
    {
        int AddGender(Gender gender);
        Gender GetGender(int genderId);
        IQueryable<Gender> GetGenders();
        bool RemoveGender(int genderId);
        bool UpdateGender(int genderId, Gender gender);
    }
}
