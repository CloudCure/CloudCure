using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Vitals Repository interface
    public class VitalsRepository : Repository<Vitals>, IVitalsRepository
    {
        //Constructor sets VitalsRepository class with DbContext class for database access
        public VitalsRepository(CloudCureDbContext context) : base(context)
        {
        }

        
        /// <summary>
        /// Retrieves Vitals report of a specific patient containg that patient's DiagnosisId
        /// </summary>
        /// <param name="p_patientId">query which will be DiagnosisId</param>
        public Vitals SearchByDiagnosisId(int p_patientId)
        {
            try
            {
            var result = base.GetAll()
                        .FirstOrDefault(vital => vital.DiagnosisId == p_patientId);
            return result;
            }
            
            //Returns an exception if there were no vitals report found for the patient
            catch (System.Exception)
            {
                
                throw new KeyNotFoundException("No Vitals Found");
            }
        }
    }
}