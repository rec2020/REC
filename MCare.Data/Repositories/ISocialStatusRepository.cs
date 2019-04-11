using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ISocialStatusRepository
    {
        int AddSocialStatus(SocialStatus socialStatus);
        SocialStatus GetSocialStatus(int socialStatusId);
        IQueryable<SocialStatus> GetSocialStatuss();
        bool RemoveSocialStatus(int socialStatusId);
        bool UpdateSocialStatus(int socialStatusId, SocialStatus socialStatus);
    }
}
