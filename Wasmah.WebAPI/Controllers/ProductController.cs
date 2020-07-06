using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wasmah.BusinessLogic;
using Wasmah.Entities;
using Wasmah.WebAPI.DTO;

namespace Wasmah.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public ProductController(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IQueryable<ProductDTO>> GetAll()
        {
            var products = await _unitOfWork.ProductManager.GetAllAsync(); 
            return products.Select(e => _mapper.Map<ProductDTO>(e));
        }
    }
}