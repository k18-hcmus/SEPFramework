using SEPFramework.source.SQLSep.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Poco
{
    [Table("Members")]
    public class Members
    {
        [Key]
        [Column("MemberId")]
        public string MemberId { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("isLogged")]
        public Boolean isLogged { get; set; }

    }
}
