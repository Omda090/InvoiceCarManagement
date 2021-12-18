using AutoMapper;
using InvoiceCarManagement.Dto;
using InvoiceCarManagement.Implement_interfaces;
using InvoiceCarManagement.Interfaces;
using InvoiceCarManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InterfaceInvoice _interfaceInvoice;
        private readonly IMapper _mapper;

        public InvoiceController(InterfaceInvoice interfaceInvoice , IMapper mapper)
        {
            _interfaceInvoice = interfaceInvoice;
            _mapper = mapper;
        }

        [HttpGet("GetInvoiceDetails")]
        public async Task<IActionResult> Get()
        {
            var items = await _interfaceInvoice.GetAll();
            return Ok(items);
        }


        [HttpGet("GetInvoiceById")]

        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await _interfaceInvoice.GetById(id));
        }


        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(InvoiceProductDto invoiceProducts)
        {

            var InvoiceToCreate = _mapper.Map<InvoiceProduct>(invoiceProducts);
            _interfaceInvoice.Add(InvoiceToCreate);
            await _interfaceInvoice.SaveChanges();
            return Ok(InvoiceToCreate);

        }

        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var exitsCurrency = await _interfaceInvoice.GetById(id);


            if (exitsCurrency != null)
            {

                //save changes
                _interfaceInvoice.Remove(exitsCurrency);
                await _interfaceInvoice.SaveChanges();
                return Ok(" interfaceInvoice Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }





        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceProductDto invoiceproduct)
        {
            var exitsInvoice = await _interfaceInvoice.GetById(id);


            //Update Invoice Detials
            exitsInvoice.CarName = invoiceproduct.CarName;
            exitsInvoice.Model = invoiceproduct.Model;
            exitsInvoice.Price = invoiceproduct.Price;
            exitsInvoice.Quentity = invoiceproduct.Quentity;
            //Save Changes
            await _interfaceInvoice.SaveChanges();


            return Ok(" interfaceInvoice Updated Successfully ");
        }

    }
}
