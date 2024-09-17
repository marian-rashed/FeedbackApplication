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
            return _context.Opiniones.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
