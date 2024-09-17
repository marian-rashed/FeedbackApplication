using FeedbackApplication.Models;

namespace FeedbackApplication.Repository.Interface
{
    public interface IOpinionRepository
    {
        void Add(Opinion Entity);

        IEnumerable<Opinion> GetAll();

        void Save();
    }
}
