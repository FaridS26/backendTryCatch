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
        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTicketsById), new { id_ticket = ticket.Id }, ticket);
    }

    // Delete ticket
    [HttpDelete("ticket/{id:int}")]
    public ActionResult<Ticket> DeleteTicket(int id)
    {
        var ticketChange = _context.Tickets.Find(id);
        if (User is null)
            return NotFound();

        ticketChange.Status = "inactve";
        _context.SaveChanges();

        return Ok();
    }

    // Put Method
    [HttpPut("ticket/{id:int}")]
    public IActionResult UpdateTicket(int id, Ticket ticket)
    {
        if (id != ticket.Id)
            return BadRequest();

        var existingTicket = _context.Tickets.Find(id);
        if (existingTicket is null)
            return NotFound();


        existingTicket.IdUser = ticket.IdUser;
        existingTicket.Direccion = ticket.Direccion;
        existingTicket.Lat = ticket.Lat;
        existingTicket.Lng = ticket.Lng;
        existingTicket.Descripcion = ticket.Descripcion;
        existingTicket.ServiceType = ticket.ServiceType;
        existingTicket.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local);
        existingTicket.Status = ticket.Status;
        existingTicket.Priority = ticket.Priority;
        existingTicket.ServiceDate = ticket.ServiceDate;


        _context.SaveChanges();

        return NoContent();
    }

    // Close Method
    [HttpDelete("ticketclose/{id:int}")]
    public ActionResult<Ticket> CloseTicket(int id)
    {
        var ticketChange = _context.Tickets.Find(id);
        if (User is null)
            return NotFound();

        ticketChange.Status = "close";
        _context.SaveChanges();

        return Ok();
    }
}