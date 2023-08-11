using Microsoft.AspNetCore.Mvc;
using test_tryCatch.Data;
using test_tryCatch.Data.Models;
namespace test_tryCatch.Controller;

[ApiController]
[Route("/employees")]
public class EmployeesController: ControllerBase{
  private readonly DataContext _context;
  public EmployeesController(DataContext context)
  {
    _context = context;
  }
// Get Methods
  [HttpGet] // Get all employees
  public IEnumerable<Empleado> GetEmployees(){
    return _context.Empleados.Where(b => b.Status == "active").ToList();
  }

  [HttpGet("/code/{code}")] // Get employees by unique Code
  public ActionResult<Empleado> GetEmployeeByCode(string code){
    var employee = _context.Empleados.SingleOrDefault(b => b.CodigoEmpleado == code);
    if(employee is null)
      return NotFound();
    return employee;
  }
  [HttpGet("id/{id:int}")] // Get employees by id in database
  public ActionResult<Empleado> GetEmployeeById(int id){
    var employee = _context.Empleados.Find(id);
    if(employee is null)
      return NotFound();
    return employee;
  }
  // Post Method
  [HttpPost]
  public IActionResult CreateEmployee(Empleado empleado){
    _context.Empleados.Add(empleado);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetEmployeeById), new {id = empleado.Id}, empleado);
  }
  // Put Method
  [HttpPut("id/{id:int}")]
  public IActionResult UpdateEmployee(int id, Empleado empleado){
    if(id != empleado.Id)
      return BadRequest();

    var existingEmployee = _context.Empleados.Find(id);
    if(existingEmployee is null)
      return NotFound();

    
    existingEmployee.Nombres = empleado.Nombres;
    existingEmployee.Apellidos = empleado.Apellidos;
    existingEmployee.Celular = empleado.Celular;
    existingEmployee.Email = empleado.Email;
    existingEmployee.Direccion = empleado.Direccion;
    existingEmployee.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local);
    existingEmployee.Rol = empleado.Rol;
    existingEmployee.Status = empleado.Status;

    _context.SaveChanges();

    return NoContent();  
  }
  [HttpDelete("id/{id:int}")]
    public ActionResult<Empleado> DeleteEmployee(int id){
    var employee = _context.Empleados.Find(id);
    if(employee is null)
      return NotFound();

    employee.Status = "inactive";
    _context.SaveChanges();

    return Ok();
  }

}