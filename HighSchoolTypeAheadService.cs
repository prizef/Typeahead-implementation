using Data.Providers;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HighSchoolTypeAheadService : IHighSchoolTypeAheadService
    {
        readonly IDataProvider dataProvider;

        public HighSchoolTypeAheadService(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public List<HighSchoolTypeAheadRequest> GetByName(HighSchoolTypeAheadRequestName model)
        {
            string holder = Utils.ConvertStringToLikeExpression(model.Name);

            List<HighSchoolTypeAheadRequest> results = new List<HighSchoolTypeAheadRequest>();

            dataProvider.ExecuteCmd(
                "HighSchool_Type_Ahead_Search",
                inputParamMapper: param =>
                {
                    param.AddWithValue("@Name", holder);
                },
                singleRecordMapper: (reader, resultSetNumber) =>
                {
                    HighSchoolTypeAheadRequest highSchoolTypeAhead = new HighSchoolTypeAheadRequest();
                    highSchoolTypeAhead.Name = (string)reader["Name"];
                    highSchoolTypeAhead.Id = (int)reader["Id"];
                    results.Add(highSchoolTypeAhead);
                });
            return results;
        }
    }
}
