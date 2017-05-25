using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System.Text.RegularExpressions;
    using Framework;

    public partial class AssertionSet
    {

        public AssertionSet IsEmailAddress(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                    , KnownRegexLiterals.EmailAddressRegex
                    , RegexOptions.IgnoreCase
                    , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"Email Address");

        }

        public AssertionSet IsPhoneNumber(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.PhoneNumberRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"Phone Number");
        }

        public AssertionSet IsValidUrl(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.WebUrlRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"Web Url");
        }

        public AssertionSet IsValidIpAddress(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.IpAddressRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"IP Address");
        }

        public AssertionSet IsValidCreditCardNumber(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.CreditCardsRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"Credit Card Number");
        }

        public AssertionSet IsValidSocialSecurityNumber(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.SocialSecurityNumberRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"Social Security Number");
        }


        public AssertionSet IsValidUsZipCode(string value)
        {
            return this.Test(value
                , x => Regex.IsMatch(x
                , KnownRegexLiterals.UsZipCodeRegex
                , RegexOptions.IgnoreCase
                , TimeSpan.FromMilliseconds(250))
                , nameof(value)
                , $"USA Zip Code");
        }

        
    }
}
