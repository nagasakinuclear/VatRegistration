using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.AppLogic;
using Taxually.TechnicalTest.Domain.Entities;
using Taxually.TechnicalTest.Dtos.In;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationService vatRegistrationService;
        private readonly IMapper mapper;

        public VatRegistrationController(
            IVatRegistrationService vatRegistrationService,
            IMapper mapper
            )
        {
            this.vatRegistrationService = vatRegistrationService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> RegisterCountryVat([FromBody] VatRegistrationInDto dto)
        {
            var vatRegistration = mapper.Map<VatRegistrationInDto, VatRegistration>(dto);

            await vatRegistrationService.RegisterCountryVat(vatRegistration);

            return Ok();
        }
    }
}
