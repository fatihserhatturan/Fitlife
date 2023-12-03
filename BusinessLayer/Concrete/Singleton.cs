using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public sealed class Singleton
    {
        private Singleton() { }
        public static Singleton _instance;
        public string mail;
        public string code;

        public static Singleton GetInstance()
        {
            if( _instance == null)
            {
                _instance = new Singleton();
                _instance.mail = null;
                _instance.code = null;
            }
            return _instance;
        }
    }
}
