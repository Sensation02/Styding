using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Навчання_ООП
{
    interface IJump //інтерфейс прижка
    {
        int JumpHeight { get; set; }
        void Jump();
    }
}
