using Microsoft.AspNetCore.Mvc;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetExcelContoller : ControllerBase
    {

        private readonly IImportExcel _importExcel;
        public GetExcelContoller(IImportExcel importExcel)
        {
            _importExcel = importExcel;
        }
        [HttpGet(Name = "Excel")]
        public async Task<string> Excel()
        {
            var r = await _importExcel.SaveDataFromExcel();

            return r.Data;
        }
    }
}
