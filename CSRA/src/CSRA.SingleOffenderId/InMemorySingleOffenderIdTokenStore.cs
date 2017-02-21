using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public interface ISingleOffenderIdTokenStore : ITokenStore<SingleOffenderIdToken>
    {

    }
    public class InMemorySingleOffenderIdTokenStore : ISingleOffenderIdTokenStore
    {
        private SingleOffenderIdToken storedToken;
        private static readonly object lockObject = new object();
        private DateTime actualTokenExpiry;

        public bool IsTokenValid()
        {
            lock (lockObject)
            {
                if (DateTime.UtcNow < actualTokenExpiry)
                {
                    return storedToken != null;
                }
            }

            return false;
        }

        public SingleOffenderIdToken GetToken()
        {
            lock (lockObject)
            {
                if (DateTime.UtcNow < actualTokenExpiry)
                {
                    return storedToken;
                }
            }

            return null;
        }

        public void SaveToken(SingleOffenderIdToken token)
        {
            lock (lockObject)
            {
                this.storedToken = token;
                this.actualTokenExpiry = new DateTime(1970, 1, 1).AddSeconds(token.CreatedAt).AddSeconds(token.ExpiresIn - 60);
            }
        }
    }
}
