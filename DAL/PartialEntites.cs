using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PartialEntites { }
    [MetadataType(typeof(UserMetaData))]
    public partial class Users : BaseEntity { }
    public class UserMetaData
    {
        [GenericEntityAttribute<AttributeType, int>(AttributeType.CryptoData, 5)]
        public string Email { get; set; }
        [GenericEntityAttribute<AttributeType, string>(AttributeType.HashData, null)]
        public string PasswordHash { get; set; }
        [GenericEntityAttribute<AttributeType, int>(AttributeType.NumberValidateData, 6)]
        public string Gsm { get; set; }
    }

}
