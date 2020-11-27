using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public ProfileEntity(ProfileDto profile)
        {
            this.CertId = profile.CertId;
            this.RegisteredCapital = profile.RegisteredCapital;
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}
