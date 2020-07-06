using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wasmah.BusinessLogic;
using Wasmah.Entities;
using Wasmah.WebAPI.DTO;

namespace Wasmah.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public InvoiceController(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<InvoiceDTO> Get([FromRoute] int id)
        {
            var invoice = (await _unitOfWork.InvoiceManager.GetByIdAsync(id));
            return _mapper.Map<InvoiceDTO>(invoice);
        }

        [HttpGet]
        public async Task<IQueryable<InvoiceDTO>> GetAll()
        {
            var invoices = await _unitOfWork.InvoiceManager.GetAllAsync();
            return invoices.Select(e => _mapper.Map<InvoiceDTO>(e));
        }

        [HttpGet("CalculateInvoice")]
        public float CalculateInvoice(List<ProductDTO> products)
        {
            var productList = products.Select(e => _mapper.Map<Product>(e)).ToList();
            var invoiceResult = _unitOfWork.InvoiceManager.CalculateInvoice(productList);
            return invoiceResult;
        }

        [HttpPost("AddInvoice")]
        public async Task<InvoiceDTO> AddInvoice([FromBody] List<ProductDTO> products)
        {
            var productList = products.Select(e => _mapper.Map<Product>(e)).ToList();
            var invoiceResult = (await _unitOfWork.InvoiceManager.AddInvoice(productList));
            return _mapper.Map<InvoiceDTO>(invoiceResult);
        }
    }
}