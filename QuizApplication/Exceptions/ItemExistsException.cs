using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Exceptions
{
    public class ItemExistsException : Exception
    {
        public override string Message => "ItemExistsException: item already exists!";
    }
}
