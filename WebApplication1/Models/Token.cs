using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Token
    {
        private const string secret = "Y98Phuhp98Yh7Y87y7y7Y9okçKNbjgftrdY4er6u7Y98YH77UTFU4E54DCTRC65R86TY8YFYRD54ED45ECTYGV76T76GVRTD5Fuyf5d6ytCCF76kkkjj";

        public string GenerateToken(string id)
        {
            var payload = new Dictionary<string, object>
            {
                { "id", id }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }

        public string DecodeToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                return json;
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return "Token has invalid signature";
            }
        }
    }
}
