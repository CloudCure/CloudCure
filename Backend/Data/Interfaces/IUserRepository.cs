using Models;

namespace Data
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Finds and returns a User object with the Role Nav property
        /// </summary>
        /// <param name="p_id">User Id</param>
        /// <returns>User object | throws KeyNotFoundException</returns>
        User GetUserById(int p_id);
    }
}