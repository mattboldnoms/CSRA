using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public interface ITokenStore<T>
    {
        bool IsTokenValid();

        T GetToken();

        void SaveToken(T token);
    }
}
