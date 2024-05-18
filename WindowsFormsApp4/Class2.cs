using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public interface ISerializable
    {
        void OnBeforeSerialize();
        void OnAfterDeserialize();

    }
}
