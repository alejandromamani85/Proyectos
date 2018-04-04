using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tik4net;

namespace MKCommander.Logic.Services.Base
{
    public abstract class SrvBase
    {
        #region Properties

        protected ITikConnection Connection { get; set; }
        #endregion
    }
}
