using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Surgery Repository interface
    public class SurgeryRepository : Repository<Surgery>, ISurgeryRepository
    {
        //Surgery repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Constructor sets SurgeryRepository class with DbContext class for database access
        public SurgeryRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        // Retrieves information on surgery based on the Patient id
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