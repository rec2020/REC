using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class SocialStatusRepository : ISocialStatusRepository
    {
        private NajmetAlraqeeContext _context;

        public SocialStatusRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddSocialStatus(SocialStatus socialStatus)
        {
            _context.SocialStatuses.Add(socialStatus);
            _context.SaveChanges();

            return socialStatus.Id;
        }

        public SocialStatus GetSocialStatus(int socialStatusId)
        {
            return _context.SocialStatuses
               .SingleOrDefault(p => p.Id == socialStatusId);
        }

        public IQueryable<SocialStatus> GetSocialStatuss()
        {
            return _context.SocialStatuses;
        }

        public bool RemoveSocialStatus(int socialStatusId)
        {
            SocialStatus socialStatus = GetSocialStatus(socialStatusId);
            if (socialStatus == null)
                return false;
            _context.Remove(socialStatus);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateSocialStatus(int socialStatusId, SocialStatus socialStatus)
        {
            SocialStatus existsocialStatus = GetSocialStatus(socialStatusId);
            if (existsocialStatus == null)
                return false;

            existsocialStatus.Name = socialStatus.Name;
            _context.Update(existsocialStatus);
            _context.SaveChanges();

            return true;
        }
    }
}
