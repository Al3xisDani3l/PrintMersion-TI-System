using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.Data;

namespace PrintMersion.Web.Controllers
{
    public class AddressesController : GenericController<Address>
    {

        PrintMersionDBContext _context;
        public AddressesController(IRepository<Address> repository, IRepository<Picture> repositoryPicture, IGlobal global, PrintMersionDBContext dBContext) : base(repository, repositoryPicture, global,dBContext)
        {
            _context = dBContext;
        }





      
        // GET: Addresses/Create
       

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,InteriorNumber,ExteriorNumber,ZipCode,City,State,Country,Latitude,Logitude")] Address address)
        {
                 return await  base.Create();
        }

       
     

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Street,InteriorNumber,ExteriorNumber,ZipCode,City,State,Country,Latitude,Logitude")] Address address)
        {
            return await base.Edit(id);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
       

       
    }
}
