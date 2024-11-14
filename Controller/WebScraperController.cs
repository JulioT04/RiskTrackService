using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using RiskTrack.Util;

namespace RiskTrack.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase {
        private readonly Scraper _scraperService;

        public WebScraperController(Scraper scraperService) {
            _scraperService = scraperService;
        }


        [HttpGet("search")]
        public IActionResult SearchEntities([FromQuery] string entityName, [FromQuery] DatabaseEnum databaseName)
        {

            if (string.IsNullOrEmpty(entityName))
            {
                return BadRequest("El nombre de la entidad es requerido.");
            }
            var results = new List<object>();
            try
            {
                switch(databaseName)
                {
                    case DatabaseEnum.WorldBank:
                        results.AddRange(_scraperService.ScrapeWorldBankFirms(entityName));
                        break;
                    case DatabaseEnum.Ofac:
                        results.AddRange(_scraperService.ScrapeOFACFirms(entityName));
                        break;
                    case DatabaseEnum.OffshoreLeaks:
                        results.AddRange(_scraperService.ScrapeOffShoreFirms(entityName));
                        break;
                }
            }
            catch (NoSuchElementException ex) {
                return BadRequest(new
                {
                    message = "Algo Malio Sal Intentalo mas tarde.",
                    details = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Se produjo un error inesperado.",
                    details = ex.Message
                });
            }


            return Ok(results);
        }
    }
}