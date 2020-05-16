using AzureFunction_EFCore.DataContext;
using AzureFunction_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_EFCore.Services
{
    public interface IArtistaService
    {
        Task<List<Artista>> GetAsync();
    }

    public class ArtistaService : IArtistaService
    {
        private readonly FunctionContext _context;
        public ArtistaService(FunctionContext context) => _context = context;

        public async Task<List<Artista>> GetAsync()
        {
            var artistas = new List<Artista>();

            try
            {
                artistas = await _context.Artistas.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return artistas;
        }
    }
}
