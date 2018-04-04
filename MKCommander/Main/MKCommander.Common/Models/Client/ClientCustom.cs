using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKCommander.Common.Models.Client
{
    public class ClientCustom
    {
        public String Name { get; set; }
        public String Target { get; set; }
        public String Comment { get; set; }
        public String Index { get; set; }
        public String Host { get; set; }
        public String Blocked { get; set; }

        public ClientCustom(String name, String target, String comment)
        {
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
        }
        public ClientCustom(String name, String target, String comment, String host)
        {
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.Host = host;
        }
        public ClientCustom(String name, String target, String comment, String host, Int32 index)
        {
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.Host = host;
            this.Index = Convert.ToString(index);
        }
        public ClientCustom(String name, String target, String comment, String host, Int32 index, Boolean blocked)
        {
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.Host = host;
            this.Index = Convert.ToString(index);
            this.Blocked = Convert.ToString(blocked);
        }
    }
}
