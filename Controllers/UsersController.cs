using Microsoft.AspNetCore.Mvc;
using test_tryCatch.Data.Models;
using test_tryCatch.Data;

namespace test_tryCatch.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // Get all Users
        public IEnumerable<Usuario> GetEmployees()
        {
            return _context.Usuarios.Where(u => u.Status == "active").ToList();
        }

        [HttpGet("/user/{cedula}")] // Get user by personal ID
        public ActionResult<Usuario> GetUserByIdCard(string cedula)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Cedula == cedula);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("user/{id:int}")] // Get user by id in database
        public ActionResult<Usuario> GetUserById(int id)
        {
            var user = _context.Usuarios.Find(id);
            if (user is null)
                return NotFound();
            return user;
        }

        // Create user
        [HttpPost]
        public IActionResult CreateUser(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = usuario.Id }, usuario);
        }

        // Put Method
        [HttpPut("user/{id:int}")]
        public IActionResult UpdateUser(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            var existingUser = _context.Usuarios.Find(id);
            if (existingUser is null)
                return NotFound();


            existingUser.Nombres = usuario.Nombres;
            existingUser.Apellidos = usuario.Apellidos;
            existingUser.Celular = usuario.Celular;
            existingUser.Email = usuario.Email;
            existingUser.Direccion = usuario.Direccion;
            existingUser.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local);
            existingUser.Status = usuario.Status;
            existingUser.FechaNacimiento = usuario.FechaNacimiento;
            existingUser.Lat = usuario.Lat;
            existingUser.Lng = usuario.Lng;


            _context.SaveChanges();

            return NoContent();
        }

        // Delete user
        [HttpDelete("user/{id:int}")]
        public ActionResult<Usuario> DeleteUser(int id)
        {
            var User = _context.Usuarios.Find(id);
            if (User is null)
                return NotFound();

            User.Status = "inactive";
            _context.SaveChanges();

            return Ok();
        }
        //data
        int a = 10;
        //data
    }
}