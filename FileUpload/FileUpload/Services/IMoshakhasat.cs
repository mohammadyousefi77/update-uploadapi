using FileUpload.Entities;

namespace FileUpload.Services
{
    public interface IMoshakhasat
    {

         Task post(Moshakhsat fileData);

         Task<List<Moshakhsat>>Get();

        Task <Moshakhsat> GetSingle(long id);

        Task<Moshakhsat> Put(long id, Moshakhsat mo);

      void Delete(long  id);
    }
}
