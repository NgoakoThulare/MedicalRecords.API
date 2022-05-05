using System.Threading.Tasks;

namespace MedicalRecords.Api
{
    public interface IMedicalRecordsService
    {
        Task<bool> SendEmail(Request request);
    }
}
