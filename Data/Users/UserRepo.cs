using RiskTrack.Models;

namespace RiskTrack.Data {
    public class UserRepo : IUserRepo {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null){
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p=>p.Id==id);
        }

        public bool IsUser(string email, string password){
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges()>=0;
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}