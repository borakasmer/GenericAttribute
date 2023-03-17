using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenericEntityAttribute<T,T2> : Attribute
    {
        private T key { get; set; }
        private T2? parameter { get; set; }

        public GenericEntityAttribute(T key, T2? parameter)
        {
            this.key = key;
            this.parameter = parameter;
        }

        public T Key
        {
            get
            {
                return key;
            }
        }
        public T2? Parameter
        {
            get
            {
                return parameter;
            }
        }
    }
}
