using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintMersion.Web.Controllers
{
    public class OrdersController : GenericController<Order>
    {
        public OrdersController(IRepository<Order> repository, IRepository<Picture> repositoryPicture, IGlobal global, PrintMersionDBContext dBContext) : base(repository, repositoryPicture, global, dBContext)
        {
        }







        // GET: Orders/Create
        public override async Task<IActionResult> Create()
        {
            ViewData["IdAdminister"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Email");
            return await base.Create();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,OrderDate,DeliveryDate,Address,Subtotal,Total,DeliveryMethod,DetailedInformation,Tracking,Status,PaymentMethod,IdCustomer,IdAdminister")] Order order)
        {
          
            ViewData["IdAdminister"] = new SelectList(_context.Users, "Id", "Email", order.IdAdminister);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Email", order.IdCustomer);
            return await base.Create(order);
        }

        // GET: Orders/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.FirstOrDefault(o => o.Id == id.Value);
            ViewData["IdAdminister"] = new SelectList(_context.Users, "Id", "Email", order.IdAdminister);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Email", order.IdCustomer);
            return await base.Edit(id);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int? id, [Bind("Id,OrderDate,DeliveryDate,Address,Subtotal,Total,DeliveryMethod,DetailedInformation,Tracking,Status,PaymentMethod,IdCustomer,IdAdminister")] Order order)
        {
           
            ViewData["IdAdminister"] = new SelectList(_context.Users, "Id", "Email", order.IdAdminister);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Email", order.IdCustomer);
            return await base.Edit(id, order);
        }

     

      
    }
}
