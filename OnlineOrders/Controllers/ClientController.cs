using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using OnlineOrders.CustomActionFilters;
using OnlineOrders.Models.Domain;
using OnlineOrders.Models.DTO;
using OnlineOrders.Repository;

namespace OnlineOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] string? filterBy = null, [FromQuery] string? filterQuery = null,
            [FromQuery] string? sortBy = null, [FromQuery] bool? isAscending = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var clientsDomain = await clientRepository.GetAllAsync(filterBy, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            //domain model to dto
            var clientsDto = mapper.Map<List<ClientDto>>(clientsDomain);
            return Ok(clientsDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateClient([FromBody] AddClientDto addClientDto)
        {
            var clientDomain = mapper.Map<Client>(addClientDto);
            clientDomain = await clientRepository.AddAsync(clientDomain);
            var clientDto = mapper.Map<ClientDto>(clientDomain);
            return Ok(clientDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var clientDomain = await clientRepository.GetByIdAsync(id);
            if (clientDomain == null)
            {
                return NotFound();
            }
            var clientDto = mapper.Map<ClientDto>(clientDomain);
            return Ok(clientDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateClient([FromRoute] Guid id, [FromBody] UpdateClientDto updateClientDto)
        {
            var clientDomain = mapper.Map<Client>(updateClientDto);

            clientDomain = await clientRepository.UpdateAsync(id, clientDomain);

            if(clientDomain == null)
            {
                return NotFound();
            }

            var clientDto = mapper.Map<UpdateClientDto>(clientDomain);

            return Ok(clientDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            var clientDomain = await clientRepository.DeleteAsync(id);
            if(clientDomain == null)
            {
                return NotFound();
            }
            var clientDto = mapper.Map<DeleteClientDto>(clientDomain);
            return Ok(clientDto);
        }
    }
}
