using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entites
{
    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public ProfileEntity(ProfileDto profileDto)
        {
            this.CertId = profileDto.CertId;
            this.RegisteredCapital = profileDto.RegisteredCapital;
        }

        [ForeignKey("CompanyEntity")]
        public int? Id { get; set; }
        public int? RegisteredCapital { get; set; }
        public string CertId { get; set; }
        public CompanyEntity CompanyEntity { get; set; }
    }
}
