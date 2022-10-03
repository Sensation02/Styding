using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Навчання_ООП
{
    interface IRun //обов"язково перед назвою пишеться велика буква "І"
    {
        //тут описуються поля і методи без реалізації, як абстрактні
        public float Speed { get; set; } //аксессер (проперти)

        void Run(); //метод без реалізації
    }
}
