using FeedbackApplication.Models;

namespace FeedbackApplication.Repository.Interface
{
    public interface IOpinionRepository
    {
        void Add(Opinion Entity);

        IEnumerable<Opinion> GetAll();
        public void Delete(int id);

        Opinion Get(int id);

        void Save();
    }
}
