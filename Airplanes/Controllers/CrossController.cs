using Airplanes.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        private readonly ILogger<CrossController> _logger;
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            _logger = logger;
            _cross = cross;
        }
        [HttpGet("AirportForAirplane/{pid}")]
        public async Task<IActionResult> GetAirplaneByAirportId(Guid pid)
        {
            try
            {
                var airplane = await _cross.GetAirportByAirplaneId(pid);
                return Ok(new
                {
                    Success = true,
                    Message = "輸出Airplane的id,name且對應Airport",
                    airplane
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("AirplaneForAirport/{aid}")]
        public async Task<IActionResult> GetAirportByAirplaneId(Guid aid)
        {
            try
            {
                var airport = await _cross.GetAirplaneByAirportId(aid);
                return Ok(new
                {
                    Success = true,
                    Message = "輸出Airport的id,name且對應Airplane",
                    airport
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("AirplaneDetailsForAirport/{aid}")]
        public async Task<IActionResult> GetAirplaneDetailsByAirportId(Guid id)
        {
            try
            {
                var airplaneDetails = await _cross.GetAirplaneDetailsByAirportId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定 id 詳細資料成功",
                    Data = airplaneDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("AirportDetailsForAirplane/{pid}")]
        public async Task<IActionResult> GetAirportDetailsByAirplaneId(Guid id)
        {
            try
            {
                var airportDetails = await _cross.GetAirportDetailsByAirplaneId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定 id 詳細資料成功",
                    Data = airportDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

