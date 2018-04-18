using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocce
{
    class Player
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public string ThrowingArm { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
