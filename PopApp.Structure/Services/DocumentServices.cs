﻿using Microsoft.EntityFrameworkCore;
using PopApp.Core.Entities;
using PopApp.Core.Interfaces.Services;
using PopApp.Structure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopApp.Structure.Services
{
    public class DocumentServices : IDocumentsServices
    {
        private readonly PopAppContext _context;

        public DocumentServices(PopAppContext context)
        {
            _context = context;
        }
        public async Task CreateDocument(Document document)
        {
            document.IsActive = true;
            _context.Add(document);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument(int id)
        {
            var document = await GetDocument(id);
            if (document != null)
            {
                document.IsActive = false;
                _context.Add(document);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Document> GetDocument(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == id);
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task UpdateDocument(int id, Document document)
        {
            var updateDocument = await GetDocument(id);
            if (updateDocument != null)
            {
                updateDocument.DocumentTitle = document.DocumentTitle;
                updateDocument.DocumentDescription = document.DocumentDescription;
                updateDocument.DocumentImage = document.DocumentImage;
                _context.Update(updateDocument);
                await _context.SaveChangesAsync();

            }
        }
    }
}
