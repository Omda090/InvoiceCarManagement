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
        public async Task<IActionResult> CreateInvoice(InvoiceProductDto invoiceProducts, InvoiceDetailsDto invoiceDetails)
        {

            var InvoiceToCreate = _mapper.Map<InvoiceProduct>(invoiceProducts);
            var InvoiceDetails = _mapper.Map<InvoiceDetails>(invoiceDetails);
            _interfaceInvoice.Add(InvoiceToCreate, InvoiceDetails);
            await _interfaceInvoice.SaveChanges();
            return Ok(InvoiceToCreate);

        }

        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var exitsInvoice = await _interfaceInvoice.GetById(id);


            if (exitsInvoice != null)
            {

                //save changes
                _interfaceInvoice.Remove(exitsInvoice);
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

            //2

            //exitsInvoice.Name = invoiceDetails.Name;
            //exitsInvoice.Address = invoiceDetails.Address;
            //exitsInvoice.PhoneNumber = invoiceDetails.PhoneNumber;

            //exitsInvoice.Email = invoiceDetails.Email;
            //exitsInvoice.Date = invoiceDetails.Date;


      

        //Save Changes
        await _interfaceInvoice.SaveChanges();


            return Ok(" interfaceInvoice Updated Successfully ");
        }

    }
}
