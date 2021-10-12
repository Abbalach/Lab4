using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class AdvancedUserHandler
    {
        public readonly BaseUserHandler[] infos;
        public AdvancedUserHandler(BaseUserHandler info)
        {
            infos = new BaseUserHandler[] { info };
        }
        public AdvancedUserHandler(BaseUserHandler maininfo, BaseUserHandler minorinfo)
        {
            infos = new BaseUserHandler[] { maininfo, minorinfo };
        }
        public AdvancedUserHandler(BaseUserHandler maininfo, BaseUserHandler minorinfo, BaseUserHandler someinfo)
        {
            infos = new BaseUserHandler[] { maininfo, minorinfo, someinfo };
        }
        static public void GetInheritedInfo()
        {
            Console.WriteLine(typeof(FlexibleUserHandler).ToString());
            Console.WriteLine(typeof(WIPUserHandler).ToString());
            Console.WriteLine(typeof(SpecificUserHandler).ToString());
        }
    }
}
