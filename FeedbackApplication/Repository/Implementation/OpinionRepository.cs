using FeedbackApplication.Models;
using FeedbackApplication.Repository.Interface;

namespace FeedbackApplication.Repository.Implementation
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly FeedbackDbContext _context;

        public OpinionRepository(FeedbackDbContext context)
        {
            _context = context;
        }

        public void Add(Opinion Entity)
        {
            _context.Add(Entity);
        }

        public IEnumerable<Opinion> GetAll()
        {
            return _context.Opiniones.Where(o => !o.IsDeleted).ToList();
        }

        public Opinion Get(int id)
        {
            return _context.Opiniones.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        }


        public void Delete(int id) 
        {
            _context.Update(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
