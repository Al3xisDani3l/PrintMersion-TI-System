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
    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IRepository<Customer> repository, IRepository<Picture> repositoryPicture, IGlobal global, PrintMersionDBContext dBContext) : base(repository, repositoryPicture, global, dBContext)
        {
        }




      
        // GET: Customers/Details/5
      
        // GET: Customers/Create
        public override async Task<IActionResult> Create()
        {
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Street");
            return await base.Create();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,IdAddress,Phone")] Customer customer)
        {
           
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Street", customer.IdAddress);
            return await base.Create(customer);
        }

        // GET: Customers/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(o => o.Id == id.Value);
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Street", customer.IdAddress);
            return await base.Edit(id);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,Email,IdAddress,Phone")] Customer customer)
        {
           
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Street", customer.IdAddress);
            return await base.Edit(id, customer);
        }

      
    }
}
