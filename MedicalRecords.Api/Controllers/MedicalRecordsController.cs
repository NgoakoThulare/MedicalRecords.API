using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalRecords.Api.Controllers
{
    [Route("Email")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsService medicalRecordsService;
        public MedicalRecordsController(IMedicalRecordsService medicalRecordsService) => 
            this.medicalRecordsService = medicalRecordsService;

        [HttpPost]
        public async Task<bool> SendAttachments(Request request)
        {
            return await this.medicalRecordsService.SendEmail(request);
        }
    }
}
