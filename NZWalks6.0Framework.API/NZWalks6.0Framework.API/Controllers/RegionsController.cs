using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks6._0Framework.API.Models.Domain;
using NZWalks6._0Framework.API.Models.DTOs;
using NZWalks6._0Framework.API.Repository;

namespace NZWalks6._0Framework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _sQLRegionRepository;
        private readonly IMapper _mapper;

        public RegionsController( IRegionRepository sQLRegionRepository, IMapper mapper)
        {
            this._sQLRegionRepository = sQLRegionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _sQLRegionRepository.GetAllRegionsAsync();
            if(regions == null)
            {
                return NotFound();
            }
            //Map Region domain model to Region DTO  model
            //var regionsDto = new List<RegionDto>();
            //regions.ToList().ForEach(regions=>
            //{
            //    var regionDto = new RegionDto()
            //    {
            //        Id = regions.Id,
            //        Name = regions.Name,
            //        Code = regions.Code,
            //        Area = regions.Area,
            //        Lat = regions.Lat,
            //        Long = regions.Long,
            //        Population = regions.Population,
            //};
                

            //    regionsDto.Add(regionDto);
            //});
            return Ok(_mapper.Map<List<RegionDto>>(regions));
        }
        [HttpGet]
        [Route("{regionId:Guid}")]
        [ActionName("GetRegionByIdAsync")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute] Guid regionId)
        {
            var regionDomainModel = await _sQLRegionRepository.GetRegionByIdAsync(regionId);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            //Map Region Domain model to Region DTO Model 
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            var fetchDomainModel = await _sQLRegionRepository.AddRegionAsync(regionDomainModel);
            if(fetchDomainModel == null)
            {
                return NotFound();
            }
            var regionDtoModel = _mapper.Map<RegionDto>(fetchDomainModel);
            return CreatedAtAction(nameof(GetRegionByIdAsync), new {regionId = regionDtoModel.Id}, regionDtoModel);
        }
        [HttpDelete]
        [Route("{regionId:Guid}")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid regionId)
        {
            var regionDomainModel = await _sQLRegionRepository.DeleteRegionAsync(regionId);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
        [HttpPut]
        [Route("{regionId:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid regionId, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
            var updateRegionDomainModel = _sQLRegionRepository.UpdateRegionAsync(regionId, regionDomainModel);
            if(updateRegionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(updateRegionDomainModel));
        }
    }
}
