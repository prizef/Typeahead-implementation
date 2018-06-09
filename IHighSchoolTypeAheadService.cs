using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IHighSchoolTypeAheadService
    {
        List<HighSchoolTypeAheadRequest> GetByName(HighSchoolTypeAheadRequestName model);
    }
}
