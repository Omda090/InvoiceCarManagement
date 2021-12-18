using AutoMapper;
using InvoiceCarManagement.Dto;
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
        public async Task<IActionResult> CreateInvoice(InvoiceProductDto invoiceProductDto)
        {

            var InvoiceToCreate = _mapper.Map<InvoiceProduct>(invoiceProductDto);
            _interfaceInvoice.Add(InvoiceToCreate);
            await _interfaceInvoice.SaveChanges();
            return Ok(InvoiceToCreate);

        }

        [HttpDelete("DeleteSector")]
        public async Task<IActionResult> DeleteSector(decimal id)
        {
            var exitsCurrency = await _sectors.GetById(id);


            //check if Currency exit or not 
            if (exitsCurrency != null)
            {

                //save changes
                _sectors.Remove(exitsCurrency);
                await _sectors.SaveAll();
                return Ok(" sectors Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateSector")]
        public async Task<IActionResult> UpdateSector(int id, SectorDto sectors)
        {
            var exitsCurrency = await _sectors.GetById(id);


            //Update Currency Detials
            exitsCurrency.SectorCode = sectors.SectorCode;
            exitsCurrency.SectorName = sectors.SectorName;
            exitsCurrency.IsoCode = sectors.IsoCode;
            exitsCurrency.CenterBankCode = sectors.CenterBankCode;
            exitsCurrency.SectorForeignname = sectors.SectorForeignname;
            //Save Changes
            await _sectors.SaveAll();


            return Ok(" sectors Updated Successfully ");
        }

    }
}
