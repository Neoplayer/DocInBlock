using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthContract.Blazor
{
    public static class DocumentsManager
    {
        public static event Action OnNewDoc;

        public static void UpdateCollection()
        {
            OnNewDoc?.Invoke();
        }
    }
}
