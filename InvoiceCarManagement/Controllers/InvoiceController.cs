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
        private readonly InterfaceDetails _interfaceDetails;

        public InvoiceController(InterfaceInvoice interfaceInvoice, IMapper mapper,InterfaceDetails interfaceDetails)
        {
            _interfaceInvoice = interfaceInvoice;
            _mapper = mapper;
            _interfaceDetails = interfaceDetails;
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
            var salesMaster = new InvoiceProduct()
            {
                CarName = invoiceProducts.CarName,
                Color = invoiceProducts.Color,
                Desc = invoiceProducts.Desc,
                Model = invoiceProducts.Model,
                Price = invoiceProducts.Price,
                Quentity = invoiceProducts.Quentity

            };

            _interfaceInvoice.Add(salesMaster);
            await _interfaceInvoice.SaveChanges();

            foreach (var i in invoiceProducts.InvoiceDetails)
            {
                var saleInvoiceDetail = new InvoiceDetails()
                {
                  InvoiceProductId= salesMaster.ID,
                    Name = i.Name,
                    Address = i.Address,
                    PhoneNumber = i.PhoneNumber,
                    Email = i.Email,
                    Date = i.Date

                };

                _interfaceDetails.Add(saleInvoiceDetail);
                await _interfaceDetails.SaveChanges();
            }
            return Ok(salesMaster);

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
