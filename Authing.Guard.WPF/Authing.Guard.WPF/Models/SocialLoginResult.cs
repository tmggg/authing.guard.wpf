using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Models
{
    internal class SocialLoginResult
    {
    }


    public class Rootobject
    {
        public int code { get; set; }
        public Data data { get; set; }
        public Event _event { get; set; }
        public string message { get; set; }
    }

    public class Data
    {
        public string _id { get; set; }
        public object address { get; set; }
        public object birthdate { get; set; }
        public bool blocked { get; set; }
        public object browser { get; set; }
        public object city { get; set; }
        public object company { get; set; }
        public object country { get; set; }
        public DateTime createdAt { get; set; }
        public object device { get; set; }
        public object email { get; set; }
        public bool emailVerified { get; set; }
        public string encryptedPassword { get; set; }
        public object externalId { get; set; }
        public object familyName { get; set; }
        public object formatted { get; set; }
        public string gender { get; set; }
        public object givenName { get; set; }
        public string id { get; set; }
        public Identity[] identities { get; set; }
        public bool isDeleted { get; set; }
        public bool isRoot { get; set; }
        public string lastIP { get; set; }
        public string lastIp { get; set; }
        public DateTime lastLogin { get; set; }
        public string lastLoginApp { get; set; }
        public object lastMfaTime { get; set; }
        public object locale { get; set; }
        public object locality { get; set; }
        public int loginsCount { get; set; }
        public object mainDepartmentCode { get; set; }
        public object mainDepartmentId { get; set; }
        public object middleName { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public object oauth { get; set; }
        public object openid { get; set; }
        public string password { get; set; }
        public string passwordLastSetAt { get; set; }
        public int passwordSecurityLevel { get; set; }
        public object phone { get; set; }
        public object phoneCountryCode { get; set; }
        public bool phoneVerified { get; set; }
        public string photo { get; set; }
        public object[] positions { get; set; }
        public object postalCode { get; set; }
        public object preferredUsername { get; set; }
        public string profile { get; set; }
        public object province { get; set; }
        public object region { get; set; }
        public string registerInClient { get; set; }
        public string registerMethod { get; set; }
        public string[] registerSource { get; set; }
        public bool resetPasswordOnFirstLogin { get; set; }
        public bool resetPasswordOnNextLogin { get; set; }
        public bool resetedPassword { get; set; }
        public object salt { get; set; }
        public object secretInfo { get; set; }
        public int sendSmsCount { get; set; }
        public int sendSmsLimitCount { get; set; }
        public DateTime signedUp { get; set; }
        public string status { get; set; }
        public object statusChangedAt { get; set; }
        public object streetAddress { get; set; }
        public object syncExtInfo { get; set; }
        public Thirdpartyidentity thirdPartyIdentity { get; set; }
        public string token { get; set; }
        public DateTime tokenExpiredAt { get; set; }
        public object unionid { get; set; }
        public DateTime updatedAt { get; set; }
        public string userPoolId { get; set; }
        public string userSourceId { get; set; }
        public string userSourceType { get; set; }
        public string username { get; set; }
        public object website { get; set; }
        public object zoneinfo { get; set; }
    }

    public class Thirdpartyidentity
    {
        public object accessToken { get; set; }
        public object expiresIn { get; set; }
        public object provider { get; set; }
        public object refreshToken { get; set; }
        public object scope { get; set; }
        public object updatedAt { get; set; }
    }

    public class Identity
    {
        public string accessToken { get; set; }
        public DateTime createdAt { get; set; }
        public string extIdpId { get; set; }
        public string id { get; set; }
        public bool isSocial { get; set; }
        public object openid { get; set; }
        public object origianlProfile { get; set; }
        public string[] originConnIds { get; set; }
        public string provider { get; set; }
        public string refreshToken { get; set; }
        public object syncIdentityProviderId { get; set; }
        public string type { get; set; }
        public DateTime updatedAt { get; set; }
        public string userId { get; set; }
        public string userIdInIdp { get; set; }
        public Userinfoinidp userInfoInIdp { get; set; }
        public string userPoolId { get; set; }
    }

    public class Userinfoinidp
    {
        public string accessToken { get; set; }
        public object email { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string photo { get; set; }
        public string profile { get; set; }
        public string refreshToken { get; set; }
        public string username { get; set; }
        public object website { get; set; }
    }

    public class Event
    {
        public string eventType { get; set; }
        public string source { get; set; }
    }

}
