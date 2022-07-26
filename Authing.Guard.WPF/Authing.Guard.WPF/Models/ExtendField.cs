using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Authing.Guard.WPF.Utils.Extensions;

namespace Authing.Guard.WPF.Models
{
    public enum ControlName
    {
        [EnumMember(Value = "name")]
        UserInfoName,

        [EnumMember(Value = "username")]
        UserInfoUserName,

        [EnumMember(Value = "nickename")]
        UserInfoNickName,

        [EnumMember(Value = "gender")]
        UserInfoGender,

        [EnumMember(Value = "birthdate")]
        UserInfoBirthdate,

        [EnumMember(Value = "phone")]
        UserInfoPhone,

        [EnumMember(Value = "country")]
        UserInfoCountry,

        [EnumMember(Value = "company")]
        UserInfoCompany,

        [EnumMember(Value = "city")]
        UserInfoCity,

        [EnumMember(Value = "province")]
        UserInfoCProvince,

        [EnumMember(Value = "address")]
        UserInfoStreetAddress,

        [EnumMember(Value = "postalCode")]
        UserInfoStreetPostalCode,

        [EnumMember(Value = "formatted")]
        UserInfoStreetformatted,

        [EnumMember(Value = "email")]
        UserInfoMail,
    }

    public enum ComplatePlace
    {
        [EnumMember(Value = "login")]
        login,
        [EnumMember(Value = "register")]
        Register
    }

    public class ExtendField
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public ControlName Control
        {
            get
            {
                return EnumExtension.ToEnum<ControlName>(Name);
            }
        }
    }

    public class ExtendConfig
    {
        public bool CanIgnore { get; set; }

        public List<string> Places { get; set; }

        public List<ExtendField> ExtendFields { get; set; }

        public List<ComplatePlace> ComplatePlaces
        {
            get
            {
                return Places.Select(t => EnumExtension.ToEnum<ComplatePlace>(t)).ToList();
            }
        }
    }
}