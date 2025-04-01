using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetClients()
        {
            var clientsDomain = await clientRepository.GetAllAsync();
            //domain model to dto
            var clientsDto = mapper.Map<List<ClientDto>>(clientsDomain);
            return Ok(clientsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] AddClientDto addClientDto)
        {
            var clientDomain = mapper.Map<Client>(addClientDto);
            clientDomain = await clientRepository.AddAsync(clientDomain);
            var clientDto = mapper.Map<ClientDto>(clientDomain);
            return Ok(clientDto);
        }

    }
}
