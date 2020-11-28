using AutoMapper;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Implementations
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly StarexDbContext _context;
        private readonly IMapper _mapper;

        public DeclarationRepository(StarexDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Create(DeclarationViewModel declarationViewModel)
        {
            var declaration = _mapper.Map<Declaration>(declarationViewModel);
            await _context.Declarations.AddAsync(declaration);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Declaration declaration)
        {
            throw new NotImplementedException();
        }
    }
}
