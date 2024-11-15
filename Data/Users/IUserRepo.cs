using RiskTrack.Models;
namespace RiskTrack.Data {
    public interface IUserRepo {
        bool IsUser(string email, string password);

        User GetUserById(int id);
        User GetUserByEmailAndPassword(string email, string password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool SaveChanges();
    }
}