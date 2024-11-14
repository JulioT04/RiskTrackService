using RiskTrack.Models;

namespace RiskTrack.Data{
    public class ProviderRepo : IProviderRepo
    {
        private readonly AppDbContext _context;
        public ProviderRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateProvider(Provider provider)
        {
            if(provider == null){
                throw new ArgumentNullException(nameof(provider));
            }
            provider.LastEditedDate = DateTime.Now;
            _context.Providers.Add(provider);
        }
        public void UpdateProvider(Provider provider)
        {

        }
        public void DeleteProvider(Provider provider)
        {
            _context.Providers.Remove(provider);
        }

        public IEnumerable<Provider> GetAllProviders()
        {
            return _context.Providers.ToList();
        }

        public Provider GetProviderById(int id)
        {
            return _context.Providers.FirstOrDefault(p=>p.Id==id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges()>=0;
        }
    }
}