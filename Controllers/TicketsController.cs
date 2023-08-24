using Microsoft.AspNetCore.Mvc;
using test_tryCatch.Data;
using test_tryCatch.Data.Models;
namespace test_tryCatch.Controller;

[ApiController]
[Route("/tickets")]
public class TicketsController : ControllerBase
{
    private readonly DataContext _context;
    public TicketsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("id_client/{id_client}")]
    public IEnumerable<Ticket> GetTicketsByClient(int id_client)
    {
        return _context.Tickets.Where(b => b.IdUser == id_client).ToList();
    }
    [HttpGet("id_ticket/{id_ticket:int}")]
    public ActionResult<Ticket> GetTicketsById(int id_ticket)
    {
        var ticketById = _context.Tickets.Find(id_ticket);
        if (ticketById is null)
            return NotFound();
        return ticketById;
    }
    // Post Method
   [HttpPost]
    public IActionResult CreateTicket(Ticket ticket)
    {
    // No asignar un valor al campo Id, ya que se generará automáticamente
    _context.Tickets.Add(ticket);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetTicketsById), new { id_ticket = ticket.Id }, ticket);
    }


    // Delete tickets
    [HttpDelete("ticket/{id:int}")]
    public ActionResult<Ticket> DeleteTicket(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket is null)
            return NotFound();

        ticket.Status = "inactive";
        _context.SaveChanges();

        return Ok();
    }

    // Put Method
    [HttpPut("ticket/{id:int}")]
    public IActionResult UpdateTicket(int id, Ticket ticket)
    {

        var existingTicket = _context.Tickets.Find(id);
        if (existingTicket is null)
            return NotFound();
            
        if (ticket.IdUser.HasValue)
            existingTicket.IdUser = ticket.IdUser;

        if (!string.IsNullOrEmpty(ticket.Direccion))
            existingTicket.Direccion = ticket.Direccion;

        if (ticket.Lat.HasValue)
            existingTicket.Lat = ticket.Lat;

        if (ticket.Lng.HasValue)
            existingTicket.Lng = ticket.Lng;

        if (!string.IsNullOrEmpty(ticket.Descripcion))
            existingTicket.Descripcion = ticket.Descripcion;

        if (!string.IsNullOrEmpty(ticket.ServiceType))
            existingTicket.ServiceType = ticket.ServiceType;

        if (!string.IsNullOrEmpty(ticket.Status))
            existingTicket.Status = ticket.Status;

        if (!string.IsNullOrEmpty(ticket.Priority))
            existingTicket.Priority = ticket.Priority;

        if (ticket.ServiceDate.HasValue)
            existingTicket.ServiceDate = ticket.ServiceDate;

        existingTicket.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local);

        _context.SaveChanges();
        return NoContent();
    }

    // Close Method
    [HttpDelete("ticketclose/{id:int}")]
    public ActionResult<Ticket> CloseTicket(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket is null)
            return NotFound();

        ticket.Status = "close";
        _context.SaveChanges();

        return Ok();
    }
}