using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiskTrack.Data;
using RiskTrack.DTOs;
using RiskTrack.Models;

namespace RiskTrack.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase{
        private readonly IMapper _mapper;
        private readonly IProviderRepo _repo;

        public ProvidersController(IProviderRepo repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProviderReadDTO>> GetProviders(){
            var providers = _repo.GetAllProviders();
             if (providers == null || !providers.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ProviderReadDTO>>(providers));
        }

        [HttpGet("{id}", Name = "GetProviderById")]
        public ActionResult<ProviderReadDTO> GetProviderById(int id)
        {
            var providerItem = _repo.GetProviderById(id);
            if (providerItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProviderReadDTO>(providerItem));
        }
        [HttpPost]
        public async Task<ActionResult<ProviderReadDTO>> CreateProvider(ProviderCreateDTO providerCreateDTO)
        {
            var providerModel = _mapper.Map<Provider>(providerCreateDTO);
            _repo.CreateProvider(providerModel);
            _repo.SaveChanges();
            var providerReadDTO = _mapper.Map<ProviderReadDTO>(providerModel);
            return CreatedAtRoute(nameof(GetProviderById), new { id = providerReadDTO.Id }, providerReadDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProvider(int id, ProviderCreateDTO providerUpdateDTO)
        {
            var providerFromRepo = _repo.GetProviderById(id);
            if (providerFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(providerUpdateDTO, providerFromRepo);
            providerFromRepo.LastEditedDate = DateTime.Now;
            _repo.UpdateProvider(providerFromRepo); // Implementación opcional en el repositorio
            _repo.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProvider(int id)
        {
            var providerFromRepo = _repo.GetProviderById(id);
            if (providerFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteProvider(providerFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}