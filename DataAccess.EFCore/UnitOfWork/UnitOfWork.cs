﻿using DataAccess.EFCore.Repositories;
using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Developers = new DeveloperRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public IDeveloperRepository Developers { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
