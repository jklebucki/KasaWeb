using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.BankAccount;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IMapper _mapper;

        public BankAccountController(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var bankAccount = await _bankAccountService.GetBankAccountById(id);
                return Ok(_mapper.Map<BankAccountDto>(bankAccount));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("BankAccounts/{sourceId}/{accountOwner}")]
        public async Task<IActionResult> GetBySourceId(int sourceId, AccountOwner accountOwner)
        {
            var bankAccounts = await _bankAccountService.GetBankAccountsBySourceId(sourceId, accountOwner);
            return Ok(_mapper.Map<List<BankAccountDto>>(bankAccounts));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBankAccount createBankAccount)
        {
            if (createBankAccount == null)
                return BadRequest("CrateBankAccount command is null");
            try
            {
                var bankAccount = _mapper.Map<BankAccount>(createBankAccount);
                var newBankAccountId = await _bankAccountService.AddBankAccount(bankAccount);
                return Created($"LocationAccount/{newBankAccountId}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _bankAccountService.DeleteBankAccount(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(CreateBankAccount createBankAccount)
        {
            if (createBankAccount == null)
                return BadRequest("CreateBankAccount command is null");
            try
            {
                var bankAccount = _mapper.Map<BankAccount>(createBankAccount);
                await _bankAccountService.UpdateBankAccount(bankAccount);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
