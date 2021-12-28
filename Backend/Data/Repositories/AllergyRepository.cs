using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{

    //Inherits methods from Repository repo and Allery Repository interface
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        //Constructor sets AllergyRepository class with DbContext class for database access
        public AllergyRepository(CloudCureDbContext context) : base(context)
        {
        }

        
        /// <summary>
        /// Retrieves list of allergies with same name that the user requested
        /// </summary>
        /// <param name="query">query which will be AllergyName</param>
        public IEnumerable<Allergy> SearchByAllergy(string query)
        {
            var allergy = GetAll().Where(b => b.AllergyName.Equals(query));

            //Returns exception if user provided allergy not found in database
            if (!allergy.Any())
            {
                throw new KeyNotFoundException("Allergy not found.");
            }

            //Returns allergy object containing name requested by user if found in database
            else
            {
                return allergy;
            }
        }

        
        /// <summary>
        /// Retrieves list of allergies associated with user provided PatientId
        /// </summary>
        /// <param name="query">query which will be PatientId</param>
        public IEnumerable<Allergy> SearchByPatientId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(query));

            //Returns exception if user did not provide a PatientId
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;
        }
    }
}