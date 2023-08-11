using Microsoft.AspNetCore.Mvc;
using test_tryCatch.Data;
using test_tryCatch.Data.Models;
namespace test_tryCatch.Controller;

[ApiController]
[Route("/tickets")]
public class TicketsController: ControllerBase{
  private readonly DataContext _context;
  public TicketsController(DataContext context)
  {
    _context = context;
  }

 [HttpGet("id_client/{id_client}")]
  public IEnumerable<Ticket> GetTicketsByClient(int id_client){
    return _context.Tickets.Where(b => b.IdUser == id_client).ToList();
  }
  [HttpGet("id_ticket/{id_ticket:int}")]
  public ActionResult<Ticket> GetTicketsById(int id_ticket){
     var ticketById = _context.Tickets.Find(id_ticket);
     if(ticketById is null)
      return NotFound();
    return ticketById;
  }
  // Post Method
  [HttpPost]
  public IActionResult CreateTicket(Ticket ticket){
    _context.Tickets.Add(ticket);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetTicketsById), new {id_ticket = ticket.Id}, ticket);
  }
  
}
