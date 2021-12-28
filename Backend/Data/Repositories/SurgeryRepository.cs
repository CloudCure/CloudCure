using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Surgery Repository interface
    public class SurgeryRepository : Repository<Surgery>, ISurgeryRepository
    {
        public SurgeryRepository(CloudCureDbContext context) : base(context)
        {
        }

        
        /// <summary>
        /// Retrieves information on surgery based on the Patient id
        /// </summary>
        /// <param name="query">query which will be PatientId</param>
        public IEnumerable<Surgery> SearchByPatientId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }
            return result;
        }
    }
}