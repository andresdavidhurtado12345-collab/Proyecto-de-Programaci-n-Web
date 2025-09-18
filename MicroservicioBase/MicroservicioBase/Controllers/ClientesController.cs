using Microsoft.AspNetCore.Mvc;
using MicroservicioBase.Models;

namespace MicroservicioBase.Controllers
{
    public class ClientesController : Controller
    {
        private static List<Cliente> listadoClientes = new List<Cliente>()
        {
            new Cliente { Id = 1, Nombre = "Yenny Perea", Email = "yennydinary@mail.com", Telefono="3001234567" },
            new Cliente { Id = 2, Nombre = "Texto de Prueba", Email = "texto@gmail.com", Telefono="3109876543" }
        };

        // GET: Clientes/Index
        public IActionResult Index()
        {
            return View(listadoClientes);
        }

        // GET: Clientes/Detalle/5
        public IActionResult Detalle(int id)
        {
            var cliente = listadoClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente nuevoCliente)
        {
            if (ModelState.IsValid)
            {
                nuevoCliente.Id = listadoClientes.Max(c => c.Id) + 1;
                listadoClientes.Add(nuevoCliente);
                return RedirectToAction(nameof(Index));
            }
            return View(nuevoCliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = listadoClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: Clientes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente clienteEditado)
        {
            if (ModelState.IsValid)
            {
                var cliente = listadoClientes.FirstOrDefault(c => c.Id == clienteEditado.Id);
                if (cliente == null) return NotFound();

                cliente.Nombre = clienteEditado.Nombre;
                cliente.Email = clienteEditado.Email;
                cliente.Telefono = clienteEditado.Telefono;
                cliente.Estado = clienteEditado.Estado;

                return RedirectToAction(nameof(Index));
            }
            return View(clienteEditado);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int id)
        {
            var cliente = listadoClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: Clientes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = listadoClientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                listadoClientes.Remove(cliente);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

