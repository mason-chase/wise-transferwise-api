using Azihub.Utilities.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Wise.NetStandard.Tests.Settings
{
    public static class TestSettings 
    {
        static TestSettings()
        {
            DotEnv.Load();
            Settings = DotEnv.Load<WorkerSettings>();
        }

        public static WorkerSettings Settings { get; set; }
    }
}
