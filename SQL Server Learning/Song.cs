using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Server_Learning
{
    //таблиця пісень
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        //зв"язок із іншою таблицею:
        public virtual Group Group { get; set; }
        //Entity Framework буде автоматично підставляти ці властивості
    }
}
