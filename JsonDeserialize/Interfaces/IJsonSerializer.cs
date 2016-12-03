using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserialize.Interfaces
{
    public interface IJsonSerializer
    {
        List<IMyObject> ParseJsonToMyObject(string json);
    }
}
